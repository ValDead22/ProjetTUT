using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class Plat
    {
        private int CodePlat { get; set; }

        private int IdTarif { get; set; }

        private DateTime DateEffet { get; set; }

        private DateTime DateFin { get; set; }

        private string Categorie { get; set; }

        private string Nom { get; set; }

        private Tarif Tarif { get; set; }

        public Plat(int CodePlat, DateTime DateEffet, DateTime DateFin, string Categorie, string Nom)
        {
            this.CodePlat = CodePlat;
            this.DateEffet = DateEffet;
            this.DateFin = DateFin;
            this.Categorie = Categorie;
            this.Nom = Nom;
        }
    }
}
