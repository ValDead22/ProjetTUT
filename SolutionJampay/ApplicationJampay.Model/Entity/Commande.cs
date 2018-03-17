using System;

namespace ApplicationJampay.Model.Entity
{
    public class Commande
    {
        public int? CodeCommande { get; private set; }
        public int IDCaissier { get; private set; }
        public string MoyenDePaiement { get; private set; }
        public DateTime Date { get; private set; }
        public int MatriculeClient { get; private set; }

        public Commande(int idCaissier, string moyenDePaiement, DateTime date, int matriculeCLient, int? codeCommande = default(int))
        {
            Date = date;
            CodeCommande = codeCommande;
            IDCaissier = idCaissier;
            MatriculeClient = matriculeCLient;
            MoyenDePaiement = moyenDePaiement;
        }
    }
}
