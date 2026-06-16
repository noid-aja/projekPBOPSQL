-- ============================================================================
-- KAPTEN - FITUR POSTGRESQL UNTUK DIPANGGIL DARI WINFORMS
-- Materi: GROUP BY, CUBE/ROLLUP/GROUPING SETS, SUBQUERY, TEORI HIMPUNAN,
--         VIEW, STATEMENT, FUNCTION, STORED PROCEDURE, TRANSACTION, TRIGGER
--
-- PRASYARAT:
--   Jalankan Kapten_table.sql lebih dahulu sampai tabel schema kapten tersedia.
--
-- CATATAN:
--   File ini TIDAK menghapus tabel/data. Aman dijalankan ulang karena objek
--   dibuat dengan CREATE OR REPLACE dan trigger lama di-drop sebelum dibuat.
--
-- REVISI:
--   Diselaraskan dengan DbExecutor dan Context WinForms terbaru.
--   Operasi tulis memakai CALL procedure; operasi baca memakai VIEW/FUNCTION.
--   Mencakup UserContext, ProdukKopiContext, InspeksiContext, LelangContext,
--   BidContext, TransaksiContext, DashboardContext, JenisKopiContext, dan
--   PemenangLelangContext.
-- ============================================================================

CREATE SCHEMA IF NOT EXISTS kapten;

-- ============================================================================
-- 01. FUNCTION: LOGIKA BISNIS YANG DAPAT DIPAKAI ULANG
-- ============================================================================

CREATE OR REPLACE FUNCTION kapten.fn_tentukan_grade(p_nilai INT)
RETURNS VARCHAR(10)
LANGUAGE plpgsql
IMMUTABLE
STRICT
AS $$
BEGIN
    IF p_nilai NOT BETWEEN 0 AND 100 THEN
        RAISE EXCEPTION 'Nilai QC harus 0 sampai 100.';
    END IF;

    RETURN CASE
        WHEN p_nilai >= 85 THEN 'A'
        WHEN p_nilai >= 80 THEN 'B'
        WHEN p_nilai >= 60 THEN 'C'
        ELSE 'D'
    END;
END;
$$;

CREATE OR REPLACE FUNCTION kapten.fn_tentukan_status_qc(p_nilai INT)
RETURNS VARCHAR(30)
LANGUAGE plpgsql
IMMUTABLE
STRICT
AS $$
BEGIN
    IF p_nilai NOT BETWEEN 0 AND 100 THEN
        RAISE EXCEPTION 'Nilai QC harus 0 sampai 100.';
    END IF;

    RETURN CASE
        WHEN p_nilai >= 80 THEN 'lolos_qc'
        ELSE 'ditolak_qc'
    END;
END;
$$;

CREATE OR REPLACE FUNCTION kapten.fn_hitung_biaya_komisi(
    p_total_bayar NUMERIC,
    p_persentase NUMERIC DEFAULT 5.00
)
RETURNS NUMERIC(12,2)
LANGUAGE plpgsql
IMMUTABLE
STRICT
AS $$
BEGIN
    IF p_total_bayar < 0 THEN
        RAISE EXCEPTION 'Total bayar tidak boleh negatif.';
    END IF;

    IF p_persentase NOT BETWEEN 0 AND 100 THEN
        RAISE EXCEPTION 'Persentase komisi harus 0 sampai 100.';
    END IF;

    RETURN ROUND(p_total_bayar * p_persentase / 100.0, 2);
END;
$$;

CREATE OR REPLACE FUNCTION kapten.fn_hitung_diterima_petani(
    p_total_bayar NUMERIC,
    p_persentase NUMERIC DEFAULT 5.00
)
RETURNS NUMERIC(12,2)
LANGUAGE sql
IMMUTABLE
STRICT
AS $$
    SELECT ROUND(
        p_total_bayar - kapten.fn_hitung_biaya_komisi(p_total_bayar, p_persentase),
        2
    )::NUMERIC(12,2);
$$;

-- Function tabel: data produk milik petani untuk DataGridView.
CREATE OR REPLACE FUNCTION kapten.fn_produk_petani(p_id_petani INT)
RETURNS TABLE (
    id_produk INT,
    nama_produk VARCHAR,
    nama_jenis VARCHAR,
    berat_kg NUMERIC,
    harga_pengajuan NUMERIC,
    status_produk VARCHAR,
    nilai INT,
    grade VARCHAR,
    harga_rekomendasi NUMERIC,
    status_inspeksi VARCHAR,
    id_lelang INT,
    status_lelang VARCHAR,
    bid_tertinggi NUMERIC
)
LANGUAGE sql
STABLE
AS $$
    SELECT
        p.id_produk,
        p.nama_produk,
        jk.nama_jenis,
        p.berat_kg,
        p.harga_pengajuan,
        p.status_produk,
        i.nilai,
        i.grade,
        i.harga_rekomendasi,
        i.status_inspeksi,
        l.id_lelang,
        l.status_lelang,
        (SELECT MAX(b.nominal)
         FROM kapten.bid b
         WHERE b.id_lelang = l.id_lelang) AS bid_tertinggi
    FROM kapten.produk_kopi p
    JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
    LEFT JOIN kapten.inspeksi i ON i.id_produk = p.id_produk
    LEFT JOIN kapten.lelang l ON l.id_produk = p.id_produk
    WHERE p.id_petani = p_id_petani
    ORDER BY p.id_produk DESC;
$$;

-- Function tabel: lelang yang boleh diikuti pembeli.
CREATE OR REPLACE FUNCTION kapten.fn_lelang_tersedia(p_id_pembeli INT)
RETURNS TABLE (
    id_lelang INT,
    id_produk INT,
    nama_produk VARCHAR,
    nama_petani VARCHAR,
    nama_jenis VARCHAR,
    berat_kg NUMERIC,
    bid_minimum NUMERIC,
    bid_tertinggi NUMERIC,
    tgl_akhir TIMESTAMP,
    lokasi_lelang VARCHAR
)
LANGUAGE sql
STABLE
AS $$
    SELECT
        l.id_lelang,
        p.id_produk,
        p.nama_produk,
        u.nama_lengkap,
        jk.nama_jenis,
        p.berat_kg,
        l.bid_minimum,
        COALESCE((SELECT MAX(b.nominal)
                  FROM kapten.bid b
                  WHERE b.id_lelang = l.id_lelang), 0),
        l.tgl_akhir,
        l.lokasi_lelang
    FROM kapten.lelang l
    JOIN kapten.produk_kopi p ON p.id_produk = l.id_produk
    JOIN kapten.users u ON u.id_user = p.id_petani
    JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
    WHERE l.status_lelang = 'berlangsung'
      AND CURRENT_TIMESTAMP BETWEEN l.tgl_mulai AND l.tgl_akhir
      AND p.id_petani <> p_id_pembeli
    ORDER BY l.tgl_akhir, l.id_lelang;
$$;

CREATE OR REPLACE FUNCTION kapten.fn_riwayat_bid_pembeli(p_id_pembeli INT)
RETURNS TABLE (
    id_bid INT,
    id_lelang INT,
    nama_produk VARCHAR,
    nominal NUMERIC,
    tgl_bid TIMESTAMP,
    status_lelang VARCHAR,
    status_bid VARCHAR
)
LANGUAGE sql
STABLE
AS $$
    SELECT
        b.id_bid,
        b.id_lelang,
        p.nama_produk,
        b.nominal,
        b.tgl_bid,
        l.status_lelang,
        CASE
            WHEN pl.id_bid = b.id_bid THEN 'menang'
            WHEN l.status_lelang IN ('selesai', 'dibatalkan') THEN 'kalah'
            WHEN b.nominal = (SELECT MAX(b2.nominal)
                              FROM kapten.bid b2
                              WHERE b2.id_lelang = b.id_lelang) THEN 'tertinggi_sementara'
            ELSE 'terlampaui'
        END::VARCHAR AS status_bid
    FROM kapten.bid b
    JOIN kapten.lelang l ON l.id_lelang = b.id_lelang
    JOIN kapten.produk_kopi p ON p.id_produk = l.id_produk
    LEFT JOIN kapten.pemenang_lelang pl ON pl.id_lelang = b.id_lelang
    WHERE b.id_pembeli = p_id_pembeli
    ORDER BY b.tgl_bid DESC;
