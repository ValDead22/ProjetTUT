using ApplicationJampay.ViewModel.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Caissier.UserControlFolder
{
    public class UserControlWelcomingViewModel : IViewModelBase
    {
        #region Property Stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion

        #region Commands

        private readonly RelayCommand _showCaisseUserControl;
        public ICommand ShowCaisseUserControl => _showCaisseUserControl;

        private readonly RelayCommand _showFactureUserControl;
        public ICommand ShowFactureUserControl => _showFactureUserControl;
        #endregion


        public UserControlWelcomingViewModel()
        {
            _showCaisseUserControl = new RelayCommand(() => Messenger.Default.Send<string>("CaisseUserControl"), o => true);

            _showFactureUserControl = new RelayCommand(() => Messenger.Default.Send<string>("FactureUserControl"), o => true);

        }
    }
}
