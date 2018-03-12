﻿using System;
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
        

        public Produit(int codeProduit, DateTime dateEffet, DateTime dateFin, string categorie, string nom, string observation)
        {
            CodeProduit = codeProduit;
            DateEffet = dateEffet;
            DateFin = dateFin;
            Categorie = categorie;
            Nom = nom;
            Observation = observation;
        }

        public bool Equals(Produit other)
        {
            return null != other && CodeProduit == other.CodeProduit;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Produit;

            if (item == null)
            {
                return false;
            }

            return this.CodeProduit.Equals(item.CodeProduit);
        }

        public override int GetHashCode()
        {
            return this.CodeProduit.GetHashCode();
        }

    }
}
