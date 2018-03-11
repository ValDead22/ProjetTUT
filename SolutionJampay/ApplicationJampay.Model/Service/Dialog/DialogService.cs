using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationJampay.Model.Entity;
using System.Windows.Input;

namespace ApplicationJampay.Model.Service.Dialog
{
    public class DialogService
    {       

        /// <summary>
        /// Show a Error window
        /// </summary>
        /// <param name="message"></param>
        public static void ShowErrorWindow(string message)
        {
            var createType = Type.GetType("ApplicationJampay.View.ErrorView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType, message);
            
            windows.ShowDialog();
        }

        /// <summary>
        /// Show a dialog with YES and NO buttons
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="yes"></param>
        public static void ShowYesNoWindow(string msg, Action yes)
        {
            var createType = Type.GetType("ApplicationJampay.View.DialogYesNo, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType, msg, yes);

            windows.ShowDialog();
        }


        public static void ShowLoginWindow()
        {
            var createType = Type.GetType("ApplicationJampay.View.LoginView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.Show();
        }

    }
}
