using LawFarm;
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
        private string currentLawyerId;

        public LawerDashboard(int id)
        {
            InitializeComponent();
            userId = id;

            if (db.LawyerExists(userId))
            {
                FormPanel.Visibility = Visibility.Collapsed;
                ProfileImage.Visibility = Visibility.Visible;
                AppointmentSection.Visibility = Visibility.Visible;

                currentLawyerId = db.GetLawyerIdByUserId(userId);
                AppointmentList.ItemsSource = db.GetAppointmentsByLawyerId(currentLawyerId);

                AppointmentCalendar.SelectedDatesChanged += AppointmentCalendar_SelectedDatesChanged;
            }
            else
            {
                FormPanel.Visibility = Visibility.Visible;
                ProfileImage.Visibility = Visibility.Collapsed;
                AppointmentSection.Visibility = Visibility.Collapsed;
            }
        }

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

            db.InsertLawyer(lawyerId, fullName, address, contact, categories, userId);
            FormPanel.Visibility = Visibility.Collapsed;
            ProfileImage.Visibility = Visibility.Visible;
            AppointmentSection.Visibility = Visibility.Visible;

            currentLawyerId = lawyerId;
            AppointmentList.ItemsSource = db.GetAppointmentsByLawyerId(lawyerId);
        }

        private void AppointmentCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AppointmentCalendar.SelectedDate.HasValue && !string.IsNullOrEmpty(currentLawyerId))
            {
                DateTime selectedDate = AppointmentCalendar.SelectedDate.Value;
                var filteredAppointments = db.GetAppointmentsByLawyerIdAndDate(currentLawyerId, selectedDate);
                AppointmentList.ItemsSource = filteredAppointments;
            }
        }
    }
}