using ApplicationJampay.Model.DAL.Plat;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.ViewModel.ViewModel
{
    public class AjouterPlatGerantViewModel : IViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private PlatBusiness _platBusiness;

        private ObservableCollection<Plat> _collectionPlat = new ObservableCollection<Plat>();
        public IEnumerable<Plat> CollectionPlats { get { return _collectionPlat; } }

        public AjouterPlatGerantViewModel()
        {
            _platBusiness = new PlatBusiness();
            

            try
            {
                foreach (Plat plat in _platBusiness.GetAllPlat())
                {
                    _collectionPlat.Add(plat);
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowErrorWindow(ex.Message);
            }
        }
    }
}
