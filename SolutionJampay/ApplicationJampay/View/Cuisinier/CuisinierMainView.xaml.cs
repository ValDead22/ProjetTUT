using ApplicationJampay.ViewModel.ViewModel.Cuisinier;
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

namespace ApplicationJampay.View.Cuisinier
{
    /// <summary>
    /// Logique d'interaction pour CuisinierMainView.xaml
    /// </summary>
    public partial class CuisinierMainView : Window
    {
        public CuisinierMainView()
        {
            DataContext = new CuisinierMainViewModel();

            InitializeComponent();            
        }
    }
}
