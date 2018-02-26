using ApplicationJampay.Model.DAL.Utilisateur;
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

namespace ApplicationJampay.ViewModel.ViewModel.Caissier
{
    public class CaissierViewModel : IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //List implémente IEnumerable, pas de sousses

        private ObservableCollection<Plat> _collectionPlat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlat { get { return _collectionPlat; } }





        public CaissierViewModel()
        {

            _openAddPlatViewCommand = new RelayCommand(() => AddPlat(), o => true);
           


        }

        private Plat _platService;
        //Table sélectionnée dans la ListView
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
                //Mettre à jour le canExecute de la fenêtre
                _openModifyPlatViewCommand.RaiseCanExecuteChanged();
                _openRemovePlatViewCommand.RaiseCanExecuteChanged();
            }
        }

        //Table créée
        private Plat _newPlat;
        public Plat NewPlat
        {
            get { return _newPlat; }
            set { _newPlat = value; }
        }


        public RelayCommand AjoutP { get; private set; }
        public RelayCommand Reglement { get; private set; }

        private readonly RelayCommand _openAddPlatViewCommand;
        public ICommand OpenAddPlatViewCommand => _openAddPlatViewCommand;

        private readonly RelayCommand _openCreatePlatViewCommand;
        public ICommand OpenCreatePlatViewCommand => _openCreatePlatViewCommand;

        //Commande pour ouvrir la fenêtre de suppression
        private readonly RelayCommand _openRemovePlatViewCommand;
        public ICommand OpenRemoveTableViewCommand => _openRemovePlatViewCommand;

        //Commande pour ouvrir la fenêtre de modification
        private readonly RelayCommand _openModifyPlatViewCommand;
        public ICommand OpenModifyTableViewCommand => _openModifyPlatViewCommand;

        //Commande pour modifier une table
        private readonly RelayCommand _modifyPlatComand;
        public ICommand ModifyTableCommand => _modifyPlatComand;

        //Commande pour supprimer une table
        private readonly RelayCommand _deletePlatComand;
        public ICommand DeleteTableCommand => _deletePlatComand;

        //Commande pour annuler une suppression
        private readonly RelayCommand _cancelDeletePlatComand;
        public ICommand CancelDeleteTableCommand => _cancelDeletePlatComand;




        public void AddPlat()
        {

            DialogCaissier.ShowAjouterPlatWindow();

        }
    }
}
      

        



    
    


