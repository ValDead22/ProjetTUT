using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Service.Dialog
{
    public static class DialogGerant
    {

        /// <summary>
        /// Main View
        /// </summary>
        public static void ShowGerantMainView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.GérantMainView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.Show();
        }

        /// <summary>
        /// Create new Menu
        /// </summary>
        public static void ShowAjoutMenuView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.PopUp.Plat.AjoutPlatView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        /// <summary>
        /// Create new Plat
        /// </summary>
        public static void ShowAjoutPlatView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.PopUp.Menu.AjoutMenuView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        /// <summary>
        /// Modify a Menu
        /// </summary>
        public static void ShowModifMenuView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.PopUp.Menu.ModifMenuView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        /// <summary>
        /// Modify a Plat
        /// </summary>
        public static void ShowModifPlatView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.PopUp.Plat.ModifPlatView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }

        /// <summary>
        /// Create a new Utilisateur
        /// </summary>
        public static void ShowAjoutUtilisateurView()
        {
            var createType = Type.GetType("ApplicationJampay.View.Gérant.PopUp.AjoutUtilisateurView, ApplicationJampay");
            var windows = (System.Windows.Window)Activator.CreateInstance(createType);

            windows.ShowDialog();
        }
    }
}
