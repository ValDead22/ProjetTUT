using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class Plat
    {
        public int CodePlat { get; private set; }

        public int IdTarif { get; private set; }

        public DateTime DateEffet { get; private set; }

        public DateTime DateFin { get; private set; }

        public string Categorie { get; private set; }

        public string Nom { get; private set; }

        public Plat(int CodePlat, int idTarif, DateTime DateEffet, DateTime DateFin, string Categorie, string Nom)
        {
            this.CodePlat = CodePlat;
            this.IdTarif = idTarif;
            this.DateEffet = DateEffet;
            this.DateFin = DateFin;
            this.Categorie = Categorie;
            this.Nom = Nom;
        }
    }
}
