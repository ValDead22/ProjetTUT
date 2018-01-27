using ApplicationJamPay.Service;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
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
        
        public RelayCommand LoginCommand { get; private set; }
        private SQLService _sQLService;
        

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(() => Login());
            _sQLService = SQLService.Instance;

            if (IsInDesignMode)
            {
                _title = "Connexion (DESING)";
                _id = "02356433";
            }
            else
            {
                _title = "Connexion";
            }
        }

        private string _id;
        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
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


        private bool isMatching(string login, SecureString password)
        {


        }



        public void Login()
        {

            Console.WriteLine("slt");
            Console.WriteLine(ID);

            try {
                Console.WriteLine(Marshal.PtrToStringBSTR(Marshal.SecureStringToBSTR(Password)));
            }
            catch
            { }
            

            //TODO Connexion � la bonne cat�gorie d'utilisateur
        }



        

        

        

        

    }
}