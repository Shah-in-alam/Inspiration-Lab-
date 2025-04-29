using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using static LawFarm.BookingPage;

namespace LawFarm
{
    class Database
    {
        private string connectionString = "server=localhost;user id=root;password=;database=Lawdb";
        //-------------------------------------------------------------------------------------------------
        //PASSWORD HASSING
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
        //-----------------------------------------------------------------------------------------------------------
        //USER DATA ENTRY POINT
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
        //------------------------------------------------------------------------------------------------------------
        // USER AUTHENTICATION NORMAL USER
        public int GetUserId(string username, string hashedPassword)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id FROM users WHERE username = @username AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        object result = cmd.ExecuteScalar();
                        return result != null && result != DBNull.Value ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
                return -1;
            }
        }
        //-----------------------------------------------------------------------------------------------------------
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
        //----------------------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------------------------------------
        //LAWERS DATA
        public void InsertLawyer(string lawyerId, string fullName, string address, string contact, string[] categories,int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO lawyers (lawyer_id, full_name, address, contact, categories,user_id) " +
                                   "VALUES (@lawyerId, @fullName, @address, @contact, @categories,@userId)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@lawyerId", lawyerId);
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@categories", string.Join(", ", categories));
                        cmd.Parameters.AddWithValue("@userId",userId);
                        

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Lawyer details saved to database!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------
        //IF LAWER already input his details 
        public bool LawyerExists(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM lawyers WHERE user_id = @userId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------
        //REVIEW SAVING IN THE DATABASE
        
        public void InsertReview(string userName, string lawyerName, string lawyerId, int rating, string description)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO reviews (user_name, lawyer_name, lawyer_id, rating, description) " +
                                   "VALUES (@userName, @lawyerName, @lawyerId, @rating, @description)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@lawyerName", lawyerName);
                        cmd.Parameters.AddWithValue("@lawyerId", lawyerId);
                        cmd.Parameters.AddWithValue("@rating", rating);
                        cmd.Parameters.AddWithValue("@description", description);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        ///----------------------------------------------------------------------------------------------------------
        ///LAWYER DISPLAY IN BOOKING WINDOW: 
        public List<LawyerDisplayModel> GetLawyersWithRatings()
        {
            List<LawyerDisplayModel> lawyers = new List<LawyerDisplayModel>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    l.lawyer_id,
                    l.full_name,
                    l.categories,
                    COALESCE(AVG(r.rating), 0) AS average_rating
                FROM 
                    lawyers l
                LEFT JOIN 
                    reviews r ON l.lawyer_id = r.lawyer_id
                GROUP BY 
                    l.lawyer_id, l.full_name,l.categories";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var model = new LawyerDisplayModel
                            {
                                LawyerId = reader["lawyer_id"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Categories = reader["categories"].ToString(),
                                Rating = Convert.ToDouble(reader["average_rating"]).ToString("0") // Round off
                            };
                            lawyers.Add(model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }

            return lawyers;
        }


    }


}
