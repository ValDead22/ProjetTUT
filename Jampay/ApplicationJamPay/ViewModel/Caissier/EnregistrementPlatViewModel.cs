using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace ApplicationJamPay.ViewModel.Caissier
{
    class EnregistrementPlatViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public EnregistrementPlatViewModel()
        {
            if (IsInDesignMode)
            {
                Title = "Connexion (DESING)";
                // Code runs in Blend --> create design time data.
            }
            else
            {
                Title = "Connexion";
            }
        }


    }
}
