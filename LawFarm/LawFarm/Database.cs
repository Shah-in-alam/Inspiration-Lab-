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
        private string connectionString = "server=localhost;user id=root;password=;database=LawDb";
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
        public int GetUserId(string email, string hashedPassword)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id FROM users WHERE email = @Email AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
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
        public bool IsLawer(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Lawer FROM Users WHERE id = @UserId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    object result = cmd.ExecuteScalar();
                    return result != null && Convert.ToBoolean(result);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------------
        //ADMIN AUTHENTICATION 
  
        public bool IsAdmin(string email, string hashedPassword)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Admin FROM Users WHERE Email = @Email AND Password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    object result = cmd.ExecuteScalar();
                    return result != null && Convert.ToBoolean(result);
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
        //IF LAWYER DETAILS already input his details 
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
        public string GetLawyerIdByUserId(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT lawyer_id FROM lawyers WHERE user_id = @userId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------
        public List<AppointmentModel> GetAppointmentsByLawyerIdAndDate(string lawyerId, DateTime date)
        {
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT name, date,description FROM appointments WHERE lawyer_id = @lawyerId AND DATE(date) = @date";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lawyerId", lawyerId);
                    cmd.Parameters.AddWithValue("@date", date.Date);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new AppointmentModel
                            {
                                Name = reader["name"].ToString(),
                                Date = Convert.ToDateTime(reader["date"]).ToShortDateString(),
                                   Description = reader["description"].ToString()
                            });
                        }
                    }
                }
            }

            return appointments;
        }
        public List<AppointmentModel> GetAppointmentsByLawyerId(string lawyerId)
        {
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT name, date FROM appointments WHERE lawyer_id = @lawyerId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lawyerId", lawyerId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new AppointmentModel
                            {
                                Name = reader["name"].ToString(),
                                Date = Convert.ToDateTime(reader["date"]).ToShortDateString()
                            });
                        }
                    }
                }
            }

            return appointments;
        }
        public string GetAppointmentDescription(string lawyerId, DateTime date)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT description FROM appointments WHERE lawyer_id = @lawyerId AND DATE(date) = @date LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lawyerId", lawyerId);
                    cmd.Parameters.AddWithValue("@date", date.Date);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "No description found.";
                }
            }
        }


        //----------------------------------------------------------------------------------------------------------------------
        //REVIEW SAVING IN THE DATABASE

        public void InsertReview(string userName, string lawyerName, string lawyerId, double rating, string description)
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
        //----------------------------------------------------------------------------------------------------------
        public List<string> GetAllLawyerIds()
        {
            List<string> ids = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT lawyer_id FROM lawyers";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ids.Add(reader["lawyer_id"].ToString());
                    }
                }
            }
            return ids;
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
                       l.lawyer_id, l.full_name, l.categories";

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
                                Rating = Convert.ToDouble(reader["average_rating"]) // Fix: Ensure Rating is assigned as a double
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
        //--------------------------------------------------------------------------------------------------------
        //GET LAWYER ID BY NAME top 3
        public List<LawyerDisplayModel> GetTopRatedLawyers(int count = 3)
        {
            List<LawyerDisplayModel> lawyers = new List<LawyerDisplayModel>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $@"
                SELECT 
                    l.lawyer_id,
                    l.full_name,l.categories,
                    COALESCE(AVG(r.rating), 0) AS average_rating
                FROM lawyers l
                LEFT JOIN reviews r ON l.lawyer_id = r.lawyer_id
                GROUP BY l.lawyer_id, l.full_name
                ORDER BY average_rating DESC
                LIMIT {count};";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lawyers.Add(new LawyerDisplayModel
                            {
                                LawyerId = reader["lawyer_id"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Categories = reader["categories"].ToString(),
                                Rating = Convert.ToDouble(reader["average_rating"]) // Fix: Ensure Rating is assigned as a double
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching top lawyers: " + ex.Message);
            }

            return lawyers;
        }

        //----------------------------------------------------------------------------------------------------------
        //APPOINTMENT SAVING IN THE DATABASE
        public void InsertAppointment(string name, string lawyerId, DateTime date, string description)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO appointments (name, lawyer_id, date, description)
                             VALUES (@name, @lawyerId, @date, @description)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@lawyerId", lawyerId);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@description", description);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Appointment booked successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        //----------------------------------------------------------------------------------------------------------
        //DELETE USERS AND LAWYERS BY ADMIN
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, username FROM users";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Username = reader["username"].ToString()
                        });
                    }
                }
            }
            return users;
        }

        public void DeleteUserById(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM users WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Lawyer> GetAllLawyers()
        {
            List<Lawyer> lawyers = new List<Lawyer>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT lawyer_id, full_name FROM lawyers";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lawyers.Add(new Lawyer
                        {
                            LawyerId = reader["lawyer_id"].ToString(),
                            FullName = reader["full_name"].ToString()
                        });

                    }
                }
            }
            return lawyers;
        }

        public void DeleteLawyerById(string lawyerId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM lawyers WHERE lawyer_id = @lawyerId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lawyerId", lawyerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
