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
    /// Interaction logic for ProgressPage.xaml
    /// </summary>
    public partial class ProgressPage : Page
    {
        private int userId;
        private Database db = new Database();

        public ProgressPage(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void ProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ProgressText != null)
            {
                int value = (int)e.NewValue;

                if (value >= 100)
                {
                    ProgressText.Text = "Success";
                    ProgressText.Foreground = System.Windows.Media.Brushes.Green;
                    SuccessMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    ProgressText.Text = $"{value}%";
                    ProgressText.Foreground = System.Windows.Media.Brushes.Black;
                    SuccessMessage.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            string message = ChatInput.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                Border bubble = new Border
                {
                    Background = System.Windows.Media.Brushes.LightBlue,
                    CornerRadius = new CornerRadius(10),
                    Padding = new Thickness(10),
                    Margin = new Thickness(0, 5, 0, 5),
                    Child = new TextBlock
                    {
                        Text = "👨‍⚖️ Lawyer: " + message,
                        TextWrapping = TextWrapping.Wrap,
                        Foreground = System.Windows.Media.Brushes.Black
                    }
                };

                ChatHistory.Children.Add(bubble);
                ChatInput.Clear();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StartPage());
        }

        private void BackToDashboard_Click(object sender, RoutedEventArgs e)
        {
            if (db.LawyerExists(userId))
            {
                NavigationService?.Navigate(new LawerDashboard(userId));
            }
            else
            {
                MessageBox.Show("Lawyer not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
