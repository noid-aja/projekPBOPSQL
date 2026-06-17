-- Hapus schema lama beserta seluruh isinya
DROP SCHEMA IF EXISTS kapten CASCADE;

-- Buat schema baru
CREATE SCHEMA kapten;

-- =========================================================
-- TABLE: users
-- =========================================================
CREATE TABLE kapten.users (
    id_user SERIAL PRIMARY KEY,
    nama_lengkap VARCHAR(100) NOT NULL,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    no_telp VARCHAR(20) NOT NULL,
    is_aktif BOOLEAN NOT NULL DEFAULT TRUE
);

-- =========================================================
-- TABLE: roles
-- =========================================================
CREATE TABLE kapten.roles (
    id_role SERIAL PRIMARY KEY,
    nama_role VARCHAR(50) NOT NULL UNIQUE
);

-- =========================================================
-- TABLE: user_roles
-- =========================================================
CREATE TABLE kapten.user_roles (
    id_user INT NOT NULL,
    id_role INT NOT NULL,
    is_role_aktif BOOLEAN NOT NULL DEFAULT TRUE,

    PRIMARY KEY (id_user, id_role),

    CONSTRAINT fk_user_roles_user
        FOREIGN KEY (id_user)
        REFERENCES kapten.users(id_user)
        ON DELETE CASCADE,

    CONSTRAINT fk_user_roles_role
        FOREIGN KEY (id_role)
        REFERENCES kapten.roles(id_role)
        ON DELETE CASCADE
);


-- =========================================================
-- TABLE: jenis_kopi
-- =========================================================
CREATE TABLE kapten.jenis_kopi (
    id_jenis SERIAL PRIMARY KEY,
    nama_jenis VARCHAR(50) NOT NULL UNIQUE,
    deskripsi TEXT
);

-- =========================================================
-- TABLE: produk_kopi
-- =========================================================
CREATE TABLE kapten.produk_kopi (
    id_produk SERIAL PRIMARY KEY,
    id_petani INT NOT NULL,
    id_jenis INT NOT NULL,

    nama_produk VARCHAR(100) NOT NULL,
    berat_kg NUMERIC(10,2) NOT NULL,
    harga_pengajuan NUMERIC(12,2) NOT NULL,
    deskripsi TEXT,
    status_produk VARCHAR(30) DEFAULT 'pending_inspeksi',

    CONSTRAINT fk_produk_petani
        FOREIGN KEY (id_petani)
        REFERENCES kapten.users(id_user),

    CONSTRAINT fk_produk_jenis
        FOREIGN KEY (id_jenis)
        REFERENCES kapten.jenis_kopi(id_jenis),

    CONSTRAINT chk_produk_berat
        CHECK (berat_kg > 0),

    CONSTRAINT chk_produk_harga
        CHECK (harga_pengajuan >= 0),

    CONSTRAINT chk_status_produk
        CHECK (status_produk IN (
            'pending_inspeksi',
            'lolos_qc',
            'ditolak_qc',
            'dijadwalkan_lelang',
            'berlangsung',
            'terjual',
            'dibatalkan'
        ))
);

-- =========================================================
-- TABLE: inspeksi
-- =========================================================
CREATE TABLE kapten.inspeksi (
    id_inspeksi SERIAL PRIMARY KEY,
    id_produk INT NOT NULL UNIQUE,
    id_inspektor INT NOT NULL,

    tgl_inspeksi DATE DEFAULT CURRENT_DATE,
    nilai INT NOT NULL,
    grade VARCHAR(10) NOT NULL,
    harga_rekomendasi NUMERIC(12,2) NOT NULL,
    catatan TEXT,
    status_inspeksi VARCHAR(30) NOT NULL,

    CONSTRAINT fk_inspeksi_produk
        FOREIGN KEY (id_produk)
        REFERENCES kapten.produk_kopi(id_produk)
        ON DELETE CASCADE,

    CONSTRAINT fk_inspeksi_inspektor
        FOREIGN KEY (id_inspektor)
        REFERENCES kapten.users(id_user),

    CONSTRAINT chk_nilai_inspeksi
        CHECK (nilai BETWEEN 0 AND 100),

    CONSTRAINT chk_grade_inspeksi
        CHECK (grade IN ('A+', 'A', 'B', 'C', 'D')),

    CONSTRAINT chk_status_inspeksi
        CHECK (status_inspeksi IN (
            'lolos_qc',
            'ditolak_qc'
        )),

    CONSTRAINT chk_harga_rekomendasi
        CHECK (harga_rekomendasi >= 0)
);