$$;

-- USER: REGISTER
-- Register user dan berikan satu role awal.
CREATE OR REPLACE PROCEDURE kapten.sp_register_user(
    p_nama_lengkap VARCHAR,
    p_username VARCHAR,
    p_password VARCHAR,
    p_no_telp VARCHAR,
    p_nama_role VARCHAR
)
LANGUAGE plpgsql
AS $$
DECLARE
    v_id_user INT;
    v_id_role INT;
    v_role VARCHAR(30) := LOWER(TRIM(p_nama_role));
BEGIN
    IF v_role NOT IN ('petani', 'pembeli', 'inspektor') THEN
        RAISE EXCEPTION
            'Role hanya boleh petani, pembeli, atau inspektor.';
    END IF;

    IF NULLIF(TRIM(p_nama_lengkap), '') IS NULL THEN
        RAISE EXCEPTION 'Nama lengkap tidak boleh kosong.';
    END IF;

    IF NULLIF(TRIM(p_username), '') IS NULL THEN
        RAISE EXCEPTION 'Username tidak boleh kosong.';
    END IF;

    IF LENGTH(TRIM(p_username)) < 4 THEN
        RAISE EXCEPTION 'Username minimal 4 karakter.';
    END IF;

    IF NULLIF(p_password, '') IS NULL THEN
        RAISE EXCEPTION 'Password tidak boleh kosong.';
    END IF;

    IF LENGTH(p_password) < 8 THEN
        RAISE EXCEPTION 'Password minimal 8 karakter.';
    END IF;

    -- Kolom users.no_telp pada schema utama bersifat NOT NULL.
    IF NULLIF(TRIM(p_no_telp), '') IS NULL THEN
        RAISE EXCEPTION 'Nomor telepon tidak boleh kosong.';
    END IF;

    IF EXISTS (
        SELECT 1
        FROM kapten.users
        WHERE LOWER(username) = LOWER(TRIM(p_username))
    ) THEN
        RAISE EXCEPTION 'Username % sudah digunakan.', p_username;
    END IF;

    IF EXISTS (
        SELECT 1
        FROM kapten.users
        WHERE no_telp = TRIM(p_no_telp)
    ) THEN
        RAISE EXCEPTION 'Nomor telepon sudah digunakan.';
    END IF;

    SELECT id_role
    INTO v_id_role
    FROM kapten.roles
    WHERE LOWER(nama_role) = v_role;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Role % tidak ditemukan.', v_role;
    END IF;

    INSERT INTO kapten.users (
        nama_lengkap,
        username,
        password,
        no_telp,
        is_aktif
    )
    VALUES (
        TRIM(p_nama_lengkap),
        TRIM(p_username),
        p_password,
        TRIM(p_no_telp),
        TRUE
    )
    RETURNING id_user INTO v_id_user;

    INSERT INTO kapten.user_roles (
        id_user,
        id_role,
        is_role_aktif
    )
    VALUES (
        v_id_user,
        v_id_role,
        TRUE
    );
END;
$$;


-- USER: UPDATE PROFILE
-- Ubah nama lengkap dan nomor telepon user.
CREATE OR REPLACE PROCEDURE kapten.sp_update_profile(
    p_id_user INT,
    p_nama_lengkap VARCHAR,
    p_no_telp VARCHAR
)
LANGUAGE plpgsql
AS $$
BEGIN
    IF p_id_user <= 0 THEN
        RAISE EXCEPTION 'ID user tidak valid.';
    END IF;

    IF NULLIF(TRIM(p_nama_lengkap), '') IS NULL THEN
        RAISE EXCEPTION 'Nama lengkap tidak boleh kosong.';
    END IF;

    IF NULLIF(TRIM(p_no_telp), '') IS NULL THEN
        RAISE EXCEPTION 'Nomor telepon tidak boleh kosong.';
    END IF;

    IF EXISTS (
        SELECT 1
        FROM kapten.users
        WHERE no_telp = TRIM(p_no_telp)
          AND id_user <> p_id_user
    ) THEN
        RAISE EXCEPTION 'Nomor telepon sudah digunakan user lain.';
    END IF;

    UPDATE kapten.users
    SET nama_lengkap = TRIM(p_nama_lengkap),
        no_telp = TRIM(p_no_telp)
    WHERE id_user = p_id_user;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'User ID % tidak ditemukan.', p_id_user;
    END IF;
END;
$$;


-- USER: UPDATE PASSWORD
-- Ubah password user aktif.
CREATE OR REPLACE PROCEDURE kapten.sp_update_password(
    p_id_user INT,
    p_password_baru VARCHAR
)
LANGUAGE plpgsql
AS $$
BEGIN
    IF p_id_user <= 0 THEN
        RAISE EXCEPTION 'ID user tidak valid.';
    END IF;

    IF NULLIF(p_password_baru, '') IS NULL THEN
        RAISE EXCEPTION 'Password baru tidak boleh kosong.';
    END IF;

    IF LENGTH(p_password_baru) < 8 THEN
        RAISE EXCEPTION 'Password baru minimal 8 karakter.';
    END IF;

    UPDATE kapten.users
    SET password = p_password_baru
    WHERE id_user = p_id_user
      AND is_aktif = TRUE;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'User tidak ditemukan atau sudah dinonaktifkan.';
    END IF;
END;
$$;


-- Tambah role baru atau aktifkan kembali role yang sebelumnya nonaktif.
CREATE OR REPLACE PROCEDURE kapten.sp_tambah_role_user(
    p_id_user INT,
    p_nama_role VARCHAR
)
LANGUAGE plpgsql
AS $$
DECLARE
    v_id_role INT;
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM kapten.users
        WHERE id_user = p_id_user
    ) THEN
        RAISE EXCEPTION 'User ID % tidak ditemukan.', p_id_user;
    END IF;

    SELECT id_role
    INTO v_id_role
    FROM kapten.roles
    WHERE LOWER(nama_role) = LOWER(TRIM(p_nama_role));

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Role % tidak ditemukan.', p_nama_role;
    END IF;

    INSERT INTO kapten.user_roles (
        id_user,
        id_role,
        is_role_aktif
    )
    VALUES (
        p_id_user,
        v_id_role,
        TRUE
    )
    ON CONFLICT (id_user, id_role)
    DO UPDATE SET is_role_aktif = TRUE;
END;
$$;

-- USER: AUTENTIKASI
CREATE OR REPLACE FUNCTION kapten.fn_authenticate_user(
    p_username VARCHAR,
    p_password VARCHAR
)
RETURNS TABLE (
    id_user INT,
    nama_lengkap VARCHAR,
    username VARCHAR,
    no_telp VARCHAR,
    is_aktif BOOLEAN,
    id_role INT,
    nama_role VARCHAR
)
LANGUAGE sql
STABLE
AS $$
    SELECT
        u.id_user,
        u.nama_lengkap,
        u.username,
        u.no_telp,
        u.is_aktif,
        r.id_role,
        r.nama_role
    FROM kapten.users u
    JOIN kapten.user_roles ur
        ON ur.id_user = u.id_user
    JOIN kapten.roles r
        ON r.id_role = ur.id_role
    WHERE LOWER(u.username) = LOWER(TRIM(p_username))
      AND u.password = p_password
      AND u.is_aktif = TRUE
      AND ur.is_role_aktif = TRUE
    ORDER BY r.id_role;
$$;

-- USER: CEK NOMOR TELEPON
CREATE OR REPLACE FUNCTION kapten.fn_no_telp_terpakai(
    p_no_telp VARCHAR
)
RETURNS BOOLEAN
LANGUAGE sql
STABLE
AS $$
    SELECT CASE
        WHEN NULLIF(TRIM(p_no_telp), '') IS NULL
            THEN FALSE
        ELSE EXISTS (
            SELECT 1
            FROM kapten.users
            WHERE no_telp = TRIM(p_no_telp)
        )
    END;
$$;

-- ============================================================================
-- 02. TRIGGER: OTOMATISASI DAN VALIDASI DI DATABASE
-- ============================================================================

