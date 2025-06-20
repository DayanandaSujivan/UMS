using System;
using System.Data.SQLite;
using UMS.Data;
using UMS.Model;

namespace UMS.Controller
{
    public static class LoginController
    {
        public static AdminHandle GetAdminApprovalByNIC(int nic)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM pre_register WHERE NIC = @NIC AND Status = 0";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NIC", nic);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AdminHandle
                            {
                                NIC = Convert.ToInt32(reader["NIC"]),
                                FullName = reader["FullName"].ToString(),
                                phone = Convert.ToInt32(reader["Phone"]),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                DOB = reader["DOB"].ToString(),
                                Role = reader["Role"].ToString(),
                                Status = "0"
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public static bool RegisterUser(AdminHandle handle, string username, string password, byte[] profilePic)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Insert user account
                    string userInsertQuery = @"
                        INSERT INTO Users (Username, Password, Role) 
                        VALUES (@Username, @Password, @Role);
                        SELECT last_insert_rowid();";

                    int userId;
                    using (var cmd = new SQLiteCommand(userInsertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", handle.Role);
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Determine insert query based on role
                    string roleInsertQuery = "";
                    if (handle.Role.ToLower() == "student")
                    {
                        roleInsertQuery = @"INSERT INTO Students (UserID, NIC, FullName, Phone, Email, Address, DOB, ProfilePic) 
                                            VALUES (@UserID, @NIC, @FullName, @Phone, @Email, @Address, @DOB, @ProfilePic)";
                    }
                    else if (handle.Role.ToLower() == "admin")
                    {
                        roleInsertQuery = @"INSERT INTO Admins (UserID, NIC, FullName, Phone, Email, Address, DOB, ProfilePic) 
                                            VALUES (@UserID, @NIC, @FullName, @Phone, @Email, @Address, @DOB, @ProfilePic)";
                    }
                    else if (handle.Role.ToLower() == "staff")
                    {
                        roleInsertQuery = @"INSERT INTO Staff (UserID, NIC, FullName, Phone, Email, Address, DOB, ProfilePic) 
                                            VALUES (@UserID, @NIC, @FullName, @Phone, @Email, @Address, @DOB, @ProfilePic)";
                    }
                    else if (handle.Role.ToLower() == "lecturer")
                    {
                        roleInsertQuery = @"INSERT INTO Lecturers (UserID, NIC, FullName, Phone, Email, Address, DOB, ProfilePic) 
                                            VALUES (@UserID, @NIC, @FullName, @Phone, @Email, @Address, @DOB, @ProfilePic)";
                    }
                    else
                    {
                        throw new Exception("Invalid role");
                    }

                    // Insert into specific role table
                    using (var cmd = new SQLiteCommand(roleInsertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@NIC", handle.NIC);
                        cmd.Parameters.AddWithValue("@FullName", handle.FullName);
                        cmd.Parameters.AddWithValue("@Phone", handle.phone);
                        cmd.Parameters.AddWithValue("@Email", handle.Email);
                        cmd.Parameters.AddWithValue("@Address", handle.Address);
                        cmd.Parameters.AddWithValue("@DOB", handle.DOB);
                        cmd.Parameters.AddWithValue("@ProfilePic", profilePic ?? new byte[0]);
                        cmd.ExecuteNonQuery();
                    }

                    // Update pre_register status
                    using (var cmd = new SQLiteCommand("UPDATE pre_register SET Status = 1 WHERE NIC = @NIC", conn))
                    {
                        cmd.Parameters.AddWithValue("@NIC", handle.NIC);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public static bool ValidateLogin(string username, string password, out string role)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = @"SELECT Role FROM Users WHERE Username = @username AND Password = @password";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role = reader["Role"].ToString();
                            return true;
                        }
                        role = null;
                        return false;
                    }
                }
            }
        }
        public static UserProfile GetUserProfile(string username)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            int userId = Convert.ToInt32(reader["UserID"]);

                            return GetProfileByRole(userId, role, conn);
                        }
                    }
                }
            }
            return null;
        }

        private static UserProfile GetProfileByRole(int userId, string role, SQLiteConnection conn)
        {
            string roleTable = null;

            if (role.ToLower() == "admin") roleTable = "Admins";
            else if (role.ToLower() == "student") roleTable = "Students";
            else if (role.ToLower() == "staff") roleTable = "Staff";
            else if (role.ToLower() == "lecturer") roleTable = "Lecturers";

            if (roleTable == null) return null;

            string query = $"SELECT * FROM {roleTable} WHERE UserID = @UserID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserProfile
                        {
                            FullName = reader["FullName"].ToString(),
                            Role = role,
                            ProfilePic = reader["ProfilePic"] != DBNull.Value ? (byte[])reader["ProfilePic"] : null
                        };
                    }
                }
            }
            return null;
        }


    }
}
