﻿using ApplicationJampay.Model.DAL.Menu;
using ApplicationJampay.Model.Service.Dialog;
using ApplicationJampay.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel.Gérant
{
    public class AjoutMenuViewModel : IViewModelBase
    {
        #region PropertyStuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

       
        private MenuBusiness _menuBusiness;

        public Action Close;

        private readonly RelayCommand _createMenuCommand;
        public ICommand CreateMenuCommand => _createMenuCommand;

        public AjoutMenuViewModel()
        {
            _menuBusiness = new MenuBusiness();

            _availableCategories = _menuBusiness.GetAllCategories();

            _createMenuCommand = new RelayCommand(() => { CreateNewMenu(); Close(); }, o => true);

        }


        private void CreateNewMenu()
        {
            Model.Entity.Menu menu = new Model.Entity.Menu(_idGérant, _dateElaboration, _selectedCategory, _nom, _observation);

            try
            {
                _menuBusiness.AddMenu(menu);
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }


        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }

        private int _idGérant;
        public int IDGérant
        {
            get { return _idGérant; }
            set
            {
                _idGérant = value;
                OnPropertyChanged(nameof(IDGérant));
            }
        }

        private DateTime _dateElaboration;
        public DateTime DateElaboration
        {
            get { return _dateElaboration; }
            set
            {
                _dateElaboration = value;
                OnPropertyChanged(nameof(DateElaboration));
            }
        }

        private string _observation;
        public string Observation
        {
            get { return _observation; }
            set
            {
                _observation = value;
                OnPropertyChanged(nameof(Observation));
            }
        }


        private List<string> _availableCategories;
        public List<string> AvailableCategories
        {
            get { return _availableCategories; }
            set
            {
                _availableCategories = value;
                OnPropertyChanged(nameof(AvailableCategories));
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        
    }
}
