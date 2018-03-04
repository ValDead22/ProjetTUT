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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ApplicationJampay.ViewModel.ViewModel.Caissier.UserControlFolder;

namespace ApplicationJampay.View.Caissier.UserControlFolder
{
    /// <summary>
    /// Logique d'interaction pour CaisseUserControl.xaml
    /// </summary>
    public partial class CaisseUserControl : UserControl
    {
        public CaisseUserControl()
        {
            DataContext = new UserControlCaisserViewModel();
            InitializeComponent();
        }
    }
}
