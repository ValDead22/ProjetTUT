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
        

        private ObservableCollection<PlatWithQuantité> _choosenPlat = new ObservableCollection<PlatWithQuantité>();
        public IEnumerable<PlatWithQuantité> ChoosenPlat { get { return _choosenPlat; } }

        private float _prixTotal = 0;
        
        public CaissierViewModel()
        {
            _openAddPlatViewCommand = new RelayCommand(() => AddPlat(), o => true);

            Messenger.Default.Register<Plat>(this, (plat) => HandleMessage(plat));
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

        private string _prix;
        public string Prix
        {
            get
            {
                return _prix;
            }
            set
            {
                _prix = value;
                OnPropertyChanged(nameof(Prix));
            }
        }

        private void HandleMessage(Plat plat)
        {
            foreach(PlatWithQuantité platWQ in _choosenPlat)
            {
                if(plat.CodePlat == platWQ.CodePlat)
                {
                    platWQ.Quantite++;
                    _prixTotal += plat.Prix ?? default(float);
                    Prix = _prixTotal.ToString() + " €";
                    return;
                }
            }
            _choosenPlat.Add(new PlatWithQuantité(plat.CodePlat, plat.DateEffet, plat.DateFin, plat.Categorie, plat.Nom, 1));
            _prixTotal += plat.Prix ?? default(float);
            Prix = _prixTotal.ToString() + " €";

        }

        private readonly RelayCommand _openAddPlatViewCommand;
        public ICommand OpenAddPlatViewCommand => _openAddPlatViewCommand;
        

        public void AddPlat()
        {
            DialogCaissier.ShowAjouterPlatWindow();
        }
    }
}
      

        



    
    


