using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LawFarm
{
    /// <summary>
    /// Interaction logic for ForgetPasswordPage.xaml
    /// </summary>
    public partial class ForgetPasswordPage : Page
    {
        private Database db = new Database();
        public ForgetPasswordPage()
        {
            InitializeComponent();
        }
        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text.Trim();
            string newPassword = NewPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter both email and new password.", "Error");
                return;
            }

            bool updated = db.UpdatePasswordByEmail(email, newPassword);

            if (updated)
            {
                MessageBox.Show("Password updated successfully!", "Success");
                NavigationService?.Navigate(new StartPage()); // or SignInPage
            }
            else
            {
                MessageBox.Show("Email not found.", "Error");
            }
        }

        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StartPage());
        }
    }
}
