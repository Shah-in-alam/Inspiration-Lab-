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
    /// Interaction logic for ReviewPage.xaml
    /// </summary>
    public partial class ReviewPage : Page
    {
        public ReviewPage()
        {
            InitializeComponent();
            LoadLawyerIds();
        }
        private void LoadLawyerIds()
        {
            Database db = new Database();
            List<string> lawyerIds = db.GetAllLawyerIds(); // You must define this in Database.cs
            LawyerIdBox.ItemsSource = lawyerIds;
        }
        private void SubmitReview_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserNameBox.Text.Trim();
            string lawyerName = LawyerNameBox.Text.Trim();
            string lawyerId = LawyerIdBox.SelectedItem?.ToString(); 
            string ratingStr = RatingBox.Text.Trim();
            string description = DescriptionBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(lawyerName) ||
                string.IsNullOrWhiteSpace(lawyerId) ||
                string.IsNullOrWhiteSpace(ratingStr) ||
                string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all fields before submitting the review.",
                                "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(ratingStr, out double rating) || rating < 0 || rating > 5)
            {
                MessageBox.Show("Please enter a valid rating between 0 and 5 (e.g. 4.5).",
                                "Invalid Rating", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Database db = new Database();
            db.InsertReview(userName, lawyerName, lawyerId, rating, description); // Database method should support double

            MessageBox.Show("Thank you for your feedback!",
                            "Review Submitted", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear fields
            UserNameBox.Clear();
            LawyerNameBox.Clear();
            LawyerIdBox.SelectedIndex=-1;
            RatingBox.Clear();
            DescriptionBox.Clear();
        }
    }
}
