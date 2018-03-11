using ApplicationJampay.Model.DAL.Menu;
using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.Model.DAL.Utilisateur;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service.Dialog;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant.PopUp
{
    public class ModifMenuViewModel : IViewModelBase
    {
        #region PropertyStuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



        private ObservableCollection<Plat> _collectionSelectedPat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionSelectedPat { get { return _collectionSelectedPat; } }

        private ObservableCollection<Plat> _collectionAvalaiblePat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionAvalaiblePat { get { return _collectionAvalaiblePat; } }

        private Menu ModifyedMenu;

        private MenuBusiness _menuBusiness;
        private UtilisateurBusiness _utilisateurBusiness;
        private PlatBusiness _platBusiness;

        public ModifMenuViewModel()
        {
            Messenger.Default.Register<Menu>(this, (menu) => HandleMessage(menu));
            Messenger.Default.Send<string>("RequestSelectedMenu");

            Nom = ModifyedMenu.Nom;
            DateElaboration = ModifyedMenu.DateElaboration;
            Observation = ModifyedMenu.Observation;

            _menuBusiness = new MenuBusiness();
            _utilisateurBusiness = new UtilisateurBusiness();
            _platBusiness = new PlatBusiness();



            try {


                List<Plat> list = new List<Plat>();
                list.AddRange(_platBusiness.GetAllPlat().Except(ModifyedMenu.ListPLats));

                foreach (Plat p  in list)
                {
                    _collectionAvalaiblePat.Add(p);
                }
                _availableCategories = _menuBusiness.GetAllCategories();
                _avalaibleGerant = _utilisateurBusiness.GetUtilisateursByFonction("Gérant");

            }
            catch (Exception ex)
            {

                DialogService.ShowErrorWindow(ex.Message);
            }

            foreach (Plat p in ModifyedMenu.ListPLats)
            {
                _collectionSelectedPat.Add(p);
            }

        }


        private Plat _selectedFromSelectedPlat;
        public Plat SelectedFromSelectedPlat
        {
            get { return _selectedFromSelectedPlat; }
            set { _selectedFromSelectedPlat = value;
                OnPropertyChanged(nameof(SelectedFromSelectedPlat));
            }
        }

        private Plat _selectedFromAvalaiblePlat;
        public Plat SelectedFromAvalaiblePlat
        {
            get { return _selectedFromAvalaiblePlat; }
            set
            {
                _selectedFromAvalaiblePlat = value;
                OnPropertyChanged(nameof(SelectedFromAvalaiblePlat));
            }
        }


        private void HandleMessage(Menu menu)
        {
            ModifyedMenu = menu;
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }

        private DateTime _dateElaboration;
        public DateTime DateElaboration
        {
            get { return _dateElaboration; }
            set
            {
                _dateElaboration = value;
                OnPropertyChanged(nameof(DateElaboration));
            }
        }

        private string _observation;
        public string Observation
        {
            get { return _observation; }
            set
            {
                _observation = value;
                OnPropertyChanged(nameof(Observation));
            }
        }


        private List<string> _availableCategories;
        public List<string> AvailableCategories
        {
            get { return _availableCategories; }
            set
            {
                _availableCategories = value;
                OnPropertyChanged(nameof(AvailableCategories));
            }
        }


        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        

        private List<Utilisateur> _avalaibleGerant;
        public List<Utilisateur> AvalaibleGerant
        {
            get { return _avalaibleGerant; }
            set
            {
                _avalaibleGerant = value;
                OnPropertyChanged(nameof(AvalaibleGerant));
            }
        }

        private Utilisateur _selectedGerant;
        public Utilisateur SelectedGerant
        {
            get { return _selectedGerant; }
            set
            {
                _selectedGerant = value;
                OnPropertyChanged(nameof(SelectedGerant));
            }
        }

    }
}
