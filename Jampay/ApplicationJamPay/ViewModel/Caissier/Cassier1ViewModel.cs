using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace ApplicationJamPay.ViewModel.Caissier
{
    public class Cassier1ViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public Cassier1ViewModel()
        {
            if (IsInDesignMode)
            {
                Title = "Caissier (DESING)";
                // Code runs in Blend --> create design time data.
            }
            else
            {
                Title = "Caissier";
            }
        }


    }
}
