using ApplicationJampay.ViewModel.ViewModel.Gérant.UserControlTab;
using System.Windows.Controls;

namespace ApplicationJampay.View.Gérant.UserControlTab
{
    /// <summary>
    /// Logique d'interaction pour UserControlUtilisateur.xaml
    /// </summary>
    public partial class UserControlUtilisateur : UserControl
    {
        public UserControlUtilisateur()
        {
            DataContext = new UserControlUtilisateurViewModel();
            InitializeComponent();
        }
    }
}
