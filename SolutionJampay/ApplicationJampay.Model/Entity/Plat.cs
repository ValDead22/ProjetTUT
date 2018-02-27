﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class Plat
    {
        public int CodePlat { get; private set; }
        public float? Prix { get; private set; }
        public DateTime DateEffet { get; private set; }
        public DateTime DateFin { get; private set; }
        public string Categorie { get; private set; }
        public string Nom { get; private set; }

        public Plat(int codePlat, DateTime dateEffet, DateTime dateFin, string categorie, string nom, float? prix = default(float))
        {
            CodePlat = codePlat;
            Prix = prix;
            DateEffet = dateEffet;
            DateFin = dateFin;
            Categorie = categorie;
            Nom = nom;
        }

    }
}
