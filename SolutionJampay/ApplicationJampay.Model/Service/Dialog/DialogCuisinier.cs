using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Service.Dialog
{
    public static class DialogCuisinier
    {
        /// <summary>
        /// Main view
        /// </summary>
        public static void ShowCuisinierWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.Cuisinier.CuisinierMainView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.Show();
        }
    }
}