-- =========================================================
-- TABLE: lelang
-- =========================================================
CREATE TABLE kapten.lelang (
    id_lelang SERIAL PRIMARY KEY,
    id_produk INT NOT NULL UNIQUE,

    bid_minimum NUMERIC(12,2) NOT NULL,
    tgl_mulai TIMESTAMP NOT NULL,
    tgl_akhir TIMESTAMP NOT NULL,
    lokasi_lelang VARCHAR(150) NOT NULL,
    status_lelang VARCHAR(30) DEFAULT 'dijadwalkan',

    CONSTRAINT fk_lelang_produk
        FOREIGN KEY (id_produk)
        REFERENCES kapten.produk_kopi(id_produk)
        ON DELETE CASCADE,

    CONSTRAINT chk_bid_minimum
        CHECK (bid_minimum >= 0),

    CONSTRAINT chk_tanggal_lelang
        CHECK (tgl_akhir > tgl_mulai),

    CONSTRAINT chk_status_lelang
        CHECK (status_lelang IN (
            'dijadwalkan',
            'berlangsung',
            'selesai',
            'dibatalkan'
        ))
);

-- =========================================================
-- TABLE: bid
-- =========================================================
CREATE TABLE kapten.bid (
    id_bid SERIAL PRIMARY KEY,
    id_lelang INT NOT NULL,
    id_pembeli INT NOT NULL,

    nominal NUMERIC(12,2) NOT NULL,
    tgl_bid TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_bid_lelang
        FOREIGN KEY (id_lelang)
        REFERENCES kapten.lelang(id_lelang)
        ON DELETE CASCADE,

    CONSTRAINT fk_bid_pembeli
        FOREIGN KEY (id_pembeli)
        REFERENCES kapten.users(id_user),

    CONSTRAINT chk_nominal_bid
        CHECK (nominal > 0)
);

-- =========================================================
-- TABLE: pemenang_lelang
-- =========================================================
CREATE TABLE kapten.pemenang_lelang (
    id_pemenang SERIAL PRIMARY KEY,
    id_lelang INT NOT NULL UNIQUE,
    id_bid INT NOT NULL UNIQUE,

    tgl_ditetapkan TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_pemenang_lelang
        FOREIGN KEY (id_lelang)
        REFERENCES kapten.lelang(id_lelang)
        ON DELETE CASCADE,

    CONSTRAINT fk_pemenang_bid
        FOREIGN KEY (id_bid)
        REFERENCES kapten.bid(id_bid)
);

-- =========================================================
-- TABLE: transaksi
-- =========================================================
CREATE TABLE kapten.transaksi (
    id_transaksi SERIAL PRIMARY KEY,
    id_pemenang INT NOT NULL UNIQUE,

    tgl_transaksi TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    total_bayar NUMERIC(12,2) NOT NULL,
    persentase_komisi NUMERIC(5,2) DEFAULT 5.00,
    biaya_komisi NUMERIC(12,2) NOT NULL,
    total_diterima_petani NUMERIC(12,2) NOT NULL,
    status_bayar VARCHAR(30) DEFAULT 'belum_bayar',
    metode_pembayaran VARCHAR(50) DEFAULT 'Transfer',

    CONSTRAINT fk_transaksi_pemenang
        FOREIGN KEY (id_pemenang)
        REFERENCES kapten.pemenang_lelang(id_pemenang)
        ON DELETE CASCADE,

    CONSTRAINT chk_total_bayar
        CHECK (total_bayar >= 0),

    CONSTRAINT chk_persentase_komisi
        CHECK (persentase_komisi >= 0 AND persentase_komisi <= 100),

    CONSTRAINT chk_biaya_komisi
        CHECK (biaya_komisi >= 0),

    CONSTRAINT chk_total_diterima_petani
        CHECK (total_diterima_petani >= 0),

    CONSTRAINT chk_status_bayar
        CHECK (status_bayar IN (
            'belum_bayar',
            'menunggu_konfirmasi',
            'lunas',
            'dibatalkan'
        ))
);

-- =========================================================
-- SEED DATA LENGKAP
-- Jalankan setelah seluruh tabel berhasil dibuat.
-- Jika sebelumnya sudah ada data sampel, TRUNCATE ini akan
-- membersihkan seluruh data dan mereset SERIAL.
-- =========================================================
TRUNCATE TABLE
    kapten.transaksi,
    kapten.pemenang_lelang,
    kapten.bid,
    kapten.lelang,
    kapten.inspeksi,
    kapten.produk_kopi,
    kapten.jenis_kopi,
    kapten.user_roles,
    kapten.roles,
    kapten.users
