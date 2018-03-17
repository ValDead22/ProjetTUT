using ApplicationJampay.Model.DAL.Menu;
using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.Model.DAL.Produit;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Cuisinier
{
    public class CuisinierMainViewModel : IViewModelBase
    {
        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion  

        #region Data Access

        private MenuBusiness _menuBusiness;

        private PlatBusiness _platBusiness;

        private ProduitBusiness _produitBusiness;

        #endregion

        #region ObservableCollections

        private ObservableCollection<Menu> _collectionMenu = new ObservableCollection<Menu>();
        public IEnumerable<Menu> CollectionMenus { get { return _collectionMenu; } }

        private ObservableCollection<Plat> _collectionPlatOfSelectedMenu = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlatOfSelectedMenu { get { return _collectionPlatOfSelectedMenu; } }

        private ObservableCollection<Produit> _collectionProduitOfSelectedPlat = new ObservableCollection<Produit>();
        public IEnumerable<Produit> CollectionProduitOfSelectedPlat { get { return _collectionProduitOfSelectedPlat; } }

        #endregion

        public Action Close;

        private readonly RelayCommand _logOut;
        public ICommand LogOut => _logOut;

        private readonly RelayCommand _openDeletePlatWindow;
        public ICommand OpenDeletePlatWindow => _openDeletePlatWindow;

        private readonly RelayCommand _openAddObsWindow;
        public ICommand OpenAddObsWindow => _openAddObsWindow;


        public CuisinierMainViewModel()
        {
            _menuBusiness = new MenuBusiness();
            _platBusiness = new PlatBusiness();
            _produitBusiness = new ProduitBusiness();

            _logOut = new RelayCommand(() => Quit(), o => true);

            _openDeletePlatWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir supprimer ce plat du menu ?", new Action(DeletePlat)), o => true);
            _openAddObsWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir ajouter une observation à ce produit ?", new Action(AddObs)), o => true);

            try
            {
                foreach (Menu menu in _menuBusiness.GetMenusDuJour())
                {
                    _collectionMenu.Add(menu);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }

        }

        private void Quit()
        {
            DialogService.ShowLoginWindow();
            Close();

        }

        private String _productObs;
        public String ProductObs
        {
            get { return _productObs; }
            set
            {
                _productObs = value;
                OnPropertyChanged(nameof(ProductObs));
            }
        }


        private Menu _selectedMenu;
        public Menu SelectedMenu
        {
            get
            {
                return _selectedMenu;
            }
            set
            {
                _selectedMenu = value;
                OnPropertyChanged(nameof(SelectedMenu));
                UpdatePlatCollection();
            }
        }

        private Produit _selectedProduit;
        public Produit SelectedProduit
        {
            get
            {
                return _selectedProduit;
            }
            set
            {
                _selectedProduit = value;
                OnPropertyChanged(nameof(SelectedProduit));
                if (_selectedProduit != null)
                {
                    ProductObs = _selectedProduit.Observation; 
                }
                else
                {
                    ProductObs = ""; 
                }
            }
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
                if(_selectedPlat != null)
                {
                    UpdateProduitCollection();
                }
                
            }
        }



        private void UpdatePlatCollection()
        {
            _collectionProduitOfSelectedPlat.Clear();
            _collectionPlatOfSelectedMenu.Clear();
            try
            {
                _platBusiness.GetPlatByMenu(SelectedMenu).ForEach(p => _collectionPlatOfSelectedMenu.Add(p));
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void UpdateProduitCollection()
        {
            _collectionProduitOfSelectedPlat.Clear();
            try
            {
                _produitBusiness.GetProduitsByPlatId(SelectedPlat).ForEach(p => _collectionProduitOfSelectedPlat.Add(p));
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
            
        }

        private void DeletePlat()
        {
            try
            {
                _menuBusiness.DeletePlatfromMenu(SelectedMenu,SelectedPlat);
                _collectionPlatOfSelectedMenu.Clear();
                _collectionProduitOfSelectedPlat.Clear();

                foreach (Plat plat in _platBusiness.GetPlatByMenu(SelectedMenu))
                {
                    _collectionPlatOfSelectedMenu.Add(plat);
                }

            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }

        }

        private void AddObs()
        {
            try
            {
                _produitBusiness.AddObs(SelectedProduit,ProductObs);
             
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }

        }


    }
}
