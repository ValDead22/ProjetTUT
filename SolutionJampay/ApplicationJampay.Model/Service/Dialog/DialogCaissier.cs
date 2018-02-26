using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
