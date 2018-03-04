using ApplicationJampay.ViewModel.ViewModel.Caissier.UserControlFolder;
using GalaSoft.MvvmLight.Messaging;
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

namespace ApplicationJampay.View.Caissier.UserControlFolder
{
    /// <summary>
    /// Logique d'interaction pour WelcomingUserControl.xaml
    /// </summary>
    public partial class WelcomingUserControl : UserControl
    {
        public WelcomingUserControl()
        {
            DataContext = new UserControlWelcomingViewModel();
            InitializeComponent();
        }
    }
}
