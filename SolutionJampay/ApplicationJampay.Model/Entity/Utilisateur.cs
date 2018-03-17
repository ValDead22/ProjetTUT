using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class Utilisateur : Usager
    {
        public string Fonction { get; private set; }

        public Utilisateur(string fonction, 
            DateTime dateEntree,
            int matricule,
            int codeFonction,
            int service,
            string nom,
            string prenom,
            string titre,
            string paiement,
            int matriculeCarte,
            DateTime? dateFinContrat = default(DateTime?)) : base(dateEntree, matricule, codeFonction, service, nom, prenom, titre, paiement, matriculeCarte, dateFinContrat)
        {
            Fonction = fonction;
        }

    }
}
