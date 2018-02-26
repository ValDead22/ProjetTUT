using ApplicationJampay.Model.DAL.Usager;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant.UserControlTab
{
    public class UserControlUsagerViewModel : IViewModelBase
    {
        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private ObservableCollection<Usager> _collectionUsager = new ObservableCollection<Usager>();
        public IEnumerable<Usager> CollectionUsager { get { return _collectionUsager; } }

        private readonly RelayCommand _openModifyingMoyenDePaiementWindow;
        public ICommand OpenModifyingMoyenDePaiementWindow => _openModifyingMoyenDePaiementWindow;

        private UsagerBusiness _usagerBusiness;

        public UserControlUsagerViewModel()
        {
            _usagerBusiness = new UsagerBusiness();
            

            _availableMoyenDePaiement = _usagerBusiness.GetAllMoyenDePaiements();

            _openModifyingMoyenDePaiementWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir modifier le moyen de paiement de " + SelectedUsager.Titre + " " + SelectedUsager.Nom + "\n" + SelectedUsager.Paiement + " => " + SelectedMoyenDePaiement, new Action(ModifyMoyenDePaiement)), o => true);

            try
            {
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

        private List<string> _availableMoyenDePaiement;
        public List<string> AvailableMoyenDePaiement
        {
            get
            {
                return _availableMoyenDePaiement;
            }
            set
            {
                _availableMoyenDePaiement = value;
                OnPropertyChanged(nameof(AvailableMoyenDePaiement));
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

        private void ModifyMoyenDePaiement()
        {
            _usagerBusiness.ModifyMoyenDePaiement(SelectedUsager.Matricule, SelectedMoyenDePaiement);
            _collectionUsager.Clear();
            _usagerBusiness.GetAllUsagers().ForEach(u => _collectionUsager.Add(u));

        }

    }
}
