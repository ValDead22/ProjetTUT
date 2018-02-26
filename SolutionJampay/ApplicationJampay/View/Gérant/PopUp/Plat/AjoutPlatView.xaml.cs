using ApplicationJampay.ViewModel.ViewModel.Gérant;
using System.Windows;

namespace ApplicationJampay.View.Gérant.PopUp.Plat
{
    /// <summary>
    /// Logique d'interaction pour AjouterPlatGerantView.xaml
    /// </summary>
    public partial class AjoutPlatView : Window
    {
        public AjoutPlatView()
        {
            DataContext = new AjoutPlatViewModel()
            {
                Close = () => Close()
            };

            InitializeComponent();
        }
    }
}
