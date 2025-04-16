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
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text.Trim();
            string lawyerId = LawyerIdBox.Text.Trim();
            string date = DatePicker.SelectedDate?.ToShortDateString() ?? "";
            string description = DescriptionBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(lawyerId) ||
                string.IsNullOrWhiteSpace(date) ||
                string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill out all fields.", "Missing Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Appointment confirmed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
