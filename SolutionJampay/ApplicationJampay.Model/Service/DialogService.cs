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

        public static void ShowErrorWindow(string message)
        {
            var createType = Type.GetType("ApplicationJampay.View.ErrorView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType, message);
            
            windows.ShowDialog();
        }

        public static void ShowGerantWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant1, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        public static void ShowAjouterPlatWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.AjouterPlat, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }
        public static void ShowPlatsWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Plat, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }
        public static void ShowEntreesWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Entree, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }
        public static void ShowSnacksWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Snack, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }
        public static void ShowDessertstWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Dessert, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }
    }
}
