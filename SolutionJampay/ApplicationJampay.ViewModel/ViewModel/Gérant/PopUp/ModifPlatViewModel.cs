using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.Model.DAL.Produit;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant
{
    public class ModifPlatViewModel : IViewModelBase
    {
        #region PropertyStuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private PlatBusiness _platBusiness;
        private ProduitBusiness _produitBusiness;

        public Action Close;

        private Plat ModifyedPlat;

        private readonly RelayCommand _addProduit;
        public ICommand AddProduit => _addProduit;

        private readonly RelayCommand _deleteProduit;
        public ICommand DeleteProduit => _deleteProduit;

        private readonly RelayCommand _apply;
        public ICommand Apply => _apply;




        private ObservableCollection<Produit> _collectionAvalaibleProduit = new ObservableCollection<Produit>();
        public IEnumerable<Produit> CollectionAvalaibleProduit { get { return _collectionAvalaibleProduit; } }

        private ObservableCollection<Produit> _collectionSelectedProduit = new ObservableCollection<Produit>();
        public IEnumerable<Produit> CollectionSelectedProduit { get { return _collectionSelectedProduit; } }

        public ModifPlatViewModel()
        {
            Messenger.Default.Register<Plat>(this, (plat) => HandleMessage(plat));
            Messenger.Default.Send<string>("RequestSelectedPlat");

            _platBusiness = new PlatBusiness();
            _produitBusiness = new ProduitBusiness();

            _deleteProduit = new RelayCommand(() => { DeleteProduitFromPlat(); }, o => true);
            _addProduit = new RelayCommand(() => { AddMewProduitToPlat(); }, o => true);
            _apply = new RelayCommand(() => { Modify(); Messenger.Default.Send<string>("UpdatePlat"); Close(); }, o => true);


            Nom = ModifyedPlat.Nom;
            DateEffet = ModifyedPlat.DateEffet;
            DateFin = ModifyedPlat.DateFin;
            Tarif = ModifyedPlat.Prix;


            try
            {
                _availableCategories = _platBusiness.GetAllCategories();

                foreach (Produit p in ModifyedPlat.ListProduits)
                {
                    _collectionSelectedProduit.Add(p);
                }

                List<Produit> list = new List<Produit>();
                list.AddRange(_produitBusiness.GetAllProduits().Except(ModifyedPlat.ListProduits));

                foreach (Produit p in list)
                {
                    _collectionAvalaibleProduit.Add(p);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }

        }

        private void Modify()
        {
            Plat plat = new Plat(ModifyedPlat.CodePlat, DateEffet, DateEffet, SelectedCategory, Nom, Tarif);
            try
            {
                _platBusiness.ModifyPlat(plat);
                _platBusiness.DeleteProduitOfPlat(plat);

                foreach (Produit p in _collectionSelectedProduit)
                {
                    _platBusiness.AddProduitToPlat(plat, p);
                }

            }
            catch (Exception ex)
            {

                DialogService.ShowErrorWindow(ex.Message);
            }

            Messenger.Default.Send<string>("UpdateMenu");
        }

        private void HandleMessage(Plat plat)
        {
            ModifyedPlat = plat;
        }

        private Produit _selectedFromSelectedProduit;
        public Produit SelectedFromSelectedProduit
        {
            get { return _selectedFromSelectedProduit; }
            set
            {
                _selectedFromSelectedProduit = value;
                OnPropertyChanged(nameof(SelectedFromSelectedProduit));
            }
        }

        private Produit _selectedFromAvalaibleProduit;
        public Produit SelectedFromAvalaibleProduit
        {
            get { return _selectedFromAvalaibleProduit; }
            set
            {
                _selectedFromAvalaibleProduit = value;
                OnPropertyChanged(nameof(SelectedFromAvalaibleProduit));
            }
        }


        private void AddMewProduitToPlat()
        {
            _collectionSelectedProduit.Add(_selectedFromAvalaibleProduit);
            _collectionAvalaibleProduit.Remove(_selectedFromAvalaibleProduit);
        }

        private void DeleteProduitFromPlat()
        {
            _collectionAvalaibleProduit.Add(_selectedFromSelectedProduit);
            _collectionSelectedProduit.Remove(_selectedFromSelectedProduit);
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

        private DateTime _dateEffet;
        public DateTime DateEffet
        {
            get { return _dateEffet; }
            set
            {
                _dateEffet = value;
                OnPropertyChanged(nameof(DateEffet));
            }
        }

        private DateTime _dateFin;
        public DateTime DateFin
        {
            get { return _dateFin; }
            set
            {
                _dateFin = value;
                OnPropertyChanged(nameof(DateFin));
            }
        }

        private float _tarif;
        public float Tarif
        {
            get { return _tarif; }
            set
            {
                _tarif = value;
                OnPropertyChanged(nameof(Tarif));
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

       

    }
}
