using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LawFarm
{
    public partial class Navbar : UserControl
    {
        public Navbar()
        {
            InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);
            nav?.Navigate(new HomePage());
        }

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);
            nav?.Navigate(new BookingPage()); // Make sure BookingPage exists
        }

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);
            nav?.Navigate(new ReviewPage()); // Make sure ReviewPage exists
        }
        // Logout button 
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var nav = NavigationService.GetNavigationService(this);
            nav?.Navigate(new StartPage());
        }
    }
}


