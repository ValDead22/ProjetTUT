using ApplicationJampay.ViewModel.ViewModel.Caissier;
using System.Windows;

namespace ApplicationJampay.View.Caissier
{
    /// <summary>
    /// Logique d'interaction pour Caissier1.xaml
    /// </summary>
    public partial class CaissierMainView : Window
    {
        public CaissierMainView()
        {
            DataContext = new CaissierViewModel();

            InitializeComponent();            
        }
    }
}
