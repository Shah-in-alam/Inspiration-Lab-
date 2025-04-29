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
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Page
    {
        private Database db = new Database();
        public AdminDashboard()
        {
            InitializeComponent();
            LoadUsers();      
            LoadLawyers();
        }
        private void LoadUsers()
        {
            UsersList.ItemsSource = db.GetAllUsers(); // Returns List<User>
        }

        private void LoadLawyers()
        {
            LawyersList.ItemsSource = db.GetAllLawyers(); // Returns List<Lawyer>
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersList.SelectedItem as User;
            if (selectedUser != null)
            {
                db.DeleteUserById(selectedUser.Id);
                LoadUsers();
            }
        }

        private void DeleteLawyer_Click(object sender, RoutedEventArgs e)
        {
            var selectedLawyer = LawyersList.SelectedItem as Lawyer;
            if (selectedLawyer != null)
            {
                db.DeleteLawyerById(selectedLawyer.Id);
                LoadLawyers();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StartPage());
        }
    }

}
