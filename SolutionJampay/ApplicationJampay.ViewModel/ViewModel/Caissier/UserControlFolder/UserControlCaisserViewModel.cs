using ApplicationJampay.Model.Entity;

using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ApplicationJampay.Model.DAL.Plat;

namespace ApplicationJampay.ViewModel.ViewModel.Caissier.UserControlFolder
{
    public class UserControlCaisserViewModel : IViewModelBase
    {
        #region Property Stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Commands
        private readonly RelayCommand _displayPlatCommand;
        public ICommand DisplayPlatViewCommand => _displayPlatCommand;

        private readonly RelayCommand _displayEntreeCommand;
        public ICommand DisplayEntreeViewCommand => _displayEntreeCommand;

        private readonly RelayCommand _displayDessertCommand;
        public ICommand DisplayDessertViewCommand => _displayDessertCommand;

        private readonly RelayCommand _displaySnackCommand;
        public ICommand DisplaySnackViewCommand => _displaySnackCommand;

        private readonly RelayCommand _validateCommand;
        public ICommand ValidateCommand => _validateCommand;

        private readonly RelayCommand _closeWindow;
        public ICommand CloseWindow => _closeWindow;

        private readonly RelayCommand _cardPayCommand;
        public ICommand CardPayCommand => _cardPayCommand;

        private readonly RelayCommand _openAddPlatViewCommand;
        public ICommand OpenAddPlatViewCommand => _openAddPlatViewCommand;

        private readonly RelayCommand _deleteSelectedChoosenPlat;
        public ICommand DeleteSelectedChoosenPlat => _deleteSelectedChoosenPlat;
        #endregion


        private PlatBusiness _platBusiness;

        private ObservableCollection<PlatWithQuantité> _collectionChoosenPlat = new ObservableCollection<PlatWithQuantité>();
        public IEnumerable<PlatWithQuantité> CollectionChoosenPlat { get { return _collectionChoosenPlat; } }

        private ObservableCollection<Plat> _coollectionOfSelectedCateg = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionOfSelectedCateg { get { return _coollectionOfSelectedCateg; } }

        private float _prixTotal = 0;

        public UserControlCaisserViewModel()
        {
            _openAddPlatViewCommand = new RelayCommand(() => AddPlat(), o => true);
            _deleteSelectedChoosenPlat = new RelayCommand(() => DeletePlat(), o => true);
            _cardPayCommand = new RelayCommand(() => PayCardReader(), o => true);

            _platBusiness = new PlatBusiness();

            _displayPlatCommand = new RelayCommand(() => Plats(), o => true);
            _displayEntreeCommand = new RelayCommand(() => Entrees(), o => true);
            _displayDessertCommand = new RelayCommand(() => Desserts(), o => true);
            _displaySnackCommand = new RelayCommand(() => Snacks(), o => true);

            _validateCommand = new RelayCommand(() => GetPlats(_selectedPlat), o => true);

            
        }

        private PlatWithQuantité _selectedChoosenPlat;
        public PlatWithQuantité SelectedChoosenPlat
        {
            get
            {
                return _selectedChoosenPlat;
            }
            set
            {
                _selectedChoosenPlat = value;
                OnPropertyChanged(nameof(SelectedChoosenPlat));
            }
        }

        private string _prix;
        public string Prix
        {
            get
            {
                return _prix;
            }
            set
            {
                _prix = value;
                OnPropertyChanged(nameof(Prix));
            }
        }

        private void GetPlats(Plat plat)
        {
            foreach (PlatWithQuantité platWQ in _collectionChoosenPlat)
            {
                if (plat.CodePlat == platWQ.CodePlat)
                {
                    platWQ.Quantite++;
                    _prixTotal += plat.Prix;
                    Prix = (Math.Round(_prixTotal, 1)).ToString() + " €";
                    return;
                }
            }
            _collectionChoosenPlat.Add(new PlatWithQuantité(plat.CodePlat, plat.DateEffet, plat.DateFin, plat.Categorie, plat.Nom, 1, plat.Prix));
            _prixTotal += plat.Prix;
            Prix = _prixTotal.ToString() + " €";

        }

        private void DeletePlat()
        {
            _prixTotal = _prixTotal - (SelectedChoosenPlat.Prix);
            Prix = _prixTotal.ToString() + " €";

            if (SelectedChoosenPlat.Quantite != 1)
            {
                SelectedChoosenPlat.Quantite--;
            }
            else
            {
                _collectionChoosenPlat.Remove(SelectedChoosenPlat);
            }

        }

        public void AddPlat()
        {
            DialogCaissier.ShowAjouterPlatWindow();
        }



        private Plat _selectedPlat;
        public Plat SelectedPlat
        {
            get
            {
                return _selectedPlat;
            }
            set
            {
                _selectedPlat = value;
                OnPropertyChanged(nameof(SelectedPlat));
            }
        }
        

        private void Plats()
        {
            _coollectionOfSelectedCateg.Clear();

            List<Plat> listPlats = new List<Plat>();
            try
            {
                listPlats = _platBusiness.GetPlatbyCateg("Plat");

                foreach (Plat plat in listPlats)
                {
                    _coollectionOfSelectedCateg.Add(plat);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void Entrees()
        {
            _coollectionOfSelectedCateg.Clear();

            List<Plat> listEntrees = new List<Plat>();

            try
            {
                listEntrees = _platBusiness.GetPlatbyCateg("Entree");

                foreach (Plat entree in listEntrees)
                {
                    _coollectionOfSelectedCateg.Add(entree);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void Desserts()
        {
            _coollectionOfSelectedCateg.Clear();
            List<Plat> listDesserts = new List<Plat>();

            try
            {
                listDesserts = _platBusiness.GetPlatbyCateg("Dessert");

                foreach (Plat dessert in listDesserts)
                {
                    _coollectionOfSelectedCateg.Add(dessert);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void Snacks()
        {
            _coollectionOfSelectedCateg.Clear();

            List<Plat> listSnacks = new List<Plat>();

            try
            {
                listSnacks = _platBusiness.GetPlatbyCateg("Snack");

                foreach (Plat snack in listSnacks)
                {
                    _coollectionOfSelectedCateg.Add(snack);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }

        }





        private void PayCardReader()
        {

            //UsagerBusiness _usagerBusiness = new UsagerBusiness();
            //int idUser = ManageDataCardService.GetCodeUser();

            //_usagerBusiness.Pay(idUser, _prixTotal);

            Messenger.Default.Send<string>("EditTicketUserControl");



        }
    }
}
