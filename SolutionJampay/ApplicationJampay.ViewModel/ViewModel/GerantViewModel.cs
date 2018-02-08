using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.DAL;
using ApplicationJampay.Model.DAL.Menu;
using ApplicationJampay.Model.Service;
using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.ViewModel.Command;
using System.Windows.Input;

namespace ApplicationJampay.ViewModel.ViewModel
{
    public class GerantViewModel : IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private MenuBusiness _menuBusiness;
        private PlatBusiness _platBusiness;

        private readonly RelayCommand _selectionChanged;
        public ICommand SelectionChanged => _selectionChanged;

        private ObservableCollection<Menu> _collectionMenu = new ObservableCollection<Menu>();
        public IEnumerable<Menu> CollectionMenus { get { return _collectionMenu; } }
       
        private ObservableCollection<Plat> _collectionPlat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlats { get { return _collectionPlat; } }

        public GerantViewModel()
        {
            _menuBusiness = new MenuBusiness();
            _platBusiness = new PlatBusiness();

            _selectionChanged = new RelayCommand(() => UpdatePlatCollection(), o => true);

            try
            {
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

        private void UpdatePlatCollection()
        {
            _collectionPlat.Clear();
            _platBusiness.GetPlatByMenuId(SelectedMenu.CodeMenu).ForEach(p => _collectionPlat.Add(p));
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
                UpdatePlatCollection();
            }
        }
    }
}
