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

            Database dbHelper = new Database();
            string hashedPassword = dbHelper.HashPassword(password);

            // Role-based priority
            if (dbHelper.IsAdmin(username, password))
            {
                MessageBox.Show("Welcome Admin!");
                NavigationService?.Navigate(new AdminDashboard());
            }
            else if (dbHelper.IsLawer(username, password))
            {
                MessageBox.Show("Welcome Lawer!");
                NavigationService?.Navigate(new LawerDashboard());
            }
            else if (dbHelper.CheckUser(username, hashedPassword)) // normal user
            {
                MessageBox.Show("Login successful!");
                NavigationService?.Navigate(new HomePage());
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        
        }

        private void ForgotPasswordLink_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to ForgotPasswordPage or show a message
            NavigationService?.Navigate(new ForgetPasswordPage());
        }

        private void BackToStartPage_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to StartPage
            NavigationService?.Navigate(new StartPage());
        }
    }
}