-- Grade dan status QC otomatis dari nilai.
CREATE OR REPLACE FUNCTION kapten.trg_set_hasil_inspeksi()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
BEGIN
    NEW.grade := kapten.fn_tentukan_grade(NEW.nilai);
    NEW.status_inspeksi := kapten.fn_tentukan_status_qc(NEW.nilai);
    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS before_inspeksi_set_hasil ON kapten.inspeksi;
CREATE TRIGGER before_inspeksi_set_hasil
BEFORE INSERT OR UPDATE OF nilai
ON kapten.inspeksi
FOR EACH ROW
EXECUTE FUNCTION kapten.trg_set_hasil_inspeksi();

-- Status produk mengikuti hasil QC.
CREATE OR REPLACE FUNCTION kapten.trg_sinkron_status_produk_qc()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
BEGIN
    UPDATE kapten.produk_kopi
    SET status_produk = NEW.status_inspeksi
    WHERE id_produk = NEW.id_produk;
    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS after_inspeksi_sinkron_produk ON kapten.inspeksi;
CREATE TRIGGER after_inspeksi_sinkron_produk
AFTER INSERT OR UPDATE OF nilai, status_inspeksi
ON kapten.inspeksi
FOR EACH ROW
EXECUTE FUNCTION kapten.trg_sinkron_status_produk_qc();

-- Produk harus lolos QC sebelum dibuatkan lelang.
CREATE OR REPLACE FUNCTION kapten.trg_validasi_produk_lelang()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
DECLARE
    v_status VARCHAR(30);
BEGIN
    SELECT status_produk
    INTO v_status
    FROM kapten.produk_kopi
    WHERE id_produk = NEW.id_produk;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Produk ID % tidak ditemukan.', NEW.id_produk;
    END IF;

    IF v_status <> 'lolos_qc' THEN
        RAISE EXCEPTION 'Produk harus lolos_qc. Status sekarang: %.', v_status;
    END IF;

    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS before_lelang_validasi_produk ON kapten.lelang;
CREATE TRIGGER before_lelang_validasi_produk
BEFORE INSERT OR UPDATE OF id_produk
ON kapten.lelang
FOR EACH ROW
EXECUTE FUNCTION kapten.trg_validasi_produk_lelang();

-- Saat lelang dibuat, status produk langsung disinkronkan.
CREATE OR REPLACE FUNCTION kapten.trg_sinkron_produk_setelah_lelang()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
BEGIN
    UPDATE kapten.produk_kopi
    SET status_produk = CASE
        WHEN NEW.status_lelang = 'berlangsung' THEN 'berlangsung'
        ELSE 'dijadwalkan_lelang'
    END
    WHERE id_produk = NEW.id_produk;
    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS after_lelang_sinkron_produk ON kapten.lelang;
DROP TRIGGER IF EXISTS after_lelang_set_produk ON kapten.lelang;
CREATE TRIGGER after_lelang_sinkron_produk
AFTER INSERT
ON kapten.lelang
FOR EACH ROW
EXECUTE FUNCTION kapten.trg_sinkron_produk_setelah_lelang();

-- Validasi setiap bid.
CREATE OR REPLACE FUNCTION kapten.trg_validasi_bid()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
DECLARE
    v_bid_minimum NUMERIC(12,2);
    v_bid_tertinggi NUMERIC(12,2);
    v_status_lelang VARCHAR(30);
    v_tgl_mulai TIMESTAMP;
    v_tgl_akhir TIMESTAMP;
    v_id_petani INT;
    v_pembeli_valid BOOLEAN;
BEGIN
    SELECT l.bid_minimum, l.status_lelang, l.tgl_mulai, l.tgl_akhir, p.id_petani
    INTO v_bid_minimum, v_status_lelang, v_tgl_mulai, v_tgl_akhir, v_id_petani
    FROM kapten.lelang l
    JOIN kapten.produk_kopi p ON p.id_produk = l.id_produk
    WHERE l.id_lelang = NEW.id_lelang;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Lelang ID % tidak ditemukan.', NEW.id_lelang;
    END IF;

    IF v_status_lelang <> 'berlangsung'
       OR CURRENT_TIMESTAMP NOT BETWEEN v_tgl_mulai AND v_tgl_akhir THEN
        RAISE EXCEPTION 'Bid hanya bisa dilakukan saat lelang sedang berlangsung.';
    END IF;

    SELECT EXISTS (
        SELECT 1
        FROM kapten.users u
        JOIN kapten.user_roles ur ON ur.id_user = u.id_user
        JOIN kapten.roles r ON r.id_role = ur.id_role
        WHERE u.id_user = NEW.id_pembeli
          AND u.is_aktif = TRUE
          AND ur.is_role_aktif = TRUE
          AND LOWER(r.nama_role) = 'pembeli'
    ) INTO v_pembeli_valid;

    IF NOT v_pembeli_valid THEN
        RAISE EXCEPTION 'User ID % bukan pembeli aktif.', NEW.id_pembeli;
    END IF;

    IF NEW.id_pembeli = v_id_petani THEN
        RAISE EXCEPTION 'Petani tidak boleh menawar produk miliknya sendiri.';
    END IF;

    SELECT MAX(b.nominal)
    INTO v_bid_tertinggi
    FROM kapten.bid b
    WHERE b.id_lelang = NEW.id_lelang
      AND b.id_bid <> COALESCE(NEW.id_bid, -1);

    IF NEW.nominal < v_bid_minimum THEN
        RAISE EXCEPTION 'Bid minimal adalah %.', v_bid_minimum;
    END IF;

    IF v_bid_tertinggi IS NOT NULL AND NEW.nominal <= v_bid_tertinggi THEN
        RAISE EXCEPTION 'Bid harus lebih tinggi dari bid saat ini: %.', v_bid_tertinggi;
    END IF;

    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS before_bid_validasi ON kapten.bid;
CREATE TRIGGER before_bid_validasi
BEFORE INSERT OR UPDATE OF id_lelang, id_pembeli, nominal
ON kapten.bid
FOR EACH ROW
EXECUTE FUNCTION kapten.trg_validasi_bid();

-- Komisi dihitung database, bukan WinForms.
CREATE OR REPLACE FUNCTION kapten.trg_hitung_transaksi()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
BEGIN
    NEW.biaya_komisi := kapten.fn_hitung_biaya_komisi(
        NEW.total_bayar,
        NEW.persentase_komisi
    );
    NEW.total_diterima_petani := kapten.fn_hitung_diterima_petani(
        NEW.total_bayar,
        NEW.persentase_komisi
    );
    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS before_transaksi_hitung ON kapten.transaksi;
CREATE TRIGGER before_transaksi_hitung
BEFORE INSERT OR UPDATE OF total_bayar, persentase_komisi
ON kapten.transaksi
FOR EACH ROW
EXECUTE FUNCTION kapten.trg_hitung_transaksi();

-- ============================================================================
-- 03. STORED PROCEDURE + STATEMENT INSERT/UPDATE/DELETE
-- Semua procedure berikut dipanggil WinForms dengan CALL kapten.nama_procedure(...)
-- ============================================================================

-- PRODUK: INSERT
CREATE OR REPLACE PROCEDURE kapten.sp_tambah_produk(
    p_id_petani INT,
    p_id_jenis INT,
    p_nama_produk VARCHAR,
    p_berat_kg NUMERIC,
    p_harga_pengajuan NUMERIC,
    p_deskripsi TEXT DEFAULT NULL
)
LANGUAGE plpgsql
AS $$
BEGIN
    IF NULLIF(TRIM(p_nama_produk), '') IS NULL THEN
        RAISE EXCEPTION 'Nama produk tidak boleh kosong.';
    END IF;

    IF p_berat_kg <= 0 THEN
        RAISE EXCEPTION 'Berat produk harus lebih dari 0 kg.';
    END IF;

    IF p_harga_pengajuan <= 0 THEN
        RAISE EXCEPTION 'Harga pengajuan harus lebih dari Rp0.';
    END IF;

    IF NOT EXISTS (
        SELECT 1
        FROM kapten.jenis_kopi
        WHERE id_jenis = p_id_jenis
    ) THEN
        RAISE EXCEPTION 'Jenis kopi ID % tidak ditemukan.', p_id_jenis;
    END IF;

    IF NOT EXISTS (
        SELECT 1
        FROM kapten.users u
        JOIN kapten.user_roles ur ON ur.id_user = u.id_user
        JOIN kapten.roles r ON r.id_role = ur.id_role
        WHERE u.id_user = p_id_petani
          AND u.is_aktif = TRUE
          AND ur.is_role_aktif = TRUE
          AND LOWER(r.nama_role) = 'petani'
    ) THEN
        RAISE EXCEPTION 'User ID % bukan petani aktif.', p_id_petani;
    END IF;

    INSERT INTO kapten.produk_kopi (
        id_petani,
        id_jenis,
        nama_produk,
        berat_kg,
        harga_pengajuan,
        deskripsi,
        status_produk
    )
    VALUES (
        p_id_petani,
        p_id_jenis,
        TRIM(p_nama_produk),
        p_berat_kg,
        p_harga_pengajuan,
        NULLIF(TRIM(p_deskripsi), ''),
        'pending_inspeksi'
    );
