using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using ApplicationJampay.Model.Entity;

namespace ApplicationJampay.ViewModel.ViewModel
{
    public class GerantViewModel : IViewModelBase
    {

        public GerantViewModel()
        {
            _collectionMenu.Add(new Menu(111, 222, new DateTime(2018, 01, 29), "entrée", "macédoine", "viable"));
            _collectionPlat.Add(new Plat(3553, new DateTime(2018, 01, 29), new DateTime(2018, 02, 5), "skfds", "Frites"));
        }

        

        private ObservableCollection<Menu> _collectionMenu = new ObservableCollection<Menu>();
        private ObservableCollection<Plat> _collectionPlat = new ObservableCollection<Plat>();

        public IEnumerable<Menu> CollectionMenus { get { return _collectionMenu; } }
        public IEnumerable<Plat> CollectionPlats { get { return _collectionPlat; } }

        public event PropertyChangedEventHandler PropertyChanged;

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


        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    
    

}
