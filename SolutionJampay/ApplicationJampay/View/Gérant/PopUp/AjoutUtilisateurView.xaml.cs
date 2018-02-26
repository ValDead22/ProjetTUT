using ApplicationJampay.ViewModel.ViewModel.Gérant;
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

namespace ApplicationJampay.View.Gérant.PopUp
{
    /// <summary>
    /// Logique d'interaction pour AjoutUtilisateurView.xaml
    /// </summary>
    public partial class AjoutUtilisateurView : Window
    {
        public AjoutUtilisateurView()
        {
            DataContext = new AjoutUtilisateurViewModel()
            {
                Close = () => this.Close()
            };

            InitializeComponent();
        }
    }
}