END;
$$;


-- PRODUK: UPDATE harga pengajuan; hanya boleh sebelum lelang dibuat.
CREATE OR REPLACE PROCEDURE kapten.sp_ubah_harga_produk(
    p_id_produk INT,
    p_id_petani INT,
    p_harga_baru NUMERIC
)
LANGUAGE plpgsql
AS $$
BEGIN
    IF p_harga_baru <= 0 THEN
        RAISE EXCEPTION 'Harga baru harus lebih dari Rp0.';
    END IF;

    UPDATE kapten.produk_kopi p
    SET harga_pengajuan = p_harga_baru
    WHERE p.id_produk = p_id_produk
      AND p.id_petani = p_id_petani
      AND p.status_produk IN (
          'pending_inspeksi',
          'lolos_qc',
          'ditolak_qc'
      )
      AND NOT EXISTS (
          SELECT 1
          FROM kapten.lelang l
          WHERE l.id_produk = p.id_produk
      );

    IF NOT FOUND THEN
        RAISE EXCEPTION
            'Produk tidak ditemukan, bukan milik petani, atau sudah masuk lelang.';
    END IF;
END;
$$;


-- DELETE produk pending.
CREATE OR REPLACE PROCEDURE kapten.sp_hapus_produk_pending(
    p_id_produk INT,
    p_id_petani INT
)
LANGUAGE plpgsql
AS $$
BEGIN
    DELETE FROM kapten.produk_kopi
    WHERE id_produk = p_id_produk
      AND id_petani = p_id_petani
      AND status_produk = 'pending_inspeksi';

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Produk hanya dapat dihapus oleh pemilik saat masih pending_inspeksi.';
    END IF;
END;
$$;

-- INSPEKSI: UPSERT hasil QC. Grade dan status dihitung oleh trigger database.
CREATE OR REPLACE PROCEDURE kapten.sp_simpan_inspeksi(
    p_id_produk INT,
    p_id_inspektor INT,
    p_nilai INT,
    p_harga_rekomendasi NUMERIC,
    p_catatan TEXT DEFAULT NULL
)
LANGUAGE plpgsql
AS $$
DECLARE
    v_status_produk VARCHAR(30);
BEGIN
    IF p_nilai NOT BETWEEN 0 AND 100 THEN
        RAISE EXCEPTION 'Nilai QC harus 0 sampai 100.';
    END IF;

    IF p_harga_rekomendasi <= 0 THEN
        RAISE EXCEPTION 'Harga rekomendasi harus lebih dari Rp0.';
    END IF;

    IF NOT EXISTS (
        SELECT 1
        FROM kapten.users u
        JOIN kapten.user_roles ur ON ur.id_user = u.id_user
        JOIN kapten.roles r ON r.id_role = ur.id_role
        WHERE u.id_user = p_id_inspektor
          AND u.is_aktif = TRUE
          AND ur.is_role_aktif = TRUE
          AND LOWER(r.nama_role) = 'inspektor'
    ) THEN
        RAISE EXCEPTION 'User ID % bukan inspektor aktif.', p_id_inspektor;
    END IF;

    SELECT status_produk
    INTO v_status_produk
    FROM kapten.produk_kopi
    WHERE id_produk = p_id_produk
    FOR UPDATE;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Produk ID % tidak ditemukan.', p_id_produk;
    END IF;

    IF EXISTS (
        SELECT 1
        FROM kapten.lelang
        WHERE id_produk = p_id_produk
    ) THEN
        RAISE EXCEPTION
            'Produk ID % sudah memiliki lelang dan tidak dapat diinspeksi ulang.',
            p_id_produk;
    END IF;

    IF v_status_produk NOT IN (
        'pending_inspeksi',
        'lolos_qc',
        'ditolak_qc'
    ) THEN
        RAISE EXCEPTION
            'Produk tidak dapat diinspeksi saat berstatus %.',
            v_status_produk;
    END IF;

    INSERT INTO kapten.inspeksi (
        id_produk,
        id_inspektor,
        tgl_inspeksi,
        nilai,
        grade,
        harga_rekomendasi,
        catatan,
        status_inspeksi
    )
    VALUES (
        p_id_produk,
        p_id_inspektor,
        CURRENT_DATE,
        p_nilai,
        kapten.fn_tentukan_grade(p_nilai),
        p_harga_rekomendasi,
        NULLIF(TRIM(p_catatan), ''),
        kapten.fn_tentukan_status_qc(p_nilai)
    )
    ON CONFLICT (id_produk)
    DO UPDATE SET
        id_inspektor = EXCLUDED.id_inspektor,
        tgl_inspeksi = CURRENT_DATE,
        nilai = EXCLUDED.nilai,
        harga_rekomendasi = EXCLUDED.harga_rekomendasi,
        catatan = EXCLUDED.catatan;
END;
$$;


-- LELANG: hapus overload lama lima parameter agar CALL WinForms tidak ambigu.
DROP PROCEDURE IF EXISTS kapten.sp_buka_lelang(
    INTEGER,
    NUMERIC,
    TIMESTAMP WITHOUT TIME ZONE,
    TIMESTAMP WITHOUT TIME ZONE,
    CHARACTER VARYING
);

-- Buka lelang: harga minimum diambil dari rekomendasi QC dan durasi dihitung DB.
CREATE OR REPLACE PROCEDURE kapten.sp_buka_lelang(
    p_id_produk INT,
    p_lokasi VARCHAR DEFAULT NULL,
    p_durasi_menit INT DEFAULT 3
)
LANGUAGE plpgsql
AS $$
DECLARE
    v_bid_minimum NUMERIC(12,2);
    v_status_produk VARCHAR(30);
    v_tgl_mulai TIMESTAMP := LOCALTIMESTAMP;
    v_tgl_akhir TIMESTAMP;
BEGIN
    IF p_id_produk <= 0 THEN
        RAISE EXCEPTION 'ID produk tidak valid.';
    END IF;

    IF p_durasi_menit <= 0 THEN
        RAISE EXCEPTION 'Durasi lelang harus lebih dari 0 menit.';
    END IF;

    SELECT status_produk
    INTO v_status_produk
    FROM kapten.produk_kopi
    WHERE id_produk = p_id_produk
    FOR UPDATE;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Produk ID % tidak ditemukan.', p_id_produk;
    END IF;

    IF v_status_produk <> 'lolos_qc' THEN
        RAISE EXCEPTION
            'Produk belum dapat dilelang. Status sekarang: %.',
            v_status_produk;
    END IF;

    IF EXISTS (
        SELECT 1
        FROM kapten.lelang
        WHERE id_produk = p_id_produk
    ) THEN
        RAISE EXCEPTION 'Produk ID % sudah memiliki lelang.', p_id_produk;
    END IF;

    SELECT harga_rekomendasi
    INTO v_bid_minimum
    FROM kapten.inspeksi
    WHERE id_produk = p_id_produk
      AND status_inspeksi = 'lolos_qc';

    IF NOT FOUND OR v_bid_minimum IS NULL THEN
        RAISE EXCEPTION
            'Produk belum memiliki rekomendasi harga dari Inspektor.';
    END IF;

    IF v_bid_minimum <= 0 THEN
        RAISE EXCEPTION 'Harga rekomendasi harus lebih dari Rp0.';
    END IF;

    v_tgl_akhir :=
        v_tgl_mulai + MAKE_INTERVAL(mins => p_durasi_menit);

    INSERT INTO kapten.lelang (
        id_produk,
        bid_minimum,
        tgl_mulai,
        tgl_akhir,
        lokasi_lelang,
        status_lelang
    )
    VALUES (
        p_id_produk,
        v_bid_minimum,
        v_tgl_mulai,
        v_tgl_akhir,
        NULLIF(TRIM(p_lokasi), ''),
        'berlangsung'
    );

    -- Trigger after_lelang_sinkron_produk menyetel produk menjadi berlangsung.
