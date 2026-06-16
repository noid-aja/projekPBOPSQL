using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public static class UserContext
    {
        public static User? CurrentUser
        {
            get;
            private set;
        }

        // =====================================================
        // SESSION USER
        // =====================================================

        public static void Login(User user)
        {
            CurrentUser = user;
        }

        public static void SetUser(User user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }

        // =====================================================
        // PENGECEKAN ROLE
        // =====================================================

        public static bool IsAdmin()
        {
            return CurrentUser?.IsInRole("admin") == true;
        }

        public static bool IsPetani()
        {
            return CurrentUser?.IsInRole("petani") == true;
        }

        public static bool IsPembeli()
        {
            return CurrentUser?.IsInRole("pembeli") == true;
        }

        public static bool IsInspektor()
        {
            return CurrentUser?.IsInRole("inspektor") == true;
        }

        public static bool HasAnyRole(
            params string[] roles)
        {
            return roles.Any(
                role =>
                    CurrentUser?.IsInRole(role) == true);
        }

        public static void RequireRole(string role)
        {
            if (CurrentUser == null)
            {
                throw new UnauthorizedAccessException(
                    "Belum login.");
            }

            if (!CurrentUser.IsInRole(role))
            {
                throw new UnauthorizedAccessException(
                    $"Akses ditolak. Role '{role}' dibutuhkan.");
            }
        }

        public static List<string> GetRoleNames()
        {
            return CurrentUser?.Roles
                .Select(role => role.NamaRole)
                .ToList()
                ?? new List<string>();
        }

        // =====================================================
        // REGISTER
        // =====================================================

        public static void Register(
            User user,
            string namaRole)
        {
            string role =
                namaRole.Trim().ToLowerInvariant();

            if (role != "petani"
                && role != "pembeli"
                && role != "inspektor"
                && role != "keduanya")
            {
                throw new ArgumentException(
                    "Role hanya boleh petani, pembeli, " +
                    "inspektor, atau keduanya.");
            }

            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_register_user(
                    @namaLengkap,
                    @username,
                    @password,
                    @noTelp,
                    @namaRole
                );",

                new NpgsqlParameter(
                    "namaLengkap",
                    NpgsqlDbType.Varchar)
                {
                    Value = user.NamaLengkap.Trim()
                },

                new NpgsqlParameter(
                    "username",
                    NpgsqlDbType.Varchar)
                {
                    Value = user.Username.Trim()
                },

                new NpgsqlParameter(
                    "password",
                    NpgsqlDbType.Varchar)
                {
                    Value = user.Password
                },

                new NpgsqlParameter(
                    "noTelp",
                    NpgsqlDbType.Varchar)
                {
                    Value = string.IsNullOrWhiteSpace(
                        user.NoTelp)
                        ? DBNull.Value
                        : user.NoTelp.Trim()
                },

                new NpgsqlParameter(
                    "namaRole",
                    NpgsqlDbType.Varchar)
                {
                    Value = role
                });
        }

        // =====================================================
        // LOGIN / AUTHENTICATE
        // =====================================================

        public static User? Authenticate(
            string username,
            string password)
        {
            DataTable table = DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.fn_authenticate_user(
                      @username,
                      @password
                  );",

                new NpgsqlParameter(
                    "username",
                    NpgsqlDbType.Varchar)
                {
                    Value = username.Trim()
                },

                new NpgsqlParameter(
                    "password",
                    NpgsqlDbType.Varchar)
                {
                    Value = password
                });

            if (table.Rows.Count == 0)
                return null;

            DataRow firstRow = table.Rows[0];

            var user = new User
            {
                IdUser = Convert.ToInt32(
                    firstRow["id_user"]),

                NamaLengkap = Convert.ToString(
                    firstRow["nama_lengkap"])
                    ?? string.Empty,

                Username = Convert.ToString(
                    firstRow["username"])
                    ?? string.Empty,

                NoTelp =
                    firstRow["no_telp"] == DBNull.Value
                        ? null
                        : Convert.ToString(
                            firstRow["no_telp"]),

                IsAktif = Convert.ToBoolean(
                    firstRow["is_aktif"]),

                Roles = new List<Userrole>()
            };

            foreach (DataRow row in table.Rows)
            {
                int idRole =
                    Convert.ToInt32(row["id_role"]);

                string namaRole =
                    Convert.ToString(row["nama_role"])
                    ?? string.Empty;

                user.Roles.Add(
                    new Userrole(
                        user.IdUser,
                        idRole,
                        namaRole));
            }

            return user;
        }

        public static bool VerifyPassword(
            int idUser,
            string password)
        {
            DataTable table = DbExecutor.QueryTable(
                @"SELECT kapten.fn_verifikasi_password(
                      @idUser,
                      @password
                  ) AS cocok;",

                new NpgsqlParameter(
                    "idUser",
                    NpgsqlDbType.Integer)
                {
                    Value = idUser
                },

                new NpgsqlParameter(
                    "password",
                    NpgsqlDbType.Varchar)
                {
                    Value = password
                });

            return table.Rows.Count > 0
                && Convert.ToBoolean(table.Rows[0]["cocok"]);
        }

        // =====================================================
        // CEK NOMOR TELEPON
        // =====================================================

        public static bool IsNoTelpTaken(
            string noTelp)
        {
            DataTable table = DbExecutor.QueryTable(
                @"SELECT
                      kapten.fn_no_telp_terpakai(
                          @noTelp
                      ) AS terpakai;",

                new NpgsqlParameter(
                    "noTelp",
                    NpgsqlDbType.Varchar)
                {
                    Value = noTelp.Trim()
                });

            if (table.Rows.Count == 0)
                return false;

            return Convert.ToBoolean(
                table.Rows[0]["terpakai"]);
        }

        // =====================================================
        // UPDATE PROFIL
        // =====================================================

        public static bool UpdateProfile(User user)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_update_profile(
                    @idUser,
                    @namaLengkap,
                    @noTelp
                );",

                new NpgsqlParameter(
                    "idUser",
                    NpgsqlDbType.Integer)
                {
                    Value = user.IdUser
                },

                new NpgsqlParameter(
                    "namaLengkap",
                    NpgsqlDbType.Varchar)
                {
                    Value = user.NamaLengkap.Trim()
                },

                new NpgsqlParameter(
                    "noTelp",
                    NpgsqlDbType.Varchar)
                {
                    Value = string.IsNullOrWhiteSpace(
                        user.NoTelp)
                        ? DBNull.Value
                        : user.NoTelp.Trim()
                });

            return true;
        }

        // =====================================================
        // UPDATE PASSWORD
        // =====================================================

        public static bool UpdatePassword(
            int idUser,
            string newPassword)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_update_password(
                    @idUser,
                    @passwordBaru
                );",

                new NpgsqlParameter(
                    "idUser",
                    NpgsqlDbType.Integer)
                {
                    Value = idUser
                },

                new NpgsqlParameter(
                    "passwordBaru",
                    NpgsqlDbType.Varchar)
                {
                    Value = newPassword
                });

            return true;
        }

        // =====================================================
        // TAMBAH / AKTIFKAN ROLE
        // =====================================================

        public static bool AddRole(
            int idUser,
            string role)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_tambah_role_user(
                    @idUser,
                    @role
                );",

                new NpgsqlParameter(
                    "idUser",
                    NpgsqlDbType.Integer)
                {
                    Value = idUser
                },

                new NpgsqlParameter(
                    "role",
                    NpgsqlDbType.Varchar)
                {
                    Value = role.Trim()
                        .ToLowerInvariant()
                });

            return true;
        }

        // =====================================================
        // NONAKTIFKAN ROLE
        // =====================================================

        public static bool RemoveRole(
            int idUser,
            string role)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_ubah_status_role(
                    @idUser,
                    @role,
                    @status
                );",

                new NpgsqlParameter(
                    "idUser",
                    NpgsqlDbType.Integer)
                {
                    Value = idUser
                },

                new NpgsqlParameter(
                    "role",
                    NpgsqlDbType.Varchar)
                {
                    Value = role.Trim()
                        .ToLowerInvariant()
                },

                new NpgsqlParameter(
                    "status",
                    NpgsqlDbType.Boolean)
                {
                    Value = false
                });

            return true;
        }

        public static bool AktifkanRole(
            int idUser,
            string role)
        {
            return AddRole(idUser, role);
        }

        // =====================================================
        // SOFT DELETE / NONAKTIFKAN AKUN
        // =====================================================

        public static bool SoftDeleteUser(int idUser)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_ubah_status_akun(
                    @idUser,
                    @status
                );",

                new NpgsqlParameter(
                    "idUser",
                    NpgsqlDbType.Integer)
                {
                    Value = idUser
                },

                new NpgsqlParameter(
                    "status",
                    NpgsqlDbType.Boolean)
                {
                    Value = false
                });

            return true;
        }

        public static bool AktifkanUser(int idUser)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_ubah_status_akun(
                    @idUser,
                    @status
                );",

                new NpgsqlParameter(
                    "idUser",
                    NpgsqlDbType.Integer)
                {
                    Value = idUser
                },

                new NpgsqlParameter(
                    "status",
                    NpgsqlDbType.Boolean)
                {
                    Value = true
                });

            return true;
        }
    }
}