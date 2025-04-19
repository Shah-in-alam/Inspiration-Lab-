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

    }
}
