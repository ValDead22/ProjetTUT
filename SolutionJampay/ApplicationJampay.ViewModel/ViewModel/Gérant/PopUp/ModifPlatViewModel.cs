using ApplicationJampay.Model.DAL.Plat;
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

        public Action Close;

        private Plat ModifyedPlat;

        private readonly RelayCommand _createplatCommand;
        public ICommand CreateplatCommand => _createplatCommand;

        public ModifPlatViewModel()
        {
            Messenger.Default.Register<Plat>(this, (plat) => HandleMessage(plat));
            Messenger.Default.Send<string>("RequestSelectedPlat");

            _platBusiness = new PlatBusiness();
            _createplatCommand = new RelayCommand(() => { CreateNewplat(); Close(); }, o => true);

            Nom = ModifyedPlat.Nom;
            DateEffet = ModifyedPlat.DateEffet;
            DateFin = ModifyedPlat.DateFin;
            Tarif = ModifyedPlat.Prix ?? default(float);


            try
            {
                _availableCategories = _platBusiness.GetAllCategories();
            }
            catch (Exception ex)
            {

                DialogService.ShowErrorWindow(ex.Message);
            }

        }

        private void HandleMessage(Plat plat)
        {
            ModifyedPlat = plat;
        }



        private void CreateNewplat()
        {
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
