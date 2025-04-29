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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            LoadTopLawyers();
        }
        private void LoadTopLawyers()
        {
            Database db = new Database();
            var topLawyers = db.GetTopRatedLawyers(3);

            foreach (var lawyer in topLawyers)
            {
                StackPanel lawyerCard = new StackPanel
                {
                    Width = 180,
                    Margin = new Thickness(20, 0, 20, 0),
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                Border imageBorder = new Border
                {
                    Width = 120,
                    Height = 120,
                    CornerRadius = new CornerRadius(60),
                    BorderBrush = Brushes.Gray,
                    BorderThickness = new Thickness(2),
                    ClipToBounds = true
                };

                Image img = new Image
                {
                    Source = new BitmapImage(new Uri("Images/New.jpg", UriKind.Relative)),
                    Stretch = Stretch.Fill,
                    Width = 120,
                    Height = 120
                };

                imageBorder.Child = img;


                TextBlock nameText = new TextBlock
                {
                    Text = lawyer.FullName,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 10, 0, 0),
                    TextAlignment = TextAlignment.Center
                };

                TextBlock ratingText = new TextBlock
                {
                    Text = $"Rating: {lawyer.Rating}%",
                    FontSize = 14,
                    Foreground = Brushes.Green,
                    TextAlignment = TextAlignment.Center
                };
                TextBlock categoryText = new TextBlock
                {
                    Text = $"Category: {lawyer.Categories}",
                    FontSize = 14,
                    Foreground = Brushes.Green,
                    TextAlignment = TextAlignment.Center
                };

                lawyerCard.Children.Add(imageBorder);
                lawyerCard.Children.Add(nameText);
                lawyerCard.Children.Add(categoryText);
                lawyerCard.Children.Add(ratingText);

                TopLawyersPanel.Children.Add(lawyerCard);
            }
        }
    }

}

