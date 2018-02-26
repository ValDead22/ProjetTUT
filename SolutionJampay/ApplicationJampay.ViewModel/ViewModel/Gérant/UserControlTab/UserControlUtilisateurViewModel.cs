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

namespace ApplicationJampay.ViewModel.ViewModel.Gérant.UserControlTab
{
    public class UserControlUtilisateurViewModel : IViewModelBase
    {
        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private ObservableCollection<Utilisateur> _collectionUtilisateur = new ObservableCollection<Utilisateur>();
        public IEnumerable<Utilisateur> CollectionUtilisateur { get { return _collectionUtilisateur; } }



        #region Commands

        private readonly RelayCommand _openModifyingFonctionWindow;
        public ICommand OpenModifyingFonctionWindow => _openModifyingFonctionWindow;

        private readonly RelayCommand _openDeletingUtilisateurWindow;
        public ICommand OpenDeletingUtilisateurWindow => _openDeletingUtilisateurWindow;

        private readonly RelayCommand _openAddingUtilisateurWindow;
        public ICommand OpenAddingUtilisateurWindow => _openAddingUtilisateurWindow;

        #endregion

        private UtilisateurBusiness _utilisateurBusiness;

        public UserControlUtilisateurViewModel()
        {
            _utilisateurBusiness = new UtilisateurBusiness();

            _avalaibleFonction = _utilisateurBusiness.GetAllFonctions();

            _openAddingUtilisateurWindow = new RelayCommand(() => DialogGerant.ShowAjoutUtilisateurView(), o => true);
            _openModifyingFonctionWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes vous sût de vouloir changer la fonction de " + SelectedUtilisateur.Titre + " " + SelectedUtilisateur.Nom + "\n" + SelectedUtilisateur.Fonction + " => " + SelectedFonction, new Action(ModifyFonction)), o => true);
            _openDeletingUtilisateurWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir supprimer cet Utilisateur ?", DeleteUtilisateur), o => true);

            try
            {
                foreach (Utilisateur utilisateur in _utilisateurBusiness.GetAllUtilisateurs())
                {
                    _collectionUtilisateur.Add(utilisateur);
                }
            }
            catch (Exception ex)
            {

                DialogService.ShowErrorWindow(ex.Message);
            }
        }
        private Utilisateur _selectedUtilisateur;
        public Utilisateur SelectedUtilisateur
        {
            get { return _selectedUtilisateur; }
            set
            {
                _selectedUtilisateur = value;
                OnPropertyChanged(nameof(SelectedUtilisateur));
            }
        }

        private string _selectedFonction;
        public string SelectedFonction
        {
            get { return _selectedFonction; }
            set
            {
                _selectedFonction = value;
                OnPropertyChanged(nameof(SelectedFonction));
            }
        }

        private List<string> _avalaibleFonction;
        public List<string> AvalaibleFonction
        {
            get
            {
                return _avalaibleFonction;
            }
            set
            {
                _avalaibleFonction = value;
                OnPropertyChanged(nameof(AvalaibleFonction));
            }
        }

        private void ModifyFonction()
        {
            _utilisateurBusiness.ModifyFonction(SelectedUtilisateur.Matricule, SelectedFonction);
            _collectionUtilisateur.Clear();
            _utilisateurBusiness.GetAllUtilisateurs().ForEach(u => _collectionUtilisateur.Add(u));

        }

        private void DeleteUtilisateur()
        {
            _utilisateurBusiness.DeleteUtilisateur(SelectedUtilisateur.Matricule);
            _collectionUtilisateur.Clear();
            _utilisateurBusiness.GetAllUtilisateurs().ForEach(u => _collectionUtilisateur.Add(u));

        }
    }
}
