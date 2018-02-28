using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;
using ApplicationJampay.CardReaderAPI;
using ApplicationJampay.CardReaderAPI.ISO;
using ApplicationJampay.Model.DAL.Utilisateur;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using ApplicationJampay.Model.Service.Dialog;
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

        private readonly RelayCommand _cardLoginCommand;
        public ICommand CardLoginCommand => _cardLoginCommand;

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
            _cardLoginCommand = new RelayCommand(() => InitCardReader(), o => true);

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
        private string SecureStringToSHA256(SecureString secureString)
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

        private void Login()
        {
            try
            {
                Utilisateur utilisateur = _userBusiness.GetUtilisateur(Matricule, SecureStringToSHA256(Password));            
                
                switch (utilisateur.Fonction)
                {
                    case "Gérant":
                        DialogGerant.ShowGerantMainView();
                        Close();
                        break;

                    case "Caissier":
                        DialogCaissier.ShowCaissierMainWindow();
                        Close();
                        break;

                    case "Cuisinier":
                        DialogCuisinier.ShowCuisinierWindow();
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


        private static string ChooseRfidReader(IList<string> readerNames)
        {
            // Show available readers.
            Debug.WriteLine("Available readers: ");
            for (var i = 0; i < readerNames.Count; i++)
            {
                Debug.WriteLine($"[{i}] {readerNames[i]}");
            }
                return readerNames[0];
            
        }

        private static bool NoReaderFound(ICollection<string> readerNames) =>
            readerNames == null || readerNames.Count < 1;




        private void InitCardReader()
        {
            var contextFactory = ContextFactory.Instance;
            using (var context = contextFactory.Establish(SCardScope.System))
            {
                var readerNames = context.GetReaders();
                if (NoReaderFound(readerNames))
                {
                    Debug.WriteLine("You need at least one reader in order to run this example.");
                    return;
                }

                var readerName = ChooseRfidReader(readerNames);
                if (readerName == null)
                {
                    return;
                }

                // 'using' statement to make sure the reader will be disposed (disconnected) on exit
                using (var rfidReader = context.ConnectReader(readerName, SCardShareMode.Shared, SCardProtocol.Any))
                {
                    var apdu = new CommandApdu(IsoCase.Case2Short, rfidReader.Protocol)
                    {
                        CLA = 0xFF,
                        Instruction = InstructionCode.ReadBinary,
                        P1 = 0x00,
                        P2 = 0x08,
                        Le = 0x08 // We don't know the ID tag size
                    };

                    using (rfidReader.Transaction(SCardReaderDisposition.Leave))
                    {
                        Debug.WriteLine("Retrieving the UID .... ");

                        var sendPci = SCardPCI.GetPci(rfidReader.Protocol);
                        var receivePci = new SCardPCI(); // IO returned protocol control information.

                        var receiveBuffer = new byte[256];
                        var command = apdu.ToArray();

                        var bytesReceived = rfidReader.Transmit(
                            sendPci, // Protocol Control Information (T0, T1 or Raw)
                            command, // command APDU
                            command.Length,
                            receivePci, // returning Protocol Control Information
                            receiveBuffer,
                            receiveBuffer.Length); // data buffer

                        var responseApdu =
                            new ResponseApdu(receiveBuffer, bytesReceived, IsoCase.Case2Short, rfidReader.Protocol);
                        Debug.WriteLine("SW1: {0:X2}, SW2: {1:X2}\nUid: {2}",
                            responseApdu.SW1,
                            responseApdu.SW2,
                            responseApdu.HasData ? BitConverter.ToString(responseApdu.GetData()) : "No uid received");
                    }
                    
                }
            }

        }
                    
    }
}
