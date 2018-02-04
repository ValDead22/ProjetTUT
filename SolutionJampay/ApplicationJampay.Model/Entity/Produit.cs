using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class Produit
    {
        public int CodeProduit { get; private set; }

        public DateTime DateEffet { get; private set; }

        public DateTime DateFin { get; private set; }

        public string Categorie { get; private set; }

        public string Nom { get; private set; }

        public string Observation { get; private set; }

        public Produit()
        {
        }
        
    }
}
