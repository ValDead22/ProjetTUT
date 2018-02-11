﻿using ApplicationJampay.Model.DAL.Menu;
using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using ApplicationJampay.ViewModel.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant
{


    public class GérantMainViewModel : IViewModelBase
    {

        #region Property stuff
        public event PropertyChangedEventHandler PropertyChanged;

        

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public Action Close;

        private readonly RelayCommand _openAddingPlatWindow;
        public ICommand OpenAddingPlatWindow => _openAddingPlatWindow;

        private readonly RelayCommand _openAddingMenuWindow;
        public ICommand OpenAddingMenuWindow => _openAddingMenuWindow;

        private readonly RelayCommand _openDeletingMenuWindow;
        public ICommand OpenDeletingMenuWindow => _openDeletingMenuWindow;

        private readonly RelayCommand _openDeletingPlatWindow;
        public ICommand OpenDeletingPlatWindow => _openDeletingPlatWindow;

        /// <summary>
        /// Logic to access to the Menus data
        /// </summary>
        private MenuBusiness _menuBusiness;
        /// <summary>
        /// Logic to access to the PLats data
        /// </summary>
        private PlatBusiness _platBusiness;

        #region ObservableCollections

        private ObservableCollection<Menu> _collectionMenu = new ObservableCollection<Menu>();
        public IEnumerable<Menu> CollectionMenus { get { return _collectionMenu; } }

        private ObservableCollection<Plat> _collectionPlat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlats { get { return _collectionPlat; } }

        private ObservableCollection<Plat> _collectionPlatOfSelectedMenu = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlatOfSelectedMenu { get { return _collectionPlatOfSelectedMenu; } }

        #endregion

        public GérantMainViewModel()
        {
            _menuBusiness = new MenuBusiness();
            _platBusiness = new PlatBusiness();

            _openDeletingMenuWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir supprimer ce menu ?", new Action(test1)), o => _selectedMenu != null);
            _openDeletingPlatWindow = new RelayCommand(() => DialogService.ShowYesNoWindow("Etes-vous sûr de vouloir supprimer ce plat ?", new Action(test1)), o => _selectedPlat != null );

            _openAddingPlatWindow = new RelayCommand(() => DialogService.ShowAjoutMenuView(), o => true);
            _openAddingMenuWindow = new RelayCommand(() => DialogService.ShowAjoutPlatView(), o => true);

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


        private void test1()
        {
            Debug.WriteLine("test yes");
        }

        private void test2()
        {
            Debug.WriteLine("test no");
        }





        private void UpdatePlatCollection()
        {
            _collectionPlatOfSelectedMenu.Clear();
            _platBusiness.GetPlatByMenuId(SelectedMenu.CodeMenu).ForEach(p => _collectionPlatOfSelectedMenu.Add(p));
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
                _openDeletingMenuWindow.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(SelectedMenu));
                UpdatePlatCollection();
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
                _openDeletingPlatWindow.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(SelectedPlat));
            }
        }
    }
}
