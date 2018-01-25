using ApplicationJamPay.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Security;
using System.Windows.Input;

namespace ApplicationJamPay.ViewModel
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChangedEH;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEH?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public ICommand LoginCommand { get; private set; }
        

        public LoginViewModel()
        {


            LoginCommand = new RelayCommand(() => Login());

            if (IsInDesignMode)
            {
                _title = "Connexion (DESING)";
                _identifiant = "02356433";
            }
            else
            {
                _title = "Connexion";
            }
        }

        private string _identifiant;
        public string Identifiant
        {
            get { return _identifiant; }
            set
            {
                _identifiant = value;
                OnPropertyChanged(nameof(Identifiant));
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private SecureString _password;
        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public void OpenWindowCanExecute()
        {
            Messenger.Default.Send(new NotificationMessage("OpenView"));
        }


        public void Login()
        {
            
            Console.Write("slt");
            
            //TODO Connexion à la bonne catégorie d'utilisateur
        }



        

        

        

        

    }
}