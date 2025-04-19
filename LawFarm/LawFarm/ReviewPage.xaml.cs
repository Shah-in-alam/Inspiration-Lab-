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
        }
        private void SubmitReview_Click(object sender, RoutedEventArgs e)
        {
            string userName = UserNameBox.Text.Trim();
            string lawyerName = LawyerNameBox.Text.Trim();
            string lawyerId = LawyerIdBox.Text.Trim();
            string ratingStr = (RatingBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string description = DescriptionBox.Text.Trim();

            // Simple validation
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

            // TODO: Save to database here
            int rating = int.Parse(ratingStr);

            // Save to database
            Database db = new Database();
            db.InsertReview(userName, lawyerName, lawyerId, rating, description);

            MessageBox.Show("Thank you for your feedback!",
                            "Review Submitted", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optional: clear fields after submission
            UserNameBox.Clear();
            LawyerNameBox.Clear();
            LawyerIdBox.Clear();
            RatingBox.SelectedIndex = -1;
            DescriptionBox.Clear();
        }
    }
}
