using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant
{


    public class GérantMainViewModel : IViewModelBase
    {        

        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;
        

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion               

        public Action Close;

        private readonly RelayCommand _logOut;
        public ICommand LogOut => _logOut;

        public GérantMainViewModel()
        {
            _logOut = new RelayCommand(() => Quit(), o => true);
        }

        private void Quit()
        {
            DialogService.ShowLoginWindow();
            Close();
           
        }

        
    }
}
