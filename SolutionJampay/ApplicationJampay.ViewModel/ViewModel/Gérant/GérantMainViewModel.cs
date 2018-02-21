using ApplicationJampay.Model.DAL.Menu;
using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.Model.DAL.Usager;
using ApplicationJampay.Model.DAL.Utilisateur;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using ApplicationJampay.ViewModel.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant
{


    public class GérantMainViewModel : IViewModelBase
    {

        public Action Close;

        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;
        

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion        

        #region Commands

        private readonly RelayCommand _openAddingPlatWindow;
        public ICommand OpenAddingPlatWindow => _openAddingPlatWindow;

        private readonly RelayCommand _openAddingMenuWindow;
        public ICommand OpenAddingMenuWindow => _openAddingMenuWindow;

        private readonly RelayCommand _openDeletingMenuWindow;
        public ICommand OpenDeletingMenuWindow => _openDeletingMenuWindow;

        private readonly RelayCommand _openDeletingPlatWindow;
        public ICommand OpenDeletingPlatWindow => _openDeletingPlatWindow;

        private readonly RelayCommand _openModifyingMenuWindow;
        public ICommand OpenModifyingMenuWindow => _openModifyingMenuWindow;

        private readonly RelayCommand _openModifyingPlatWindow;
        public ICommand OpenModifyingPlatWindow => _openModifyingPlatWindow;

        private readonly RelayCommand _openModifyingMoyenDePaiementWindow;
        public ICommand OpenModifyingMoyenDePaiementWindow => _openModifyingMoyenDePaiementWindow;

        private readonly RelayCommand _openModifyingFonctionWindow;
        public ICommand OpenModifyingFonctionWindow => _openModifyingFonctionWindow;

        #endregion

        #region Data Access

        private MenuBusiness _menuBusiness;

        private PlatBusiness _platBusiness;

        private UtilisateurBusiness _utilisateurBusiness;

        private UsagerBusiness _usagerBusiness;

        #endregion

        #region ObservableCollections

        private ObservableCollection<Menu> _collectionMenu = new ObservableCollection<Menu>();
        public IEnumerable<Menu> CollectionMenus { get { return _collectionMenu; } }

        private ObservableCollection<Plat> _collectionPlat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlats { get { return _collectionPlat; } }

        private ObservableCollection<Plat> _collectionPlatOfSelectedMenu = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlatOfSelectedMenu { get { return _collectionPlatOfSelectedMenu; } }

        private ObservableCollection<Utilisateur> _collectionUtilisateur = new ObservableCollection<Utilisateur>();
        public IEnumerable<Utilisateur> CollectionUtilisateur { get { return _collectionUtilisateur; } }

        private ObservableCollection<Usager> _collectionUsager = new ObservableCollection<Usager>();
        public IEnumerable<Usager> CollectionUsager { get { return _collectionUsager; } }

        #endregion

        public GérantMainViewModel()
        {
            _menuBusiness = new MenuBusiness();
            _platBusiness = new PlatBusiness();
            _utilisateurBusiness = new UtilisateurBusiness();
            _usagerBusiness = new UsagerBusiness();


            _openDeletingMenuWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir supprimer ce menu ?", new Action(test1)), o => true);
            _openDeletingPlatWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir supprimer ce plat ?", new Action(test1)), o => true);

            _openAddingPlatWindow = new RelayCommand(() => DialogService.ShowAjoutMenuView(), o => true);
            _openAddingMenuWindow = new RelayCommand(() => DialogService.ShowAjoutPlatView(), o => true);

            _openModifyingMenuWindow = new RelayCommand(() => DialogService.ShowModifMenuView(), o => true);
            _openModifyingPlatWindow = new RelayCommand(() => DialogService.ShowModifPlatView(), o => true);

            _openModifyingMoyenDePaiementWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir modifier le moyen de paiement de " + SelectedUsager.Titre + " " + SelectedUsager.Nom + "\n" + SelectedUsager.Paiement + " => " + SelectedMoyenDePaiement, new Action(ModifyMoyenDePaiement)), o => true);
            _openModifyingFonctionWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes vous sût de vouloir changer la fonction de " + SelectedUtilisateur.Titre + " " + SelectedUtilisateur.Nom + "\n" + SelectedUtilisateur.Fonction + " => " + SelectedFonction, new Action(ModifyFonction)), o => true);

            try
            {
                foreach (Plat plat in _platBusiness.GetAllPlat())
                {
                    _collectionPlat.Add(plat);
                }

                foreach (Menu menu in _menuBusiness.GetAllMenus())
                {
                    _collectionMenu.Add(menu);
                }

                foreach (Utilisateur utilisateur in _utilisateurBusiness.GetAllUtilisateurs())
                {
                    _collectionUtilisateur.Add(utilisateur);
                }

                foreach (Usager usager in _usagerBusiness.GetAllUsagers())
                {
                    _collectionUsager.Add(usager);
                }

            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
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

        private Utilisateur _selectedUtilisateur;
        public Utilisateur SelectedUtilisateur
        {
            get { return _selectedUtilisateur; }
            set
            {
                _selectedUtilisateur = value;
                OnPropertyChanged(nameof(SelectedUtilisateur));
            }
        }


        private void ModifyMoyenDePaiement()
        {
            _usagerBusiness.ModifyMoyenDePaiement(SelectedUsager.Matricule, SelectedMoyenDePaiement);
            _collectionUsager.Clear();
            _usagerBusiness.GetAllUsagers().ForEach(u => _collectionUsager.Add(u));

        }

        private void ModifyFonction()
        {
            _utilisateurBusiness.ModifyFonction(SelectedUtilisateur.Matricule, SelectedFonction);
            _collectionUtilisateur.Clear();
            _utilisateurBusiness.GetAllUtilisateurs().ForEach(u => _collectionUtilisateur.Add(u));

        }


        private void test1()
        {
            Debug.WriteLine("test yes");
        }

        private void test2()
        {
            Debug.WriteLine("test no");
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

        private List<string> _availableMoyenDePaiement;
        public List<string> AvailableMoyenDePaiement
        {
            get
            {
                return _usagerBusiness.GetAllMoyenDePaiements();
            }
            set
            {
                _availableMoyenDePaiement = value;
                OnPropertyChanged(nameof(AvailableMoyenDePaiement));
            }
        }






        private string _selectedFonction;
        public string SelectedFonction
        {
            get { return _selectedFonction; }
            set {
                _selectedFonction = value;
                OnPropertyChanged(nameof(SelectedFonction));                
            }
        }

        private string _selectedMoyenDePaiement;
        public string SelectedMoyenDePaiement
        {
            get { return _selectedMoyenDePaiement; }
            set
            {
                _selectedMoyenDePaiement = value;
                OnPropertyChanged(nameof(SelectedMoyenDePaiement));
            }
        }




        private void UpdatePlatCollection()
        {
            _collectionPlatOfSelectedMenu.Clear();
            _platBusiness.GetPlatByMenuId(SelectedMenu.CodeMenu).ForEach(p => _collectionPlatOfSelectedMenu.Add(p));
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
                _openDeletingMenuWindow.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(SelectedMenu));
                UpdatePlatCollection();
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
                _openDeletingPlatWindow.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(SelectedPlat));
            }
        }
    }
}
