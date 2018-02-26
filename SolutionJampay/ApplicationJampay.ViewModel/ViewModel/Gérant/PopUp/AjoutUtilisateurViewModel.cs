using ApplicationJampay.Model.DAL.Usager;
using ApplicationJampay.Model.DAL.Utilisateur;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant
{
    public class AjoutUtilisateurViewModel : IViewModelBase
    {
        #region PropertyStuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public Action Close;


        private UsagerBusiness _usagerBusiness;
        private UtilisateurBusiness _utilisateurBusiness;

        private ObservableCollection<Usager> _collectionUsager = new ObservableCollection<Usager>();
        public IEnumerable<Usager> CollectionUsager { get { return _collectionUsager; } }

        private readonly RelayCommand _validateAddingUtilisateur;
        public ICommand ValidateAddingUtilisateur => _validateAddingUtilisateur;


        public AjoutUtilisateurViewModel()
        {
            _usagerBusiness = new UsagerBusiness();
            _utilisateurBusiness = new UtilisateurBusiness();

            _validateAddingUtilisateur = new RelayCommand(() => AddingUtilisateur(), o => true);

            try
            {
                foreach (Usager usager in _usagerBusiness.GetAllUsagersNonUtilisateur())
                {
                    _collectionUsager.Add(usager);
                }

            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void AddingUtilisateur()
        {
            _utilisateurBusiness.AddUtilisateur(SelectedUsager.Matricule, SelectedFonction, SecureStringToSHA256(Password));
            Close();
        }

        private string _selectedFonction;
        public string SelectedFonction
        {
            get { return _selectedFonction; }
            set
            {
                _selectedFonction = value;
                OnPropertyChanged(nameof(SelectedFonction));
            }
        }

        private Usager _selectedUsager;
        public Usager SelectedUsager
        {
            get { return _selectedUsager; }
            set
            {
                _selectedUsager = value;
                OnPropertyChanged(nameof(SelectedUsager));
            }
        }

        private List<string> _availableFonction;
        public List<string> AvailableFonction
        {
            get
            {
                return _utilisateurBusiness.GetAllFonctions();
            }
            set
            {
                _availableFonction = value;
                OnPropertyChanged(nameof(AvailableFonction));
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


        private string SecureStringToSHA256(SecureString secureString)
        {
            IntPtr intPtr = IntPtr.Zero;

            try
            {
                intPtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                string clearPassword = Marshal.PtrToStringUni(intPtr);

                using (SHA256 hash = SHA256Managed.Create())
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


    }
}
