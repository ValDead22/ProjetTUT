using ApplicationJampay.Model.DAL.Menu;
using ApplicationJampay.Model.DAL.Plat;
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

namespace ApplicationJampay.ViewModel.ViewModel.Gérant.UserControlTab
{
    public class UserControlCafeteriaViewModel : IViewModelBase
    {
        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Collections

        private ObservableCollection<Menu> _collectionMenu = new ObservableCollection<Menu>();
        public IEnumerable<Menu> CollectionMenus { get { return _collectionMenu; } }

        private ObservableCollection<Plat> _collectionPlat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlats { get { return _collectionPlat; } }

        private ObservableCollection<Plat> _collectionPlatOfSelectedMenu = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlatOfSelectedMenu { get { return _collectionPlatOfSelectedMenu; } }

        #endregion

        #region Commands
        private readonly RelayCommand _openAddingMenuWindow;
        public ICommand OpenAddingMenuWindow => _openAddingMenuWindow;

        private readonly RelayCommand _openAddingPlatWindow;
        public ICommand OpenAddingPlatWindow => _openAddingPlatWindow;

        private readonly RelayCommand _openDeletingMenuWindow;
        public ICommand OpenDeletingMenuWindow => _openDeletingMenuWindow;

        private readonly RelayCommand _openDeletingPlatWindow;
        public ICommand OpenDeletingPlatWindow => _openDeletingPlatWindow;

        private readonly RelayCommand _openModifyingMenuWindow;
        public ICommand OpenModifyingMenuWindow => _openModifyingMenuWindow;

        private readonly RelayCommand _openModifyingPlatWindow;
        public ICommand OpenModifyingPlatWindow => _openModifyingPlatWindow;

        private readonly RelayCommand _duplicateMenuCommand;
        public ICommand DuplicateMenuCommand => _duplicateMenuCommand;

        #endregion

        private PlatBusiness _platBusiness;

        private MenuBusiness _menuBusiness;

        public UserControlCafeteriaViewModel()
        {
            _platBusiness = new PlatBusiness();
            _menuBusiness = new MenuBusiness();

            _openDeletingMenuWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir supprimer ce menu ?", new Action(DeleteMenu)), o => true);
            _openDeletingPlatWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir supprimer ce plat ?", new Action(DeletePlat)), o => true);

            _openAddingPlatWindow = new RelayCommand(() => DialogGerant.ShowAjoutMenuView(), o => true);
            _openAddingMenuWindow = new RelayCommand(() => DialogGerant.ShowAjoutPlatView(), o => true);

            _openModifyingMenuWindow = new RelayCommand(() => DialogGerant.ShowModifMenuView(), o => true);
            _openModifyingPlatWindow = new RelayCommand(() => DialogGerant.ShowModifPlatView(), o => true);

            _duplicateMenuCommand = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir dupliquer ce menu ?", new Action(DuplicateMenu)), o => true);

            Messenger.Default.Register<string>(this, (msg) => HandleMessage(msg));

            try
            {
                foreach (Plat plat in _platBusiness.GetAllPlat())
                {
                    _collectionPlat.Add(plat);
                }

                foreach (Menu menu in _menuBusiness.GetAllMenus())
                {
                    _collectionMenu.Add(menu);
                }

            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }

        }

        private void UpdateMenu()
        {
            _collectionMenu.Clear();

            try
            {
                _menuBusiness.GetAllMenus().ForEach(m => _collectionMenu.Add(m));
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void UpdatePlat()
        {
            _collectionPlat.Clear();

            try
            {
                _platBusiness.GetAllPlat().ForEach(p => _collectionPlat.Add(p));
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }


        private void HandleMessage(string msg)
        {
            switch (msg)
            {
                case "UpdateMenu":
                    UpdateMenu();
                    _collectionPlatOfSelectedMenu.Clear();
                    break;

                case "UpdatePlat":
                    UpdatePlat();
                    break;

                case "RequestSelectedMenu":
                    Messenger.Default.Send<Menu>(SelectedMenu);
                    break;
            }
        }

        private Menu _selectedMenu;
        public Menu SelectedMenu
        {
            get
            {
                return _selectedMenu;
            }
            set
            {
                _selectedMenu = value;
                OnPropertyChanged(nameof(SelectedMenu));
                if (_selectedMenu != null)
                {
                    UpdatePlatCollection();
                }
                
            }
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

        private void UpdatePlatCollection()
        {
            _collectionPlatOfSelectedMenu.Clear();

            try
            {
                _platBusiness.GetPlatByMenuId(SelectedMenu.CodeMenu ?? default(int)).ForEach(p => _collectionPlatOfSelectedMenu.Add(p));
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }

        private void DuplicateMenu()
        {
            DialogService.ShowErrorWindow("Pas encore implémenté");
        }

        private void DeleteMenu()
        {        
            try
            {
                _menuBusiness.DeleteMenu(SelectedMenu);
                _collectionMenu.Clear();
                _menuBusiness.GetAllMenus().ForEach(m => _collectionMenu.Add(m));

            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }

        }

        private void DeletePlat()
        {
            try
            {
                _platBusiness.DeletePlat(SelectedPlat);
                _collectionPlat.Clear();
                _platBusiness.GetAllPlat().ForEach(p => _collectionPlat.Add(p));

            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }

        }

    }
}
