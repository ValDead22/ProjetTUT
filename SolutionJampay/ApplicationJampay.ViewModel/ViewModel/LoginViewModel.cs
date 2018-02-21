using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApplicationJampay.Model.DAL;
using ApplicationJampay.Model.DAL.Utilisateur;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using ApplicationJampay.ViewModel.Command;

namespace ApplicationJampay.ViewModel.ViewModel
{
    public class LoginViewModel : IViewModelBase
    {
        #region PropertyChanged stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public Action Close;

        private int Try;

        /// <summary>
        /// Login Command
        /// </summary>
        private readonly RelayCommand _loginCommand;
        public ICommand LoginCommand => _loginCommand;

        /// <summary>
        /// Logic to access to the Users data
        /// </summary>
        private UtilisateurBusiness _userBusiness;

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginViewModel()
        {
            _loginCommand = new RelayCommand(() => Login(), o => true);
            _userBusiness = new UtilisateurBusiness();            
        }
        
        #region Properties
        private string _matricule;
        public string Matricule
        {
            get { return _matricule; }
            set
            {
                _matricule = value;
                OnPropertyChanged(nameof(Matricule));
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
        #endregion

        /// <summary>
        /// Convert a SecureString into a SHA256 hash
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public string SecureStringToSHA256(SecureString secureString)
        {
            IntPtr intPtr = IntPtr.Zero;

            try
            {
                intPtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                string clearPassword = Marshal.PtrToStringUni(intPtr);

                using(SHA256 hash = SHA256Managed.Create())
                {
                    Encoding encoding = Encoding.UTF8;
                    StringBuilder finalHash = new StringBuilder();

                    byte[] result = hash.ComputeHash(encoding.GetBytes(clearPassword));

                    foreach (byte theByte in result)
                    {
                        finalHash.Append(theByte.ToString("x2"));
                    }

                    return finalHash.ToString();
                }
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
            }
        }


        public void Login()
        {
            try
            {
                Utilisateur utilisateur = _userBusiness.GetUtilisateur(Matricule, SecureStringToSHA256(Password));
                
                

                switch (utilisateur.Fonction)
                {
                    case "Gérant":
                        DialogService.ShowGérantMainView();
                        Close();
                        break;

                    case "Caissier":
                        DialogService.ShowCaissierWindow();
                        Close();
                        break;
                }

                

            }
            catch (Exception ex)
            {
                Try++;
                var msg = "Il vous reste " + (5 - Try).ToString() + " essais";
                DialogService.ShowErrorWindow(ex.Message + "\n" + msg);
            }
            
        }
        
    }
}
