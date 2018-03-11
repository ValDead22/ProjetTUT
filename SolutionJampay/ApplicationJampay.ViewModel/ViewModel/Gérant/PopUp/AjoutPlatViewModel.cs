using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using System.Diagnostics;
using ApplicationJampay.ViewModel.Command;
using System.Windows.Input;
using ApplicationJampay.Model.Service.Dialog;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant
{
    public class AjoutPlatViewModel : IViewModelBase
    {
        #region PropertyStuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private PlatBusiness _platBusiness;

        public Action Close;

        private readonly RelayCommand _createPlatCommand;
        public ICommand CreatePlatCommand => _createPlatCommand;

        public AjoutPlatViewModel()
        {
            _platBusiness = new PlatBusiness();

            _availableCategories = _platBusiness.GetAllCategories();

            DateEffet = DateTime.Now;

            _createPlatCommand = new RelayCommand(() => { CreateNewPlat(); Messenger.Default.Send<string>("UpdatePlat"); Close(); }, o => true);
            
        }


        private void CreateNewPlat()
        {
            Plat plat = new Plat(_tarif, _dateEffet, _dateFin, _selectedCategory, _nom);

            try
            {
                _platBusiness.AddPlat(plat);
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

        private int _tarif;
        public int Tarif
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
