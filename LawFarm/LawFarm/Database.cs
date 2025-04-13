using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;

namespace LawFarm
{
    class Database
    {
        private string connectionString = "server=localhost;user id=root;password=;database=Lawdb";
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public void InsertUser(string username, string email, string password,bool isAdmin, bool isLawer)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string hashedPassword = HashPassword(password);
                    string query = "INSERT INTO Users (Username, Email, Password,Admin,Lawer) " +
                                   "VALUES (@Username, @Email, @Password, @Admin, @Lawer)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Admin",isAdmin);
                        cmd.Parameters.AddWithValue("@Lawer", isLawer);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sign-Up Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (MySqlException ex)

            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        // USER AUTHENTICATION NORMAL USER
        public bool CheckUser(string username, string hashedPassword)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword); // Comparing hash
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        //LAWER AUTHENTICATION 
        public bool IsLawer(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Lawer FROM Users WHERE Username = @Username AND Password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToBoolean(result); // returns true if Lawer = 1
                    }
                    return false;
                }
            }
        }
        //ADMIN AUTHENTICATION 
        public bool IsAdmin(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Admin FROM Users WHERE Username = @Username AND Password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToBoolean(result);
                    }
                    return false;
                }
            }
        }
        //CHANGE PASSWORD
        public bool UpdatePasswordByEmail(string email, string newPassword)
        {
            string hashedPassword = HashPassword(newPassword);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE users SET password = @Password WHERE email = @Email";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
        }
    }


}
