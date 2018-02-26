using ApplicationJampay.Model.Service;
using ApplicationJampay.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.DAL;
using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.Model.Service.Dialog;
using GalaSoft.MvvmLight.Messaging;

namespace ApplicationJampay.ViewModel.ViewModel.Caissier
{
    public class AjouterPlatViewModel : IViewModelBase
    {

        #region Property stuff
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
        #endregion

        private PlatBusiness _platBusiness;

        public Action Close;

        private ObservableCollection<Plat> _coollectionOfSelectedCateg = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionOfSelectedCateg { get { return _coollectionOfSelectedCateg; } }

        public AjouterPlatViewModel()
        {
            _platBusiness = new PlatBusiness();

            _displayPlatCommand = new RelayCommand(() => Plats(), o => true);
            _displayEntreeCommand = new RelayCommand(() => Entrees(), o => true);
            _displayDessertCommand = new RelayCommand(() => Desserts(), o => true);
            _displaySnackCommand = new RelayCommand(() => Snacks(), o => true);

            _validateCommand = new RelayCommand(() => AddPLatToCommande(), o => true);

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

        private void AddPLatToCommande()
        {
            Messenger.Default.Send<Plat>(SelectedPlat);
            Close();

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

    }

}

