using ApplicationJampay.ViewModel.ViewModel.Caissier;
using System.Windows;

namespace ApplicationJampay.View.Caissier.PopUp
{
    /// <summary>
    /// Logique d'interaction pour AjouterPlat.xaml
    /// </summary>
    public partial class AjouterPlat : Window
    {
        public AjouterPlat()
        {
            DataContext = new AjouterPlatViewModel()
            {
                Close = () => Close()
            };
            InitializeComponent();
            
        }
    }
}
