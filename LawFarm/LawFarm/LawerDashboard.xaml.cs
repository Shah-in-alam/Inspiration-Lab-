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
    /// Interaction logic for LawerDashboard.xaml
    /// </summary>
    public partial class LawerDashboard : Page
    {
        private Database db = new Database();
        private int userId;

       
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StartPage());
        }
        private void SubmitDetails_Click(object sender, RoutedEventArgs e)
        {
            string lawyerId = LawyerIdBox.Text.Trim();
            string fullName = FullNameBox.Text.Trim();
            string address = AddressBox.Text.Trim();
            string contact = ContactBox.Text.Trim();
            string[] categories = CategoryListBox.SelectedItems
                                        .OfType<ListBoxItem>()
                                        .Select(item => item.Content.ToString())
                                        .ToArray();


            if (string.IsNullOrWhiteSpace(lawyerId) || string.IsNullOrWhiteSpace(fullName)
                || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(contact)
                || categories.Length == 0)
            {
                MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Save to database
            db.InsertLawyer(lawyerId, fullName, address, contact, categories,userId);

            // Hide the form
            FormPanel.Visibility = Visibility.Collapsed;
        }
        public LawerDashboard(int id)
        {
            InitializeComponent();
            userId = id;

            if (db.LawyerExists(userId))
            {
                FormPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                FormPanel.Visibility = Visibility.Visible;
            }

        }
    }
}
