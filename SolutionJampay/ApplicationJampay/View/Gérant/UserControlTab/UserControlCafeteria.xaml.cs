using ApplicationJampay.ViewModel.ViewModel.Gérant.UserControlTab;
using System.Windows.Controls;

namespace ApplicationJampay.View.Gérant.UserControlTab
{
    /// <summary>
    /// Logique d'interaction pour UserControlCafeteria.xaml
    /// </summary>
    public partial class UserControlCafeteria : UserControl
    {
        public UserControlCafeteria()
        {
            DataContext = new UserControlCafeteriaViewModel();

            InitializeComponent();
        }
    }
}
