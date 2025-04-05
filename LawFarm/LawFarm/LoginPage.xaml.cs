using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            string username = UsernameBox.Text.Trim();
            string password = PasswordBox.Password;

            // Handle login logic (authentication)
            MessageBox.Show("Logged in successfully!", "Success");
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
