using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class Produit
    {
        private int CodeProduit { get; set; }

        private DateTime DateEffet { get; set; }

        private DateTime DateFin { get; set; }

        private string Categorie { get; set; }

        private string Nom { get; set; }

        private string Observation { get; set; }

        public Produit(int CodeProduit, DateTime DateEffet, DateTime DateFin, string Categorie, string Nom, string Observation)
        {
            this.CodeProduit = CodeProduit;
            this.DateEffet = DateEffet;
            this.DateFin = DateFin;
            this.Categorie = Categorie;
            this.Nom = Nom;
            this.Observation = Observation;
        }
    }
}
