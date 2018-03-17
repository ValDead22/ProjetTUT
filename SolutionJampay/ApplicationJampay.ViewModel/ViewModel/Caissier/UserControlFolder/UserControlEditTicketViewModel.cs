using ApplicationJampay.Model.DAL.Commande;
using ApplicationJampay.Model.DAL.Usager;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.Model.Service.SmartCardReader;
using ApplicationJampay.ViewModel.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Caissier.UserControlFolder
{
    public class UserControlEditTicketViewModel : IViewModelBase
    {
        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private UsagerBusiness _usagerBusiness;
        private CommandeBusiness _commandeBusiness;

        private readonly RelayCommand _validateCarte;
        public ICommand ValidateCarte => _validateCarte;

        private readonly RelayCommand _validatePaiement;
        public ICommand ValidatePaiement => _validatePaiement;



        private ObservableCollection<Plat> _collectionChoosenPlat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionChoosenPlat { get { return _collectionChoosenPlat; } }

        public UserControlEditTicketViewModel()
        {

            Messenger.Default.Register<Tuple<Utilisateur, Tuple<List<Plat>, float>>>(this, (msg) => GetData(msg));

            CanPay = false;

            _usagerBusiness = new UsagerBusiness();
            _commandeBusiness = new CommandeBusiness();

            _validateCarte = new RelayCommand(() => CheckCarte(), o => true);
            _validatePaiement = new RelayCommand(() => Pay(), o => true);

        }

        private Usager _usagerWhoPay;
        public Usager UsagerWhoPay
        {
            get { return _usagerWhoPay; }
            set { _usagerWhoPay = value;
                OnPropertyChanged(nameof(UsagerWhoPay));
            }
        }

        private Utilisateur _caissier;
        public Utilisateur Caissier
        {
            get { return _caissier; }
            set { _caissier = value;
                OnPropertyChanged(nameof(Caissier));
            }
        }


        private bool _canPay;

        public bool CanPay
        {
            get { return _canPay; }
            set { _canPay = value;
                OnPropertyChanged(nameof(CanPay));
            }
        }

        private float _prix;

        public float Prix
        {
            get { return _prix; }
            set { _prix = value;
                OnPropertyChanged(nameof(Prix));
            }
        }




        private void CheckCarte()
        {
            try
            {
                int test = ManageDataCardService.GetCodeCarte();
                UsagerWhoPay = _usagerBusiness.GetUsagerByMatriculeCarte(test);
                CanPay = true;
                if (_usagerBusiness.GetCardCredit(UsagerWhoPay) < Prix && UsagerWhoPay.Paiement == "Carte")
                {
                    throw new Exception("Solde Insuffisant !");
                }
                else
                {
                    Commande commande = new Commande(Caissier.Matricule, UsagerWhoPay.Paiement, DateTime.Today, UsagerWhoPay.Matricule);
                    
                }

                
            }
            catch (Exception ex)
            {
                CanPay = false;
                UsagerWhoPay = null;
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void Pay()
        {
            try
            {
                float currentCredit = _usagerBusiness.GetCardCredit(UsagerWhoPay);

                if (currentCredit < Prix && UsagerWhoPay.Paiement == "Carte")
                {
                    throw new Exception("Solde Insuffisant !");
                }
                else
                {
                    Commande commande = new Commande(Caissier.Matricule, UsagerWhoPay.Paiement, DateTime.Today, UsagerWhoPay.Matricule);
                    _commandeBusiness.AddCommande(commande);
                    Commande lastCommande = _commandeBusiness.GetTheLastInsertedCommande();

                    foreach(Plat p in _collectionChoosenPlat)
                    {
                        _commandeBusiness.AddPlatToCommande(p, lastCommande);
                    }
                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                    float newCredit = currentCredit - Prix;
                    _usagerBusiness.SetCardCredit(UsagerWhoPay, newCredit);

                    DialogService.ShowSuccessWindow("Commande enregistrée avec succès");

                    Messenger.Default.Send<string>("CaisseUserControl");
                }


            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void GetData(Tuple<Utilisateur, Tuple<List<Plat>, float>> tuple)
        {
            Prix = tuple.Item2.Item2 ;
            Caissier = tuple.Item1;
            foreach (Plat p in tuple.Item2.Item1)
            {
                _collectionChoosenPlat.Add(p);
            }
        }
    }
}
