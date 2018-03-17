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

namespace ApplicationJampay.View
{
    /// <summary>
    /// Logique d'interaction pour SuccessView.xaml
    /// </summary>
    public partial class SuccessView : Window
    {
        public SuccessView(string message)
        {

            InitializeComponent();
            MsgLabel.Text = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
    }
}
