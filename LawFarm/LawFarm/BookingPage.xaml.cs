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
    /// Interaction logic for BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        private Database db = new Database();
        public BookingPage()
        {
            InitializeComponent();
            LoadLawyersFromDB();
        }
        private void BookNow_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Booking submitted!", "Success");
            this.NavigationService.Navigate(new Appointment());
        }
        private void LoadLawyersFromDB()
        {
            var lawyers = db.GetLawyersWithRatings();
            LawyerListPanel.ItemsSource = lawyers;
        }
        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategories = new List<string>();

            if (CriminalCheckBox.IsChecked == true) selectedCategories.Add("Criminal");
            if (CivilCheckBox.IsChecked == true) selectedCategories.Add("Civil");
            if (DivorceCheckBox.IsChecked == true) selectedCategories.Add("Divorce");
            if (ImmigrationCheckBox.IsChecked == true) selectedCategories.Add("Immigration");
            if (CorporateCheckBox.IsChecked == true) selectedCategories.Add("Corporate");
            if (FamilyCheckBox.IsChecked == true) selectedCategories.Add("Family Law");
            if (IPCheckBox.IsChecked == true) selectedCategories.Add("Intellectual Property");

            var allLawyers = new Database().GetLawyersWithRatings();

            // Filter logic: check if any selected category exists in the lawyer's categories
            var filtered = allLawyers.Where(l =>
                selectedCategories.Any(cat => l.Categories?.ToLower().Contains(cat.ToLower()) == true)).ToList();

            LawyerListPanel.ItemsSource = filtered;
        }

    }
}
