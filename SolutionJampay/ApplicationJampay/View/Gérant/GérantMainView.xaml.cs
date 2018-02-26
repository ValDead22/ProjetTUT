using ApplicationJampay.ViewModel.ViewModel.Gérant;
using System.Windows;

namespace ApplicationJampay.View.Gérant
{
    /// <summary>
    /// Logique d'interaction pour Gérant1.xaml
    /// </summary>
    public partial class GérantMainView : Window
    {
        public GérantMainView()
        {
            DataContext = new GérantMainViewModel();

            InitializeComponent();
        }
                

    }
}
