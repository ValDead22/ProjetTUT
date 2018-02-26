using ApplicationJampay.ViewModel.ViewModel;
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
using System.Windows.Shapes;

namespace ApplicationJampay.View.Caissier
{
    /// <summary>
    /// Logique d'interaction pour Caissier1.xaml
    /// </summary>
    public partial class CaissierMainView : Window
    {
        public CaissierMainView()
        {
            InitializeComponent();

            DataContext = new CaissierViewModel();
        }
    }
}
