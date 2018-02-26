using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationJampay.Model.Entity;
using System.Windows.Input;

namespace ApplicationJampay.Model.Service
{
    public class DialogService
    {
        public static void ShowModifMenuView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.ModifMenuView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        public static void ShowCuisinierWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Cuisinier.CuisinierMainView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.Show();
        }

        public static void ShowModifPlatView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.ModifPlatView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        public static void ShowCaissierWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Caissier1, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.Show();
        }


        public static void ShowLoginWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.LoginView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.Show();
        }

        public static void ShowErrorWindow(string message)
        {
            var createType = Type.GetType("ApplicationJampay.View.ErrorView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType, message);
            
            windows.ShowDialog();
        }


        public static void ShowYesNoWindow(string msg, Action yes)
        {
            var createType = Type.GetType("ApplicationJampay.View.DialogYesNo, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType, msg, yes);

            windows.ShowDialog();
        }


        public static void ShowAjoutMenuView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.AjoutPlatView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        public static void ShowAjoutPlatView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.AjoutMenuView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        public static void ShowGérantMainView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.GérantMainView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.Show();
        }

        public static void ShowAjouterPlatWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.AjouterPlat, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }
 
  
    }
}
