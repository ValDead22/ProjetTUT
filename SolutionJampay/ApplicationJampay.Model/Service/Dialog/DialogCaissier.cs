using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ApplicationJampay.Model.Service.Dialog
{
    public static class DialogCaissier
    {
        /// <summary>
        /// Main View
        /// </summary>
        public static void ShowCaissierMainWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Caissier.CaissierMainView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.Show();
        }

        /// <summary>
        /// Add a new Plat into the command
        /// </summary>
        public static void ShowAjouterPlatWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Caissier.PopUp.AjouterPlat, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        /// <summary>
        /// Show the caisse into the main view of the Caissier
        /// </summary>
        public static FrameworkElement GetCaisseUserControl()
        {
            var createType = Type.GetType("ApplicationJampay.View.Caissier.UserControlFolder.CaisseUserControl, ApplicationJampay");
            var usercontrol = (System.Windows.Controls.UserControl)Activator.CreateInstance(createType);

            return usercontrol;
        }

        /// <summary>
        /// Show the the welcoming message into the main view of the Caissier
        /// </summary>
        public static FrameworkElement GetWelcomingUserControl()
        {
            var createType = Type.GetType("ApplicationJampay.View.Caissier.UserControlFolder.WelcomingUserControl, ApplicationJampay");
            var usercontrol = (System.Windows.Controls.UserControl)Activator.CreateInstance(createType);

            return usercontrol;
        }

        /// <summary>
        /// Show the the facture manager into the main view of the Caissier
        /// </summary>
        public static FrameworkElement GetFactureUserControl()
        {
            var createType = Type.GetType("ApplicationJampay.View.Caissier.UserControlFolder.FactureUserControl, ApplicationJampay");
            var usercontrol = (System.Windows.Controls.UserControl)Activator.CreateInstance(createType);

            return usercontrol;
        }
    }
}