END;
$$;


-- Pasang bid secara atomik dan aktifkan perlindungan anti-sniper.
CREATE OR REPLACE PROCEDURE kapten.sp_pasang_bid(
    p_id_lelang INT,
    p_id_pembeli INT,
    p_nominal NUMERIC
)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Lock satu lelang agar dua bid bersamaan divalidasi secara berurutan.
    PERFORM 1
    FROM kapten.lelang
    WHERE id_lelang = p_id_lelang
    FOR UPDATE;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Lelang ID % tidak ditemukan.', p_id_lelang;
    END IF;

    INSERT INTO kapten.bid (
        id_lelang,
        id_pembeli,
        nominal
    )
    VALUES (
        p_id_lelang,
        p_id_pembeli,
        p_nominal
    );

    UPDATE kapten.lelang
    SET tgl_akhir = tgl_akhir + INTERVAL '10 seconds'
    WHERE id_lelang = p_id_lelang
      AND tgl_akhir > CURRENT_TIMESTAMP
      AND tgl_akhir - CURRENT_TIMESTAMP <= INTERVAL '1 minute';
END;
$$;


-- Menutup lelang, memilih bid tertinggi, membuat pemenang dan transaksi.
-- Jika tidak ada bid: lelang + produk dibatalkan, pemenang/transaksi tidak dibuat.
CREATE OR REPLACE PROCEDURE kapten.sp_tutup_lelang(
    p_id_lelang INT,
    p_persentase_komisi NUMERIC DEFAULT 5.00
)
LANGUAGE plpgsql
AS $$
DECLARE
    v_id_produk INT;
    v_status VARCHAR(30);
    v_id_bid INT;
    v_nominal NUMERIC(12,2);
    v_id_pemenang INT;
BEGIN
    SELECT id_produk, status_lelang
    INTO v_id_produk, v_status
    FROM kapten.lelang
    WHERE id_lelang = p_id_lelang
    FOR UPDATE;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Lelang ID % tidak ditemukan.', p_id_lelang;
    END IF;

    IF v_status <> 'berlangsung' THEN
        RAISE EXCEPTION 'Lelang hanya dapat ditutup saat berstatus berlangsung. Status sekarang: %.', v_status;
    END IF;

    IF EXISTS (SELECT 1 FROM kapten.pemenang_lelang WHERE id_lelang = p_id_lelang) THEN
        RAISE EXCEPTION 'Pemenang lelang ID % sudah ditetapkan.', p_id_lelang;
    END IF;

    SELECT b.id_bid, b.nominal
    INTO v_id_bid, v_nominal
    FROM kapten.bid b
    WHERE b.id_lelang = p_id_lelang
    ORDER BY b.nominal DESC, b.tgl_bid ASC, b.id_bid ASC
    LIMIT 1;

    IF NOT FOUND THEN
        UPDATE kapten.lelang
        SET status_lelang = 'dibatalkan',
            tgl_akhir = CASE WHEN CURRENT_TIMESTAMP > tgl_mulai
                             THEN LEAST(tgl_akhir, CURRENT_TIMESTAMP)
                             ELSE tgl_akhir END
        WHERE id_lelang = p_id_lelang;

        UPDATE kapten.produk_kopi
        SET status_produk = 'dibatalkan'
        WHERE id_produk = v_id_produk;
        RETURN;
    END IF;

    INSERT INTO kapten.pemenang_lelang (id_lelang, id_bid)
    VALUES (p_id_lelang, v_id_bid)
    RETURNING id_pemenang INTO v_id_pemenang;

    INSERT INTO kapten.transaksi (
        id_pemenang, total_bayar, persentase_komisi,
        biaya_komisi, total_diterima_petani, status_bayar
    ) VALUES (
        v_id_pemenang, v_nominal, p_persentase_komisi,
        0, 0, 'belum_bayar'
    );

    UPDATE kapten.lelang
    SET status_lelang = 'selesai',
        tgl_akhir = CASE WHEN CURRENT_TIMESTAMP > tgl_mulai
                         THEN LEAST(tgl_akhir, CURRENT_TIMESTAMP)
                         ELSE tgl_akhir END
    WHERE id_lelang = p_id_lelang;

    UPDATE kapten.produk_kopi
    SET status_produk = 'terjual'
    WHERE id_produk = v_id_produk;
END;
$$;

-- Konfirmasi pembayaran offline; hanya transaksi belum_bayar yang dapat diubah.
CREATE OR REPLACE PROCEDURE kapten.sp_konfirmasi_pembayaran(
    p_id_transaksi INT,
    p_status_bayar VARCHAR
)
LANGUAGE plpgsql
AS $$
DECLARE
    v_id_produk INT;
    v_status_lama VARCHAR(30);
    v_status_baru VARCHAR(30) := LOWER(TRIM(p_status_bayar));
BEGIN
    IF v_status_baru NOT IN ('lunas', 'dibatalkan') THEN
        RAISE EXCEPTION 'Status pembayaran harus lunas atau dibatalkan.';
    END IF;

    SELECT l.id_produk, t.status_bayar
    INTO v_id_produk, v_status_lama
    FROM kapten.transaksi t
    JOIN kapten.pemenang_lelang pl
        ON pl.id_pemenang = t.id_pemenang
    JOIN kapten.lelang l
        ON l.id_lelang = pl.id_lelang
    WHERE t.id_transaksi = p_id_transaksi
    FOR UPDATE OF t;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'Transaksi ID % tidak ditemukan.', p_id_transaksi;
    END IF;

    IF v_status_lama <> 'belum_bayar' THEN
        RAISE EXCEPTION
            'Transaksi sudah berstatus % dan tidak dapat diubah lagi.',
            v_status_lama;
    END IF;

    UPDATE kapten.transaksi
    SET status_bayar = v_status_baru
    WHERE id_transaksi = p_id_transaksi;

    UPDATE kapten.produk_kopi
    SET status_produk = CASE
        WHEN v_status_baru = 'lunas' THEN 'terjual'
        ELSE 'dibatalkan'
    END
    WHERE id_produk = v_id_produk;
END;
$$;


CREATE OR REPLACE PROCEDURE kapten.sp_ubah_status_akun(
    p_id_user INT,
    p_status BOOLEAN
)
LANGUAGE plpgsql
AS $$
BEGIN
    UPDATE kapten.users
    SET is_aktif = p_status
    WHERE id_user = p_id_user;

    IF NOT FOUND THEN
        RAISE EXCEPTION 'User ID % tidak ditemukan.', p_id_user;
    END IF;
END;
$$;

-- Aktifkan atau nonaktifkan role milik user.
CREATE OR REPLACE PROCEDURE kapten.sp_ubah_status_role(
    p_id_user INT,
    p_nama_role VARCHAR,
    p_status BOOLEAN
)
LANGUAGE plpgsql
AS $$
BEGIN
    UPDATE kapten.user_roles ur
    SET is_role_aktif = p_status
    FROM kapten.roles r
    WHERE ur.id_role = r.id_role
      AND ur.id_user = p_id_user
      AND LOWER(r.nama_role) = LOWER(TRIM(p_nama_role));

    IF NOT FOUND THEN
        RAISE EXCEPTION
            'Role % milik user ID % tidak ditemukan.',
            p_nama_role,
            p_id_user;
    END IF;
END;
$$;


-- ============================================================================
-- 04. VIEW: QUERY KOMPLEKS DISEMBUNYIKAN DARI WINFORMS
-- ============================================================================

