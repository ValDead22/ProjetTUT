using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.DAL.Usager;

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
using ApplicationJampay.Model.Service.SmartCardReader;
using ApplicationJampay.Model.DAL.Utilisateur;

namespace ApplicationJampay.ViewModel.ViewModel.Caissier.UserControlFolder
{
    public class UserControlCaisserViewModel : IViewModelBase
    {
        #region Property Stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        #region Commands

        private readonly RelayCommand _openAddPlatViewCommand;
        public ICommand OpenAddPlatViewCommand => _openAddPlatViewCommand;

        private readonly RelayCommand _deleteSelectedChoosenPlat;
        public ICommand DeleteSelectedChoosenPlat => _deleteSelectedChoosenPlat;
        #endregion

        private readonly RelayCommand _cardPayCommand;
        public ICommand CardPayCommand => _cardPayCommand;




        private ObservableCollection<PlatWithQuantité> _collectionChoosenPlat = new ObservableCollection<PlatWithQuantité>();
        public IEnumerable<PlatWithQuantité> CollectionChoosenPlat { get { return _collectionChoosenPlat; } }

        private float _prixTotal = 0;

        public UserControlCaisserViewModel()
        {
            _openAddPlatViewCommand = new RelayCommand(() => AddPlat(), o => true);
            _deleteSelectedChoosenPlat = new RelayCommand(() => DeletePlat(), o => true);
            _cardPayCommand = new RelayCommand(() => PayCardReader(), o => true);


            Messenger.Default.Register<Plat>(this, (plat) => GetPlats(plat));
        }

        private PlatWithQuantité _selectedChoosenPlat;
        public PlatWithQuantité SelectedChoosenPlat
        {
            get
            {
                return _selectedChoosenPlat;
            }
            set
            {
                _selectedChoosenPlat = value;
                OnPropertyChanged(nameof(SelectedChoosenPlat));
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

        private void GetPlats(Plat plat)
        {
            foreach (PlatWithQuantité platWQ in _collectionChoosenPlat)
            {
                if (plat.CodePlat == platWQ.CodePlat)
                {
                    platWQ.Quantite++;
                    _prixTotal += plat.Prix ?? default(float);
                    Prix = _prixTotal.ToString() + " €";
                    return;
                }
            }
            _collectionChoosenPlat.Add(new PlatWithQuantité(plat.CodePlat, plat.DateEffet, plat.DateFin, plat.Categorie, plat.Nom, 1, plat.Prix));
            _prixTotal += plat.Prix ?? default(float);
            Prix = _prixTotal.ToString() + " €";

        }

        private void DeletePlat()
        {
            _prixTotal = _prixTotal - (SelectedChoosenPlat.Prix ?? default(float));
            Prix = _prixTotal.ToString() + " €";

            if (SelectedChoosenPlat.Quantite != 1)
            {
                SelectedChoosenPlat.Quantite--;
            }
            else
            {
                _collectionChoosenPlat.Remove(SelectedChoosenPlat);
            }

        }

        public void AddPlat()
        {
            DialogCaissier.ShowAjouterPlatWindow();
        }

        private void PayCardReader()
        {

            UsagerBusiness _usagerBusiness = new UsagerBusiness();
            int idUser = ManageDataCardService.GetCodeUser();

            _usagerBusiness.Pay(idUser, _prixTotal);

            Messenger.Default.Send<string>("EditTicketUserControl");



        }
    }
}
