using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        private Database dbHelper = new Database();
        public SignUpPage()
        {
            InitializeComponent();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            string password = PasswordBox.Password;
            bool isAdmin = email.ToLower().EndsWith(".admin@gmail.com");
            bool isLawer = email.ToLower().EndsWith(".lawyer@gmail.com");

            //lawer define
            //if (isLawer)
            //{
            //    string[] parts=email.Split('.');
            //    if (parts.Length > 0)
            //    {

            //        string nameParts=parts[0];
            //        username = char.ToUpper(nameParts[0])+nameParts.Substring(1);

            //    }   
            //}

            // Do validation / processing
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            dbHelper.InsertUser(username, email, password,isAdmin,isLawer);
        }

        private void LoginLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StartPage());
        }
    }
}
