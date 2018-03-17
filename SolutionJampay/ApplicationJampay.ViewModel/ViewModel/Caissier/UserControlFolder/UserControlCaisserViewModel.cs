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
using ApplicationJampay.Model.DAL.Menu;

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

        private readonly RelayCommand _displayAutreCommand;
        public ICommand DisplayAutreCommand => _displayAutreCommand;

        private readonly RelayCommand _validateCommand;
        public ICommand ValidateCommand => _validateCommand;
        
        private readonly RelayCommand _cardPayCommand;
        public ICommand CardPayCommand => _cardPayCommand;

        private readonly RelayCommand _openAddPlatViewCommand;
        public ICommand OpenAddPlatViewCommand => _openAddPlatViewCommand;

        private readonly RelayCommand _deleteSelectedChoosenPlat;
        public ICommand DeleteSelectedChoosenPlat => _deleteSelectedChoosenPlat;
        #endregion


        private PlatBusiness _platBusiness;

        private MenuBusiness _menuBusiness;

        private List<Menu> _menusDuJour;

        private ObservableCollection<PlatWithQuantité> _collectionChoosenPlat = new ObservableCollection<PlatWithQuantité>();
        public IEnumerable<PlatWithQuantité> CollectionChoosenPlat { get { return _collectionChoosenPlat; } }

        private ObservableCollection<Plat> _coollectionOfSelectedCateg = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionOfSelectedCateg { get { return _coollectionOfSelectedCateg; } }

        private float _prixTotal = 0;

        public UserControlCaisserViewModel()
        {
            _openAddPlatViewCommand = new RelayCommand(() => AddPlat(), o => true);
            _deleteSelectedChoosenPlat = new RelayCommand(() => DeletePlat(), o => true);
            _cardPayCommand = new RelayCommand(() => GoToTicketEdition(), o => true);

            _platBusiness = new PlatBusiness();
            _menuBusiness = new MenuBusiness();

            try
            {
                _menusDuJour = _menuBusiness.GetMenusDuJour();
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }

            _displayPlatCommand = new RelayCommand(() => Plats(), o => true);
            _displayEntreeCommand = new RelayCommand(() => Entree(), o => true);
            _displayDessertCommand = new RelayCommand(() => Dessert(), o => true);
            _displaySnackCommand = new RelayCommand(() => Snack(), o => true);
            _displayAutreCommand = new RelayCommand(() => Autre(), o => true);

            _validateCommand = new RelayCommand(() => GetPlats(_selectedPlat), o => true);

            
        }

        private List<Plat> GetPlatsByType(string type)
        {
            List<Plat> list = new List<Plat>();

            foreach(Menu m in _menusDuJour)
            {
                foreach(Plat p in m.ListPLats)
                {
                    if(p.Categorie == type)
                    {
                        list.Add(p);
                    }
                }
            }
            return list;
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
            

            foreach (Plat plat in GetPlatsByType("Plat"))
            {
                _coollectionOfSelectedCateg.Add(plat);
            }
        }

        private void Entree()
        {
            _coollectionOfSelectedCateg.Clear();

            foreach (Plat plat in GetPlatsByType("Entree"))
            {
                _coollectionOfSelectedCateg.Add(plat);
            }
        }

        private void Dessert()
        {
            _coollectionOfSelectedCateg.Clear();

            foreach (Plat plat in GetPlatsByType("Dessert"))
            {
                _coollectionOfSelectedCateg.Add(plat);
            }
        }

        private void Snack()
        {
            _coollectionOfSelectedCateg.Clear();

            foreach (Plat plat in GetPlatsByType("Snack"))
            {
                _coollectionOfSelectedCateg.Add(plat);
            }

        }

        private void Autre()
        {
            _coollectionOfSelectedCateg.Clear();

            foreach (Plat plat in GetPlatsByType("Autre"))
            {
                _coollectionOfSelectedCateg.Add(plat);
            }

        }



        private void GoToTicketEdition()
        {
            Tuple<float, List<Plat>> data = new Tuple<float, List<Plat>>(_prixTotal, new List<Plat>(_collectionChoosenPlat));

            Messenger.Default.Send<Tuple<float, List<Plat>>>(data);
            Messenger.Default.Send<string>("EditTicketUserControl");
        }
    }
}