RESTART IDENTITY CASCADE;

-- =========================================================
-- ROLES
-- =========================================================
INSERT INTO kapten.roles (id_role, nama_role) VALUES
(1, 'admin'),
(2, 'petani'),
(3, 'pembeli'),
(4, 'inspektor');

-- =========================================================
-- USERS
-- =========================================================
INSERT INTO kapten.users
(id_user, nama_lengkap, username, password, no_telp, is_aktif)
VALUES
(1, 'Admin Kapten',       'admin',   'admin123',  '081111111111', TRUE),
(2, 'Pak Budi Santoso',   'budi',    'budi123',   '082222222222', TRUE),
(3, 'Bu Sari Lestari',    'sari',    'sari123',   '083333333333', TRUE),
(4, 'Pak Joko Wijaya',    'joko',    'joko123',   '084444444444', TRUE),
(5, 'CV Kopi Makmur',     'makmur',  'makmur123', '085555555555', TRUE),
(6, 'Rina Quality Control','rinaqc',  'rina123',   '086666666666', TRUE),
(7, 'Doni Pembeli',       'doni',    'doni123',   '087777777777', TRUE),
(8, 'Tono Nonaktif',      'tono',    'tono123',   '088888888888', FALSE);

-- =========================================================
-- USER ROLES
-- Pak Budi memiliki dua role sebagai contoh multi-role.
-- Role pembeli milik Tono dinonaktifkan.
-- =========================================================
INSERT INTO kapten.user_roles
(id_user, id_role, is_role_aktif)
VALUES
(1, 1, TRUE),
(2, 2, TRUE),
(2, 3, TRUE),
(3, 2, TRUE),
(4, 3, TRUE),
(5, 3, TRUE),
(6, 4, TRUE),
(7, 3, TRUE),
(8, 3, FALSE);

-- =========================================================
-- JENIS KOPI
-- =========================================================
INSERT INTO kapten.jenis_kopi
(id_jenis, nama_jenis, deskripsi)
VALUES
(1, 'Arabika', 'Kopi beraroma kompleks dengan tingkat keasaman relatif tinggi.'),
(2, 'Robusta',  'Kopi bercita rasa kuat dengan kandungan kafein lebih tinggi.'),
(3, 'Liberika', 'Kopi dengan aroma khas buah dan ukuran biji relatif besar.');

-- =========================================================
-- PRODUK KOPI
--
-- Produk 3 = sudah lolos QC tetapi BELUM DIJADWALKAN.
-- Produk tersebut sengaja tidak memiliki baris pada tabel lelang.
-- =========================================================
INSERT INTO kapten.produk_kopi
(id_produk, id_petani, id_jenis, nama_produk, berat_kg,
 harga_pengajuan, deskripsi, status_produk)
VALUES
(1, 2, 1, 'Arabika Gayo Batch A',       25.00, 1200000,
 'Produk baru dan masih menunggu pemeriksaan QC.',
 'pending_inspeksi'),

(2, 2, 2, 'Robusta Lampung Batch B',    40.00, 1600000,
 'Produk ditolak karena kadar air terlalu tinggi.',
 'ditolak_qc'),

(3, 3, 1, 'Arabika Kintamani Batch C',  30.00, 1500000,
 'Sudah lolos QC, tetapi belum dibuatkan jadwal lelang.',
 'lolos_qc'),

(4, 3, 3, 'Liberika Riau Batch D',       20.00,  950000,
 'Sudah lolos QC dan telah dijadwalkan untuk lelang.',
 'dijadwalkan_lelang'),

(5, 2, 1, 'Arabika Ijen Batch E',        35.00, 1850000,
 'Lelang produk sedang berlangsung.',
 'berlangsung'),

(6, 3, 2, 'Robusta Temanggung Batch F', 50.00, 2250000,
 'Lelang selesai, memiliki pemenang, dan pembayaran lunas.',
 'terjual'),

(7, 2, 3, 'Liberika Jambi Batch G',      22.00, 1050000,
 'Lelang dibatalkan oleh pengelola.',
 'dibatalkan'),

(8, 3, 1, 'Arabika Toraja Batch H',      28.00, 1750000,
 'Lelang selesai dan sudah memiliki pemenang, tetapi belum dibayar.',
 'terjual'),

(9, 2, 2, 'Robusta Dampit Batch I',      45.00, 1950000,
 'Lelang telah berakhir tanpa penawar dan tidak memiliki pemenang.',
 'dibatalkan');

