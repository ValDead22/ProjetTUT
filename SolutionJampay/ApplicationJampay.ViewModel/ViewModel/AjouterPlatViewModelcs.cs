using ApplicationJampay.Model.Service;
using ApplicationJampay.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.DAL;
using ApplicationJampay.Model.DAL.Plat;

namespace ApplicationJampay.ViewModel.ViewModel
{
    public class AjouterPlatViewModel : IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PlatBusiness _platBusiness;


        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public AjouterPlatViewModel()
        {
            _platBusiness = new PlatBusiness();

            _displayPlatCommand = new RelayCommand(() => Plats(), o => true);
            _displayEntreeCommand = new RelayCommand(() => Entrees(), o => true);
            _displayDessertCommand = new RelayCommand(() => Desserts(), o => true);
            _displaySnackCommand = new RelayCommand(() => Snacks(), o => true);

        }
        private readonly RelayCommand _displayPlatCommand;
        public ICommand DisplayPlatViewCommand => _displayPlatCommand;

        private readonly RelayCommand _displayEntreeCommand;
        public ICommand DisplayEntreeViewCommand => _displayEntreeCommand;

        private readonly RelayCommand _displayDessertCommand;
        public ICommand DisplayDessertViewCommand => _displayDessertCommand;

        private readonly RelayCommand _displaySnackCommand;
        public ICommand DisplaySnackViewCommand => _displaySnackCommand;



        private ObservableCollection<Plat> _coollectionOfSelectedCateg = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionOfSelectedCateg { get { return _coollectionOfSelectedCateg; } }





        public void Plats()
        {
            _coollectionOfSelectedCateg.Clear();

            List<Plat> listPlats = new List<Plat>();
            listPlats = _platBusiness.GetPlatbyCateg("Plat");

            foreach(Plat plat in listPlats)
            {
                _coollectionOfSelectedCateg.Add(plat);
            }

        }

        public void Entrees()
       {
            _coollectionOfSelectedCateg.Clear();

            List<Plat> listEntrees = new List<Plat>();

            listEntrees = _platBusiness.GetPlatbyCateg("Entree");

            foreach (Plat entree in listEntrees)
            {
                _coollectionOfSelectedCateg.Add(entree);
            }
        }

        public void Desserts()
        {

            _coollectionOfSelectedCateg.Clear();
            List<Plat> listDesserts = new List<Plat>();

            listDesserts = _platBusiness.GetPlatbyCateg("Dessert");

            foreach (Plat dessert in listDesserts)
            {
                _coollectionOfSelectedCateg.Add(dessert);
            }



        }

        public void Snacks()
        {

            _coollectionOfSelectedCateg.Clear();

            List<Plat> listSnacks = new List<Plat>();

            listSnacks = _platBusiness.GetPlatbyCateg("Snack");

            foreach (Plat snack in listSnacks)
            {
                _coollectionOfSelectedCateg.Add(snack);
            }

        }

    }

}

