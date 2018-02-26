using ApplicationJampay.Model.DAL.Utilisateur;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Caissier
{
    public class CaissierViewModel : IViewModelBase
    {
        #region Property Stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
        

        private ObservableCollection<Plat> _collectionPlat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlat { get { return _collectionPlat; } }

        
        public CaissierViewModel()
        {
            _openAddPlatViewCommand = new RelayCommand(() => AddPlat(), o => true);

            Messenger.Default.Register<Plat>(this, HandleMessage);
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

        private void HandleMessage(Plat plat)
        {
            //Debug.WriteLine(plat.ToString());
        }

        private readonly RelayCommand _openAddPlatViewCommand;
        public ICommand OpenAddPlatViewCommand => _openAddPlatViewCommand;
        

        public void AddPlat()
        {
            DialogCaissier.ShowAjouterPlatWindow();
        }
    }
}
      

        



    
    


