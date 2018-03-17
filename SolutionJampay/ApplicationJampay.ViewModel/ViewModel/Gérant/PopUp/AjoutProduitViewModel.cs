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
    public class AjoutProduitViewModel : IViewModelBase
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

        private readonly RelayCommand _createProduitCommand;
        public ICommand CreateProduitCommand => _createProduitCommand;

        public AjoutProduitViewModel()
        {
            _produitBusiness = new ProduitBusiness();

            try
            {
                _availableCategories = _produitBusiness.GetAllCategories();
            }
            catch (Exception ex)
            {

                DialogService.ShowErrorWindow(ex.Message);
            }

            DateEffet = DateTime.Now;

            _createProduitCommand = new RelayCommand(() => { CreateNewPlat(); Messenger.Default.Send<string>("UpdateProduit"); Close(); }, o => true);

        }


        private void CreateNewPlat()
        {
            Produit produit = new Produit(0, _dateEffet, _dateFin, _selectedCategory, _nom, _observation);

            try
            {
                _produitBusiness.AddProduit(produit);
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
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
