using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    class Commande
    {
        private int CodeCommande { get; set; }

        private int idCaissier { get; set; }

        private string MoyenDePaiement { get; set; }

        private Caissier Caissier { get; set; }

        private Carte Carte { get; set; }

        public Commande(int CodeCommande, int idCaissier, string MoyenDePaiement)
        {
            this.CodeCommande = CodeCommande;
            this.idCaissier = idCaissier;
            this.MoyenDePaiement = MoyenDePaiement;
        }
    }
}
