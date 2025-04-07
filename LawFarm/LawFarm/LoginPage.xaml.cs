using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Security.Cryptography;
namespace LawFarm
{
    public partial class LoginPage : Page
    {
        //private Database dbHelper = new Database();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }
            

            // Hash the password before checking
            

            Database dbHelper = new Database();
            string hashedPassword = dbHelper.HashPassword(password);
            bool success = dbHelper.CheckUser(username, hashedPassword); // Pass the hashed password

            if (success)
            {
                MessageBox.Show("Login successful!");
                NavigationService?.Navigate(new HomePage()); // or wherever you go
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void ForgotPasswordLink_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to ForgotPasswordPage or show a message
            MessageBox.Show("Password reset instructions have been sent to your email.", "Password Reset");
        }

        private void BackToStartPage_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to StartPage
            NavigationService?.Navigate(new StartPage());
        }
    }
}
