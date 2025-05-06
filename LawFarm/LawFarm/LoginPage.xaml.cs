using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Security.Cryptography;

namespace LawFarm
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            Database dbHelper = new Database();
            string hashedPassword = dbHelper.HashPassword(password);

            // Get user ID from the database using hashed password
            int userId = dbHelper.GetUserId(email, hashedPassword);

            if (userId == -1)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            // Check admin first using hashed password
            if (dbHelper.IsAdmin(userId))
            {
                MessageBox.Show("Welcome Admin!");
                try
                {
                    NavigationService?.Navigate(new AdminDashboard(userId));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Navigation error: " + ex.Message);
                }

            }
            // Then check lawyer
            else if (dbHelper.IsLawer(userId))
            {
                MessageBox.Show("Welcome Lawyer!");
                NavigationService?.Navigate(new LawerDashboard(userId));
            }
            // Otherwise, it's a regular user
            else
            {
                MessageBox.Show("Login successful!");
                NavigationService?.Navigate(new HomePage());
            }
        }

        private void ForgotPasswordLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ForgetPasswordPage());
        }

        private void BackToStartPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StartPage());
        }
    }
}

