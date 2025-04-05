using System.Windows;

namespace LawFarm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new StartPage());
        }
    }
}
