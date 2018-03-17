using ApplicationJampay.Model.DAL.Commande;
using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.Model.DAL.Usager;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Caissier.UserControlFolder
{
    public class UserControlFactureViewModel : IViewModelBase
    {
        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private PlatBusiness _platBusiness;
        private CommandeBusiness _commandeBusiness;

        private RelayCommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand;

        private ObservableCollection<Commande> _collectionCommande = new ObservableCollection<Commande>();
        public IEnumerable<Commande> CollectionCommande { get { return _collectionCommande; } }

        private ObservableCollection<Plat> _collectionPlatOfSelectedCommande = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlatOfSelectedCommande { get { return _collectionPlatOfSelectedCommande; } }

        public UserControlFactureViewModel()
        {
            _commandeBusiness = new CommandeBusiness();
            _platBusiness = new PlatBusiness();

            _deleteCommand = new RelayCommand(() => DeletePlatFromCommande(), o => true);

            try
            {
                foreach(Commande c in _commandeBusiness.GetAllCommandes())
                {
                    _collectionCommande.Add(c);
                }
            }
            catch (Exception ex )
            {

                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private Commande _selectedCommande;
        public Commande SelectedCommande
        {
            get { return _selectedCommande; }
            set
            {
                _selectedCommande = value;
                OnPropertyChanged(nameof(SelectedCommande));
                if (_selectedCommande != null)
                {
                    UpdatePlatCollection(); 
                }


            }
        }

        private void DeletePlatFromCommande()
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
                _platBusiness.DeletePlatFromCommande(SelectedCommande, SelectedPlat);

                float newMontant = SelectedCommande.PrixTotal - SelectedPlat.Prix;

                _commandeBusiness.SetMontantCommande(SelectedCommande, newMontant);
                UpdateCommandeCollection();
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private Plat _selectedPlat;
        public Plat SelectedPlat
        {
            get { return _selectedPlat; }
            set { _selectedPlat = value;
                OnPropertyChanged(nameof(SelectedPlat));
            }
        }


        private void UpdatePlatCollection()
        {
            _collectionPlatOfSelectedCommande.Clear();
            try
            {
                _platBusiness.GetPlatByCodeCommande(SelectedCommande).ForEach(p => _collectionPlatOfSelectedCommande.Add(p));
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void UpdateCommandeCollection()
        {
            _collectionPlatOfSelectedCommande.Clear();
            _collectionCommande.Clear();
            try
            {
                _commandeBusiness.GetAllCommandes().ForEach(c => _collectionCommande.Add(c));
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

    }
}
