using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Service
{
    public class DialogService
    {
        public static void ShowCaissierWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Caissier1, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        public static void ShowGerantWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant1, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }
    }
}
