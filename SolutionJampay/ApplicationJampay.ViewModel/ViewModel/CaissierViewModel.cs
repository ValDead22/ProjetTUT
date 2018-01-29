using ApplicationJampay.Model.DAL.Usager;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.ViewModel.ViewModel
{
    public class CaissierViewModel : INotifyPropertyChanged
    {
            public event PropertyChangedEventHandler PropertyChanged;

            void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        //List implémente IEnumerable, pas de sousses
        
        private ObservableCollection<Plat> _collectionPlat = new ObservableCollection<Plat>();
        public IEnumerable<Menu> CollectionPlat { get { return _collectionPlat; } }

        public RelayCommand AjoutP { get; private set; }
            public RelayCommand Reglement { get; private set; }
            private UserBusinessLayer _userBusinessLayer;


            public CaissierViewModel()
            {
                AjoutP = new RelayCommand(() => AjoutPlat(), o => true);
                Reglement = new RelayCommand(() => ReglementCommand(), o => true);
                _userBusinessLayer = new UserBusinessLayer();
            }

            
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


            public string SecureStringToSHA256(SecureString secureString)
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


            public void AjoutPlat()
            {
                try
                {
                    string role = _userBusinessLayer.GetUser(Matricule, SecureStringToSHA256(Password));

                    switch (role)
                    {
                        case "Gérant":
                            DialogService.ShowGerantWindow();
                            break;

                        case "Caissier":
                            DialogService.ShowCaissierWindow();
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        public void ReglementCommand()
        {
            try
            {
                string role = _userBusinessLayer.GetUser(Matricule, SecureStringToSHA256(Password));

                switch (role)
                {
                    case "Gérant":
                        DialogService.ShowGerantWindow();
                        break;

                    case "Caissier":
                        DialogService.ShowCaissierWindow();
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



    }
    }
}
}
