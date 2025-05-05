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
    /// Interaction logic for Appointment.xaml
    /// </summary>
    public partial class Appointment : Page
    {
        public Appointment()
        {
            InitializeComponent();
            LoadLawyerIds();
        }
        private void LoadLawyerIds()
        {
            Database db = new Database();
            var lawyerIds = db.GetAllLawyerIds(); // Make sure this method exists in your Database.cs
            LawyerIdBox.ItemsSource = lawyerIds;
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text.Trim();
            string lawyerId = LawyerIdBox.Text.Trim();
            DateTime? selectedDate = DatePicker.SelectedDate;
            string description = DescriptionBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lawyerId) || selectedDate == null || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Database db = new Database();
            db.InsertAppointment(name, lawyerId, selectedDate.Value, description);

            // Optional: Clear fields after
            NameBox.Clear();
            LawyerIdBox.SelectedIndex = -1;
            DatePicker.SelectedDate = null;
            DescriptionBox.Clear();
        }
    }
}