-- Drop lebih dahulu agar tetap kompatibel bila versi view lama sudah terpasang.
DROP VIEW IF EXISTS kapten.vw_dashboard_produk_admin CASCADE;
DROP VIEW IF EXISTS kapten.vw_pemenang_lelang_detail CASCADE;
DROP VIEW IF EXISTS kapten.vw_produk_siap_lelang CASCADE;
DROP VIEW IF EXISTS kapten.vw_jenis_kopi CASCADE;
DROP VIEW IF EXISTS kapten.vw_except_pembeli_belum_bid CASCADE;
DROP VIEW IF EXISTS kapten.vw_intersect_petani_pembeli CASCADE;
DROP VIEW IF EXISTS kapten.vw_union_aktivitas_user CASCADE;
DROP VIEW IF EXISTS kapten.vw_subquery_bid_di_atas_rata CASCADE;
DROP VIEW IF EXISTS kapten.vw_subquery_produk_di_atas_rata CASCADE;
DROP VIEW IF EXISTS kapten.vw_grouping_sets_transaksi CASCADE;
DROP VIEW IF EXISTS kapten.vw_cube_produk CASCADE;
DROP VIEW IF EXISTS kapten.vw_rollup_produk CASCADE;
DROP VIEW IF EXISTS kapten.vw_groupby_performa_petani CASCADE;
DROP VIEW IF EXISTS kapten.vw_groupby_produk CASCADE;
DROP VIEW IF EXISTS kapten.vw_transaksi_detail CASCADE;
DROP VIEW IF EXISTS kapten.vw_lelang_detail CASCADE;
DROP VIEW IF EXISTS kapten.vw_bid_tertinggi CASCADE;
DROP VIEW IF EXISTS kapten.vw_produk_detail CASCADE;

-- view detail sautu produk + dari prdouk mana
CREATE OR REPLACE VIEW kapten.vw_produk_detail AS
SELECT
    p.id_produk,
    p.id_petani,
    petani.nama_lengkap AS nama_petani,
    p.id_jenis,
    jk.nama_jenis,
    p.nama_produk,
    p.berat_kg,
    p.harga_pengajuan,
    p.deskripsi,
    p.status_produk,
    i.id_inspeksi,
    i.id_inspektor,
    inspektor.nama_lengkap AS nama_inspektor,
    i.tgl_inspeksi,
    i.nilai,
    i.grade,
    i.harga_rekomendasi,
    i.catatan,
    i.status_inspeksi
FROM kapten.produk_kopi p
JOIN kapten.users petani ON petani.id_user = p.id_petani
JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
LEFT JOIN kapten.inspeksi i ON i.id_produk = p.id_produk
LEFT JOIN kapten.users inspektor ON inspektor.id_user = i.id_inspektor;

-- view lelang detail an
CREATE OR REPLACE VIEW kapten.vw_lelang_detail AS
SELECT
    l.id_lelang,
    l.id_produk,
    p.nama_produk,
    p.id_petani,
    petani.nama_lengkap AS nama_petani,
    jk.nama_jenis,
    p.berat_kg,
    l.bid_minimum,
    l.tgl_mulai,
    l.tgl_akhir,
    l.lokasi_lelang,
    l.status_lelang,
    COUNT(b.id_bid) AS jumlah_bid,
    MAX(b.nominal) AS bid_tertinggi
FROM kapten.lelang l
JOIN kapten.produk_kopi p ON p.id_produk = l.id_produk
JOIN kapten.users petani ON petani.id_user = p.id_petani
JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
LEFT JOIN kapten.bid b ON b.id_lelang = l.id_lelang
GROUP BY
    l.id_lelang, l.id_produk, p.nama_produk, p.id_petani,
    petani.nama_lengkap, jk.nama_jenis, p.berat_kg,
    l.bid_minimum, l.tgl_mulai, l.tgl_akhir,
    l.lokasi_lelang, l.status_lelang;

-- cek tertinggi suatu bid for winform
CREATE OR REPLACE VIEW kapten.vw_bid_tertinggi AS
SELECT id_lelang, id_bid, id_pembeli, nama_pembeli, nominal, tgl_bid
FROM (
    SELECT
        b.id_lelang,
        b.id_bid,
        b.id_pembeli,
        u.nama_lengkap AS nama_pembeli,
        b.nominal,
        b.tgl_bid,
        ROW_NUMBER() OVER (
            PARTITION BY b.id_lelang
            ORDER BY b.nominal DESC, b.tgl_bid ASC, b.id_bid ASC
        ) AS urutan
    FROM kapten.bid b
    JOIN kapten.users u ON u.id_user = b.id_pembeli
) x
WHERE urutan = 1;

-- cek detail transaksi
CREATE OR REPLACE VIEW kapten.vw_transaksi_detail AS
SELECT
    t.id_transaksi,
    t.tgl_transaksi,
    t.status_bayar,
    t.total_bayar,
    t.persentase_komisi,
    t.biaya_komisi,
    t.total_diterima_petani,
    l.id_lelang,
    p.id_produk,
    p.nama_produk,
    petani.id_user AS id_petani,
    petani.nama_lengkap AS nama_petani,
    pembeli.id_user AS id_pembeli,
    pembeli.nama_lengkap AS nama_pembeli,
    b.id_bid,
    b.nominal AS nominal_pemenang
FROM kapten.transaksi t
JOIN kapten.pemenang_lelang pl ON pl.id_pemenang = t.id_pemenang
JOIN kapten.lelang l ON l.id_lelang = pl.id_lelang
JOIN kapten.produk_kopi p ON p.id_produk = l.id_produk
JOIN kapten.users petani ON petani.id_user = p.id_petani
JOIN kapten.bid b ON b.id_bid = pl.id_bid
JOIN kapten.users pembeli ON pembeli.id_user = b.id_pembeli;

-- view untuk dashboard per role + statement
CREATE OR REPLACE FUNCTION kapten.fn_dashboard_ringkas(
    p_id_user INT,
    p_role VARCHAR
)
RETURNS TABLE (
    card1_title VARCHAR,
    card1_value BIGINT,
    card2_title VARCHAR,
    card2_value BIGINT,
    card3_title VARCHAR,
    card3_value BIGINT,
    card4_title VARCHAR,
    card4_value BIGINT
)
LANGUAGE plpgsql
STABLE
AS $$
DECLARE
    v_role VARCHAR(30) := LOWER(TRIM(p_role));
BEGIN
    IF v_role = 'admin' THEN
        RETURN QUERY
        SELECT
            'Total User'::VARCHAR,
            (SELECT COUNT(*) FROM kapten.users),

            'Produk Pending'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.produk_kopi
                WHERE status_produk = 'pending_inspeksi'
            ),

            'Lelang Berlangsung'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.lelang
                WHERE status_lelang = 'berlangsung'
            ),

            'Transaksi Belum Bayar'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.transaksi
                WHERE status_bayar = 'belum_bayar'
            );

    ELSIF v_role = 'petani' THEN
        RETURN QUERY
        SELECT
            'Total Produk'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.produk_kopi
                WHERE id_petani = p_id_user
            ),

            'Pending Inspeksi'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.produk_kopi
                WHERE id_petani = p_id_user
                  AND status_produk = 'pending_inspeksi'
            ),

            'Lolos QC'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.produk_kopi
                WHERE id_petani = p_id_user
                  AND status_produk = 'lolos_qc'
            ),

            'Produk Terjual'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.produk_kopi
                WHERE id_petani = p_id_user
                  AND status_produk = 'terjual'
            );

    ELSIF v_role = 'pembeli' THEN
        RETURN QUERY
        SELECT
            'Total Bid'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.bid
                WHERE id_pembeli = p_id_user
            ),

            'Menang Lelang'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.pemenang_lelang pl
                JOIN kapten.bid b
                    ON b.id_bid = pl.id_bid
                WHERE b.id_pembeli = p_id_user
            ),

            'Belum Bayar'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.transaksi t
                JOIN kapten.pemenang_lelang pl
                    ON pl.id_pemenang = t.id_pemenang
                JOIN kapten.bid b
                    ON b.id_bid = pl.id_bid
                WHERE b.id_pembeli = p_id_user
                  AND t.status_bayar = 'belum_bayar'
            ),

            'Transaksi Lunas'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.transaksi t
                JOIN kapten.pemenang_lelang pl
                    ON pl.id_pemenang = t.id_pemenang
                JOIN kapten.bid b
                    ON b.id_bid = pl.id_bid
                WHERE b.id_pembeli = p_id_user
                  AND t.status_bayar = 'lunas'
            );

    ELSIF v_role = 'inspektor' THEN
        RETURN QUERY
        SELECT
            'Total Inspeksi'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.inspeksi
                WHERE id_inspektor = p_id_user
            ),

            'Lolos QC'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.inspeksi
                WHERE id_inspektor = p_id_user
                  AND status_inspeksi = 'lolos_qc'
            ),

            'Ditolak QC'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.inspeksi
                WHERE id_inspektor = p_id_user
                  AND status_inspeksi = 'ditolak_qc'
            ),

            'Menunggu Inspeksi'::VARCHAR,
            (
                SELECT COUNT(*)
                FROM kapten.produk_kopi
                WHERE status_produk = 'pending_inspeksi'
            );

    ELSE
        RAISE EXCEPTION
            'Role dashboard tidak dikenali: %',
            p_role;
    END IF;
