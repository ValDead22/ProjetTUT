using ApplicationJampay.ViewModel.ViewModel.Gérant;
using System.Windows;

namespace ApplicationJampay.View.Gérant.PopUp.Menu
{
    /// <summary>
    /// Logique d'interaction pour AjouterMenuGerantView.xaml
    /// </summary>
    public partial class AjoutMenuView : Window
    {
        public AjoutMenuView()
        {
            DataContext = new AjoutMenuViewModel()
            {
                Close = () => Close()
            };
            InitializeComponent();
        }
    }
}
