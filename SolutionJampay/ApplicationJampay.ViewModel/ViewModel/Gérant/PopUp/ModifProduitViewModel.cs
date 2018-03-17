using ApplicationJampay.Model.DAL.Produit;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant.PopUp
{
    public class ModifProduitViewModel : IViewModelBase
    {
        #region PropertyStuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        
        private ProduitBusiness _produitBusiness;

        public Action Close;

        private Produit ModifyedProduit;

        private readonly RelayCommand _apply;
        public ICommand Apply => _apply;

        

        public ModifProduitViewModel()
        {
            Messenger.Default.Register<Produit>(this, (produit) => HandleMessage(produit));
            Messenger.Default.Send<string>("RequestSelectedProduit");
            
            _produitBusiness = new ProduitBusiness();
            
            _apply = new RelayCommand(() => { Modify(); Messenger.Default.Send<string>("UpdateProduit"); Close(); }, o => true);

            _availableCategories = _produitBusiness.GetAllCategories();

            Nom = ModifyedProduit.Nom;
            DateEffet = ModifyedProduit.DateEffet;
            DateFin = ModifyedProduit.DateFin;
            Observation = ModifyedProduit.Observation;

            

        }

        private void Modify()
        {
            Produit produt = new Produit(ModifyedProduit.CodeProduit, DateEffet, DateEffet, SelectedCategory, Nom, Observation);
            try
            {
                _produitBusiness.ModifyProduit(produt);

            }
            catch (Exception ex)
            {

                DialogService.ShowErrorWindow(ex.Message);
            }
            
        }

        private void HandleMessage(Produit produit)
        {
            ModifyedProduit = produit;
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
    }
}
