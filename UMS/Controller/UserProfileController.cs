using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data;
using UMS.Model;

namespace UMS.Controller
{
    public static class UserProfileController
    {
        public static bool UpdateUserProfile(UserProfile profile)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Update Users table (username, password)
                    string updateUserQuery = @"
                        UPDATE Users SET Username = @Username, Password = @Password
                        WHERE UserID = @UserID";

                    using (var cmd = new SQLiteCommand(updateUserQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", profile.Username);
                        cmd.Parameters.AddWithValue("@Password", profile.Password);
                        cmd.Parameters.AddWithValue("@UserID", profile.UserID);
                        cmd.ExecuteNonQuery();
                    }

                    // Get the correct role table
                    string roleTable = GetRoleTable(profile.Role);
                    if (roleTable == null)
                        throw new Exception("Invalid role.");

                    string updateRoleQuery = $@"
                        UPDATE {roleTable} 
                        SET FullName = @FullName,
                            Phone = @Phone,
                            Email = @Email,
                            Address = @Address,
                            ProfilePic = @ProfilePic
                        WHERE UserID = @UserID";

                    using (var cmd = new SQLiteCommand(updateRoleQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", profile.FullName);
                        cmd.Parameters.AddWithValue("@Phone", profile.Phone);
                        cmd.Parameters.AddWithValue("@Email", profile.Email);
                        cmd.Parameters.AddWithValue("@Address", profile.Address);
                        cmd.Parameters.AddWithValue("@ProfilePic", profile.ProfilePic ?? new byte[0]);
                        cmd.Parameters.AddWithValue("@UserID", profile.UserID);
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

        private static string GetRoleTable(string role)
        {
            string lower = role.ToLower();
            if (lower == "student") return "Students";
            if (lower == "admin") return "Admins";
            if (lower == "staff") return "Staff";
            if (lower == "lecturer") return "Lecturers";
            return null;
        }
    }
}
