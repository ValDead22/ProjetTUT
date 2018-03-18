using ApplicationJampay.Model.DAL.Utilisateur;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using ApplicationJampay.ViewModel.ViewModel.Caissier.UserControlFolder;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Caissier
{
    public class CaissierViewModel : IViewModelBase
    {
        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion

        private FrameworkElement _contentControlView;
        public FrameworkElement ContentControlView
        {
            get { return _contentControlView; }
            set
            {
                _contentControlView = value;
                OnPropertyChanged(nameof(ContentControlView));
            }
        }

        public Action Close;

        private Tuple<List<Plat>, float> _choosenPlat;
        private Utilisateur _currentCaissier;

        private readonly RelayCommand _logOut;
        public ICommand LogOut => _logOut;

        private readonly RelayCommand _goToMenu;
        public ICommand GoToMenu => _goToMenu;

        

        public CaissierViewModel()
        {

            ContentControlView = DialogCaissier.GetWelcomingUserControl();

            Messenger.Default.Register<Utilisateur>(this, (utilisateur) => GetUtilisateur(utilisateur));
            Messenger.Default.Register<string>(this, (msg) => SwitchView(msg));
            Messenger.Default.Register<Tuple<float, List<Plat>>>(this, (msg) => GetChoosenPlat(msg));

            _logOut = new RelayCommand(() => Quit(), o => true);
            _goToMenu = new RelayCommand(() => ContentControlView = DialogCaissier.GetWelcomingUserControl(), o => true);

        }

        private void GetUtilisateur(Utilisateur utilisateur)
        {
            _currentCaissier = utilisateur;
        }




        private void Quit()
        {
            DialogService.ShowLoginWindow();
            Close();

        }

        private void SwitchView(string msg)
        {
            switch (msg)
            {
                case "CaisseUserControl":
                    ContentControlView = DialogCaissier.GetCaisseUserControl();
                    break;

                case "FactureUserControl":
                    ContentControlView = DialogCaissier.GetFactureUserControl();
                    break;

                case "EditTicketUserControl":
                    ContentControlView = DialogCaissier.GetEditTicketUserControl();
                    Messenger.Default.Send(new Tuple<Utilisateur, Tuple<List<Plat>, float>>(_currentCaissier, _choosenPlat));
                    break;
            }
        }

        private void GetChoosenPlat(Tuple<float, List<Plat>> data)
        {
            _choosenPlat = new Tuple<List<Plat>, float>(data.Item2, data.Item1);
        }

        
    }
}
      

        



    
    


