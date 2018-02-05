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

namespace ApplicationJampay.ViewModel.ViewModel
{
        public class AjouterPlatViewModel : IViewModelBase
        {
            public event PropertyChangedEventHandler PropertyChanged;

        

        void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

           

            public AjouterPlatViewModel()
            {

                _openPlatViewCommand = new RelayCommand(() => Plats(), o => true);
                _openEntreeViewCommand = new RelayCommand(() => Entrees(), o => true);
                _openDessertViewCommand = new RelayCommand(() => Desserts(), o => true);
                _openSnackViewCommand = new RelayCommand(() => Snacks(), o => true);



        }

           

         
            


            public RelayCommand Plat { get; private set; }
            public RelayCommand Entree { get; private set; }
            public RelayCommand Dessert{ get; private set; }
            public RelayCommand Snack { get; private set; }

            private readonly RelayCommand _openPlatViewCommand;

            public ICommand OpenPlatViewCommand => _openPlatViewCommand;

            private readonly RelayCommand _openEntreeViewCommand;

            public ICommand OpenEntreeViewCommand => _openEntreeViewCommand;

            private readonly RelayCommand _openDessertViewCommand;

            public ICommand OpenDessertViewCommand => _openDessertViewCommand;

            private readonly RelayCommand _openSnackViewCommand;

            public ICommand OpenSnackViewCommand => _openSnackViewCommand;







        public void Plats()
            {

                DialogService.ShowPlatsWindow();

            }
            public void Entrees()
            {

                DialogService.ShowEntreesWindow();

            }
            public void Desserts()
            {

                DialogService.ShowDessertstWindow();

            }
            public void Snacks()
            {

                DialogService.ShowSnacksWindow();

            }
    }

}