END;
$$;

-- view buat dashboard nampilin datagrid
CREATE OR REPLACE VIEW kapten.vw_dashboard_produk_admin AS
SELECT
    id_produk AS "ID Produk",
    nama_produk AS "Produk",
    nama_petani AS "Petani",
    nama_jenis AS "Jenis Kopi",
    berat_kg AS "Berat Kg",
    harga_pengajuan AS "Harga Pengajuan",
    status_produk AS "Status",
    COALESCE(grade, '-') AS "Grade"
FROM kapten.vw_produk_detail;

-- pemenang lelang
CREATE OR REPLACE VIEW kapten.vw_pemenang_lelang_detail AS
SELECT
    pl.id_pemenang,
    pl.id_lelang,
    pl.id_bid,
    p.id_produk,
    p.nama_produk,
    u_petani.id_user AS id_petani,
    u_petani.nama_lengkap AS nama_petani,
    u_pembeli.id_user AS id_pembeli,
    u_pembeli.nama_lengkap AS nama_pembeli,
    b.nominal AS harga_menang,
    pl.tgl_ditetapkan
FROM kapten.pemenang_lelang pl
JOIN kapten.bid b
    ON b.id_bid = pl.id_bid
JOIN kapten.lelang l
    ON l.id_lelang = pl.id_lelang
JOIN kapten.produk_kopi p
    ON p.id_produk = l.id_produk
JOIN kapten.users u_petani
    ON u_petani.id_user = p.id_petani
JOIN kapten.users u_pembeli
    ON u_pembeli.id_user = b.id_pembeli;

-- view jenis kopi
CREATE OR REPLACE VIEW kapten.vw_jenis_kopi AS
SELECT
    id_jenis,
    nama_jenis,
    deskripsi
FROM kapten.jenis_kopi;

-- cek produk siap lelang
CREATE OR REPLACE VIEW kapten.vw_produk_siap_lelang AS
SELECT
    p.id_produk,
    p.id_petani,
    p.id_jenis,
    p.nama_produk,
    p.berat_kg,
    p.harga_pengajuan,
    p.deskripsi,
    p.status_produk,
    i.nilai,
    i.grade,
    i.harga_rekomendasi,
    i.status_inspeksi
FROM kapten.produk_kopi p
JOIN kapten.inspeksi i
    ON i.id_produk = p.id_produk
WHERE p.status_produk = 'lolos_qc'
  AND i.status_inspeksi = 'lolos_qc'
  AND NOT EXISTS (
      SELECT 1
      FROM kapten.lelang l
      WHERE l.id_produk = p.id_produk
  );
	
-- ============================================================================
-- 05. GROUP BY
-- Cocok untuk menu Laporan di dashboard admin.
-- ============================================================================

CREATE OR REPLACE VIEW kapten.vw_groupby_produk AS
SELECT
    jk.nama_jenis,
    p.status_produk,
    COUNT(*) AS jumlah_produk,
    ROUND(SUM(p.berat_kg), 2) AS total_berat_kg,
    ROUND(AVG(p.harga_pengajuan), 2) AS rata_harga_pengajuan,
    ROUND(SUM(p.harga_pengajuan), 2) AS total_harga_pengajuan
FROM kapten.produk_kopi p
JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
GROUP BY jk.nama_jenis, p.status_produk;

CREATE OR REPLACE VIEW kapten.vw_groupby_performa_petani AS
SELECT
    u.id_user AS id_petani,
    u.nama_lengkap AS nama_petani,
    COUNT(DISTINCT p.id_produk) AS jumlah_produk,
    COUNT(DISTINCT CASE WHEN p.status_produk = 'terjual' THEN p.id_produk END) AS produk_terjual,
    COALESCE(SUM(CASE WHEN t.status_bayar = 'lunas' THEN t.total_diterima_petani ELSE 0 END), 0) AS pendapatan_bersih
FROM kapten.users u
JOIN kapten.produk_kopi p ON p.id_petani = u.id_user
LEFT JOIN kapten.lelang l ON l.id_produk = p.id_produk
LEFT JOIN kapten.pemenang_lelang pl ON pl.id_lelang = l.id_lelang
LEFT JOIN kapten.transaksi t ON t.id_pemenang = pl.id_pemenang
GROUP BY u.id_user, u.nama_lengkap;

-- ============================================================================
-- 06. ROLLUP, CUBE, GROUPING SETS
-- ============================================================================

CREATE OR REPLACE VIEW kapten.vw_rollup_produk AS
SELECT
    CASE WHEN GROUPING(jk.nama_jenis) = 1 THEN 'SEMUA JENIS'
         ELSE jk.nama_jenis END AS nama_jenis,
    CASE WHEN GROUPING(p.status_produk) = 1 THEN 'SEMUA STATUS'
         ELSE p.status_produk END AS status_produk,
    COUNT(*) AS jumlah_produk,
    ROUND(SUM(p.berat_kg), 2) AS total_berat_kg,
    GROUPING(jk.nama_jenis) AS is_total_jenis,
    GROUPING(p.status_produk) AS is_total_status
FROM kapten.produk_kopi p
JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
GROUP BY ROLLUP (jk.nama_jenis, p.status_produk);

CREATE OR REPLACE VIEW kapten.vw_cube_produk AS
SELECT
    CASE WHEN GROUPING(jk.nama_jenis) = 1 THEN 'SEMUA JENIS'
         ELSE jk.nama_jenis END AS nama_jenis,
    CASE WHEN GROUPING(p.status_produk) = 1 THEN 'SEMUA STATUS'
         ELSE p.status_produk END AS status_produk,
    COUNT(*) AS jumlah_produk,
    ROUND(SUM(p.berat_kg), 2) AS total_berat_kg,
    ROUND(AVG(p.harga_pengajuan), 2) AS rata_harga
FROM kapten.produk_kopi p
JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
GROUP BY CUBE (jk.nama_jenis, p.status_produk);

CREATE OR REPLACE VIEW kapten.vw_grouping_sets_transaksi AS
WITH data_transaksi AS (
    SELECT
        DATE_TRUNC('month', t.tgl_transaksi)::DATE AS periode,
        t.status_bayar,
        jk.nama_jenis,
        t.total_bayar,
        t.biaya_komisi,
        t.total_diterima_petani
    FROM kapten.transaksi t
    JOIN kapten.pemenang_lelang pl ON pl.id_pemenang = t.id_pemenang
    JOIN kapten.lelang l ON l.id_lelang = pl.id_lelang
    JOIN kapten.produk_kopi p ON p.id_produk = l.id_produk
    JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
)
SELECT
    periode,
    CASE WHEN GROUPING(nama_jenis) = 1 THEN 'SEMUA JENIS'
         ELSE nama_jenis END AS nama_jenis,
    CASE WHEN GROUPING(status_bayar) = 1 THEN 'SEMUA STATUS'
         ELSE status_bayar END AS status_bayar,
    COUNT(*) AS jumlah_transaksi,
    COALESCE(SUM(total_bayar), 0) AS total_bayar,
    COALESCE(SUM(biaya_komisi), 0) AS total_komisi,
    COALESCE(SUM(total_diterima_petani), 0) AS total_petani
