using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ApplicationJampay.Model.Service;
using ApplicationJampay.ViewModel.Command;

namespace ApplicationJampay.ViewModel.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RelayCommand LoginCommand { get; private set; }
        private SQLService _sQLService;


        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(() => Login(), o => true);
            _sQLService = SQLService.Instance;

            
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
        


        private bool IsMatching(string login, SecureString password)
        {

            return true;
        }



        public void Login()
        {

            Console.WriteLine("slt");
            Console.WriteLine(ID);

            try
            {
                Console.WriteLine(Marshal.PtrToStringBSTR(Marshal.SecureStringToBSTR(Password)));
            }
            catch
            { }


            //TODO Connexion à la bonne catégorie d'utilisateur
        }
    }
}