-- =========================================================
-- INSPEKSI
-- Produk 1 tidak memiliki inspeksi karena masih pending.
-- =========================================================
INSERT INTO kapten.inspeksi
(id_inspeksi, id_produk, id_inspektor, tgl_inspeksi,
 nilai, grade, harga_rekomendasi, catatan, status_inspeksi)
VALUES
(1, 2, 6, '2026-06-02', 55, 'D', 1400000,
 'Kadar air terlalu tinggi dan banyak biji cacat.',
 'ditolak_qc'),

(2, 3, 6, '2026-06-03', 88, 'A', 1550000,
 'Aroma baik, kadar air sesuai, dan biji relatif seragam.',
 'lolos_qc'),

(3, 4, 6, '2026-06-04', 82, 'B', 1000000,
 'Kualitas baik dengan sedikit variasi ukuran biji.',
 'lolos_qc'),

(4, 5, 6, '2026-06-05', 91, 'A', 1900000,
 'Kualitas sangat baik dan layak masuk lelang.',
 'lolos_qc'),

(5, 6, 6, '2026-06-01', 94, 'A', 2300000,
 'Kualitas premium dengan aroma dan tingkat kekeringan sangat baik.',
 'lolos_qc'),

(6, 7, 6, '2026-06-06', 79, 'B', 1100000,
 'Produk layak lelang, tetapi jadwal kemudian dibatalkan.',
 'lolos_qc'),

(7, 8, 6, '2026-06-07', 89, 'A', 1800000,
 'Aroma kuat, tingkat kematangan merata, dan defect rendah.',
 'lolos_qc'),

(8, 9, 6, '2026-06-08', 84, 'B', 2000000,
 'Produk layak lelang, tetapi tidak memperoleh penawar.',
 'lolos_qc');

-- =========================================================
-- LELANG
--
-- Tidak ada record untuk produk 3 karena statusnya
-- "lolos_qc tetapi belum dijadwalkan".
-- =========================================================
INSERT INTO kapten.lelang
(id_lelang, id_produk, bid_minimum, tgl_mulai, tgl_akhir,
 lokasi_lelang, status_lelang)
VALUES
(1, 4, 1000000, '2026-06-20 09:00:00', '2026-06-21 16:00:00',
 'Gudang Lelang Kapten - Jember', 'dijadwalkan'),

(2, 5, 1900000, '2026-06-15 08:00:00', '2026-06-16 16:00:00',
 'Aula Kopi Nusantara - Jember', 'berlangsung'),

(3, 6, 2300000, '2026-06-05 09:00:00', '2026-06-06 16:00:00',
 'Gudang Lelang Kapten - Jember', 'selesai'),

(4, 7, 1100000, '2026-06-12 09:00:00', '2026-06-13 16:00:00',
 'Balai Desa Sumber Kopi', 'dibatalkan'),

(5, 8, 1800000, '2026-06-08 09:00:00', '2026-06-09 16:00:00',
 'Aula Kopi Nusantara - Jember', 'selesai'),

(6, 9, 2000000, '2026-06-10 09:00:00', '2026-06-11 16:00:00',
 'Gudang Lelang Kapten - Jember', 'selesai');

-- =========================================================
-- BID
-- Lelang 1 belum dimulai.
-- Lelang 4 dibatalkan.
-- Lelang 6 selesai tanpa penawar.
-- =========================================================
INSERT INTO kapten.bid
(id_bid, id_lelang, id_pembeli, nominal, tgl_bid)
VALUES
-- Lelang 2 sedang berlangsung
(1, 2, 4, 1950000, '2026-06-15 09:15:00'),
(2, 2, 5, 2050000, '2026-06-15 10:30:00'),
(3, 2, 7, 2150000, '2026-06-15 11:45:00'),

-- Lelang 3 sudah selesai
(4, 3, 4, 2350000, '2026-06-05 10:00:00'),
(5, 3, 5, 2500000, '2026-06-05 13:20:00'),
(6, 3, 7, 2650000, '2026-06-06 14:40:00'),

-- Lelang 5 sudah selesai
(7, 5, 4, 1850000, '2026-06-08 11:00:00'),
(8, 5, 5, 2100000, '2026-06-09 14:30:00');

-- =========================================================
-- PEMENANG LELANG
-- Hanya lelang selesai yang memiliki penawar dan pemenang.
-- Lelang 6 tidak memiliki pemenang karena tidak ada bid.
-- =========================================================
INSERT INTO kapten.pemenang_lelang
(id_pemenang, id_lelang, id_bid, tgl_ditetapkan)
VALUES
(1, 3, 6, '2026-06-06 17:00:00'),
(2, 5, 8, '2026-06-09 17:00:00');