FROM data_transaksi
GROUP BY GROUPING SETS (
    (periode, status_bayar),
    (nama_jenis, status_bayar),
    (status_bayar),
    ()
);

-- ============================================================================
-- 07. SUBQUERY
-- ============================================================================

-- Produk dengan harga di atas rata-rata jenis kopi yang sama.
CREATE OR REPLACE VIEW kapten.vw_subquery_produk_di_atas_rata AS
SELECT
    p.id_produk,
    p.nama_produk,
    jk.nama_jenis,
    p.harga_pengajuan,
    (
        SELECT ROUND(AVG(p2.harga_pengajuan), 2)
        FROM kapten.produk_kopi p2
        WHERE p2.id_jenis = p.id_jenis
    ) AS rata_harga_jenis
FROM kapten.produk_kopi p
JOIN kapten.jenis_kopi jk ON jk.id_jenis = p.id_jenis
WHERE p.harga_pengajuan > (
    SELECT AVG(p2.harga_pengajuan)
    FROM kapten.produk_kopi p2
    WHERE p2.id_jenis = p.id_jenis
);

-- Bid yang berada di atas rata-rata bid pada lelang yang sama.
CREATE OR REPLACE VIEW kapten.vw_subquery_bid_di_atas_rata AS
SELECT
    b.id_bid,
    b.id_lelang,
    u.nama_lengkap AS nama_pembeli,
    b.nominal,
    (
        SELECT ROUND(AVG(b2.nominal), 2)
        FROM kapten.bid b2
        WHERE b2.id_lelang = b.id_lelang
    ) AS rata_bid_lelang
FROM kapten.bid b
JOIN kapten.users u ON u.id_user = b.id_pembeli
WHERE b.nominal > (
    SELECT AVG(b2.nominal)
    FROM kapten.bid b2
    WHERE b2.id_lelang = b.id_lelang
);

-- ============================================================================
-- 08. TEORI HIMPUNAN: UNION, INTERSECT, EXCEPT
-- ============================================================================

-- UNION: seluruh aktivitas utama user dalam satu timeline.
CREATE OR REPLACE VIEW kapten.vw_union_aktivitas_user AS
SELECT
    p.id_petani AS id_user,
    'input_produk'::VARCHAR AS jenis_aktivitas,
    p.id_produk AS id_referensi,
    p.nama_produk::TEXT AS keterangan,
    NULL::TIMESTAMP AS waktu
FROM kapten.produk_kopi p
UNION
SELECT
    i.id_inspektor,
    'inspeksi'::VARCHAR,
    i.id_inspeksi,
    ('QC produk #' || i.id_produk)::TEXT,
    i.tgl_inspeksi::TIMESTAMP
FROM kapten.inspeksi i
UNION
SELECT
    b.id_pembeli,
    'bid'::VARCHAR,
    b.id_bid,
    ('Bid Rp' || b.nominal || ' pada lelang #' || b.id_lelang)::TEXT,
    b.tgl_bid
FROM kapten.bid b;

-- INTERSECT: user yang memiliki role petani sekaligus pembeli.
CREATE OR REPLACE VIEW kapten.vw_intersect_petani_pembeli AS
SELECT u.id_user, u.nama_lengkap, u.username
FROM kapten.users u
JOIN (
    SELECT ur.id_user
    FROM kapten.user_roles ur
    JOIN kapten.roles r ON r.id_role = ur.id_role
    WHERE LOWER(r.nama_role) = 'petani' AND ur.is_role_aktif = TRUE
    INTERSECT
    SELECT ur.id_user
    FROM kapten.user_roles ur
    JOIN kapten.roles r ON r.id_role = ur.id_role
    WHERE LOWER(r.nama_role) = 'pembeli' AND ur.is_role_aktif = TRUE
) x ON x.id_user = u.id_user;

-- EXCEPT: pembeli aktif yang belum pernah memasang bid.
CREATE OR REPLACE VIEW kapten.vw_except_pembeli_belum_bid AS
SELECT u.id_user, u.nama_lengkap, u.username
FROM kapten.users u
JOIN (
    SELECT ur.id_user
    FROM kapten.user_roles ur
    JOIN kapten.roles r ON r.id_role = ur.id_role
    WHERE LOWER(r.nama_role) = 'pembeli'
      AND ur.is_role_aktif = TRUE
    EXCEPT
    SELECT b.id_pembeli
    FROM kapten.bid b
) x ON x.id_user = u.id_user
WHERE u.is_aktif = TRUE;

-- ============================================================================
-- 09. TRANSACTION
-- Procedure PostgreSQL bersifat atomik: bila satu statement gagal, seluruh CALL
-- gagal. Untuk transaksi gabungan dari WinForms, gunakan BeginTransaction() lalu
-- jalankan beberapa CALL pada connection + transaction yang sama.
--
-- Contoh pengujian manual di pgAdmin:
--
-- BEGIN;
-- CALL kapten.sp_simpan_inspeksi(1, 6, 88, 1300000, 'Aroma baik');
-- CALL kapten.sp_buka_lelang(1, 'KAPTEN', 3);
-- COMMIT;
--
-- Bila salah satu CALL gagal:
-- ROLLBACK;
-- ============================================================================

-- ============================================================================
-- 10. CONTOH CALL DARI QUERY TOOL / NPGSQL
-- Jalankan hanya contoh yang ID datanya memang tersedia.
-- ============================================================================

-- SELECT kapten.fn_tentukan_grade(88);
-- SELECT * FROM kapten.fn_produk_petani(2);
-- SELECT * FROM kapten.fn_lelang_tersedia(4);
-- SELECT * FROM kapten.fn_riwayat_bid_pembeli(4);
--
-- CALL kapten.sp_tambah_produk(2, 1, 'Arabika Gunung', 20, 1200000, 'Panen baru');
-- CALL kapten.sp_simpan_inspeksi(1, 6, 88, 1300000, 'Layak lelang');
-- CALL kapten.sp_buka_lelang(1, 'Gedung KAPTEN', 3);
-- CALL kapten.sp_pasang_bid(1, 4, 1400000);
-- CALL kapten.sp_tutup_lelang(1, 5.00);
-- CALL kapten.sp_konfirmasi_pembayaran(1, 'lunas');
--
-- CALL kapten.sp_register_user(
--     'Petani Baru', 'petanibaru', 'password123', '081234567890', 'petani'
-- );
-- SELECT * FROM kapten.fn_authenticate_user('petanibaru', 'password123');
-- SELECT kapten.fn_no_telp_terpakai('081234567890');
-- CALL kapten.sp_update_profile(2, 'Pak Budi Baru', '082222222222');
-- CALL kapten.sp_update_password(2, 'passwordbaru123');
-- CALL kapten.sp_tambah_role_user(2, 'pembeli');
-- CALL kapten.sp_ubah_status_role(2, 'pembeli', FALSE);
-- CALL kapten.sp_ubah_status_akun(2, TRUE);
--
-- SELECT * FROM kapten.fn_dashboard_ringkas(1, 'admin');
-- SELECT * FROM kapten.vw_produk_detail;
-- SELECT * FROM kapten.vw_lelang_detail;
-- SELECT * FROM kapten.vw_transaksi_detail;
-- SELECT * FROM kapten.vw_pemenang_lelang_detail;
-- SELECT * FROM kapten.vw_jenis_kopi;
-- SELECT * FROM kapten.vw_produk_siap_lelang;
-- SELECT * FROM kapten.vw_groupby_produk;
-- SELECT * FROM kapten.vw_rollup_produk;
-- SELECT * FROM kapten.vw_cube_produk;
-- SELECT * FROM kapten.vw_grouping_sets_transaksi;
-- SELECT * FROM kapten.vw_subquery_produk_di_atas_rata;
-- SELECT * FROM kapten.vw_union_aktivitas_user;
-- SELECT * FROM kapten.vw_intersect_petani_pembeli;
-- SELECT * FROM kapten.vw_except_pembeli_belum_bid;