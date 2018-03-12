using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class PlatWithQuantité : Plat, INotifyPropertyChanged
    {
        #region PropertyChanged stuff
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private int _quantite;
        public int Quantite
        {
            get { return _quantite; }
            set {
                _quantite = value;
                OnPropertyChanged(nameof(Quantite));
            }
        }

        
        public PlatWithQuantité(int codePlat, DateTime dateEffet, DateTime dateFin, string categorie, string nom, int quantite, float prix) : base(codePlat, dateEffet, dateFin, categorie, nom, prix)
        {
            Quantite = quantite;
        }
        
    }
}
