using ApplicationJampay.ViewModel.ViewModel.Gérant.UserControlTab;
using System.Windows.Controls;

namespace ApplicationJampay.View.Gérant.UserControlTab
{
    /// <summary>
    /// Logique d'interaction pour UserControlUsager.xaml
    /// </summary>
    public partial class UserControlUsager : UserControl
    {
        public UserControlUsager()
        {
            DataContext = new UserControlUsagerViewModel();
            InitializeComponent();
        }
    }
}
