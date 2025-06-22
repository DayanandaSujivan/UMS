using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using UMS.Data;
using UMS.Model;

namespace UMS.Controller
{
    internal class CreateAdminHandleUserController
    {
        public bool AddUser(CreateAdminHandleUser user)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = @"INSERT INTO pre_register 
                                    (NIC, FullName, Phone, Email, Address, DOB, Role, Status)
                                    VALUES (@NIC, @FullName, @Phone, @Email, @Address, @DOB, @Role, 0)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NIC", user.NIC.ToLower());
                        cmd.Parameters.AddWithValue("@FullName", user.FullName);
                        cmd.Parameters.AddWithValue("@Phone", user.Phone);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Address", user.Address);
                        cmd.Parameters.AddWithValue("@DOB", user.DOB);
                        cmd.Parameters.AddWithValue("@Role", user.Role.ToLower());
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user:\n" + ex.Message);
                return false;
            }
        }

        public List<CreateAdminHandleUser> GetAllUsers()
        {
            List<CreateAdminHandleUser> users = new List<CreateAdminHandleUser>();
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT * FROM pre_register";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new CreateAdminHandleUser
                            {
                                NIC = reader["NIC"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                Phone = Convert.ToInt32(reader["Phone"]),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                DOB = reader["DOB"].ToString(),
                                Role = reader["Role"].ToString(),
                                Status = reader["Status"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving users:\n" + ex.Message);
            }
            return users;
        }

        public bool UpdateUser(CreateAdminHandleUser user)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = @"UPDATE pre_register SET 
                                     FullName = @FullName, Phone = @Phone, Email = @Email,
                                     Address = @Address, DOB = @DOB, Role = @Role
                                     WHERE NIC = @NIC";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", user.FullName);
                        cmd.Parameters.AddWithValue("@Phone", user.Phone);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Address", user.Address);
                        cmd.Parameters.AddWithValue("@DOB", user.DOB);
                        cmd.Parameters.AddWithValue("@Role", user.Role.ToLower());
                        cmd.Parameters.AddWithValue("@NIC", user.NIC.ToLower());
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user:\n" + ex.Message);
                return false;
            }
        }

        public bool DeleteUser(int nic)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM pre_register WHERE NIC = @NIC";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NIC", nic);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user:\n" + ex.Message);
                return false;
            }
        }
    }
}