-- =========================================================
-- TRANSAKSI
-- Komisi 5%.
-- =========================================================
INSERT INTO kapten.transaksi
(id_transaksi, id_pemenang, tgl_transaksi, total_bayar,
 persentase_komisi, biaya_komisi, total_diterima_petani,
 status_bayar)
VALUES
(1, 1, '2026-06-06 17:30:00',
 2650000, 5.00, 132500, 2517500, 'lunas'),

(2, 2, '2026-06-09 17:30:00',
 2100000, 5.00, 105000, 1995000, 'belum_bayar');

-- =========================================================
-- Sinkronkan sequence karena seed memakai ID manual.
-- Agar INSERT berikutnya tidak bentrok dengan primary key.
-- =========================================================
SELECT setval(pg_get_serial_sequence('kapten.users', 'id_user'),
              (SELECT MAX(id_user) FROM kapten.users), TRUE);

SELECT setval(pg_get_serial_sequence('kapten.roles', 'id_role'),
              (SELECT MAX(id_role) FROM kapten.roles), TRUE);

SELECT setval(pg_get_serial_sequence('kapten.jenis_kopi', 'id_jenis'),
              (SELECT MAX(id_jenis) FROM kapten.jenis_kopi), TRUE);

SELECT setval(pg_get_serial_sequence('kapten.produk_kopi', 'id_produk'),
              (SELECT MAX(id_produk) FROM kapten.produk_kopi), TRUE);

SELECT setval(pg_get_serial_sequence('kapten.inspeksi', 'id_inspeksi'),
              (SELECT MAX(id_inspeksi) FROM kapten.inspeksi), TRUE);

SELECT setval(pg_get_serial_sequence('kapten.lelang', 'id_lelang'),
              (SELECT MAX(id_lelang) FROM kapten.lelang), TRUE);

SELECT setval(pg_get_serial_sequence('kapten.bid', 'id_bid'),
              (SELECT MAX(id_bid) FROM kapten.bid), TRUE);

SELECT setval(pg_get_serial_sequence('kapten.pemenang_lelang', 'id_pemenang'),
              (SELECT MAX(id_pemenang) FROM kapten.pemenang_lelang), TRUE);

SELECT setval(pg_get_serial_sequence('kapten.transaksi', 'id_transaksi'),
              (SELECT MAX(id_transaksi) FROM kapten.transaksi), TRUE);

-- =========================================================
-- CEK SEMUA DATA
-- =========================================================
SELECT * FROM kapten.users ORDER BY id_user;
SELECT * FROM kapten.roles ORDER BY id_role;
SELECT * FROM kapten.user_roles ORDER BY id_user, id_role;
SELECT * FROM kapten.jenis_kopi ORDER BY id_jenis;
SELECT * FROM kapten.produk_kopi ORDER BY id_produk;
SELECT * FROM kapten.inspeksi ORDER BY id_inspeksi;
SELECT * FROM kapten.lelang ORDER BY id_lelang;
SELECT * FROM kapten.bid ORDER BY id_bid;
SELECT * FROM kapten.pemenang_lelang ORDER BY id_pemenang;
SELECT * FROM kapten.transaksi ORDER BY id_transaksi;

-- =========================================================
-- CEK RINGKAS ALUR PRODUK SAMPAI TRANSAKSI
-- =========================================================
SELECT
    pk.id_produk,
    pk.nama_produk,
    pk.status_produk,
    i.status_inspeksi,
    l.id_lelang,
    l.status_lelang,
    COUNT(b.id_bid) AS jumlah_bid,
    MAX(b.nominal) AS bid_tertinggi,
    pl.id_pemenang,
    t.status_bayar
FROM kapten.produk_kopi pk
LEFT JOIN kapten.inspeksi i
       ON i.id_produk = pk.id_produk
LEFT JOIN kapten.lelang l
       ON l.id_produk = pk.id_produk
LEFT JOIN kapten.bid b
       ON b.id_lelang = l.id_lelang
LEFT JOIN kapten.pemenang_lelang pl
       ON pl.id_lelang = l.id_lelang
LEFT JOIN kapten.transaksi t
       ON t.id_pemenang = pl.id_pemenang
GROUP BY
    pk.id_produk,
    pk.nama_produk,
    pk.status_produk,
    i.status_inspeksi,
    l.id_lelang,
    l.status_lelang,
    pl.id_pemenang,
    t.status_bayar
ORDER BY pk.id_produk;
