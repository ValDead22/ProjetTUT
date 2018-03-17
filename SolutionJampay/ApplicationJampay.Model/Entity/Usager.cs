using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class Usager
    {
        public int Matricule { get; private set; }

        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string Titre { get; private set; }
        public string Paiement { get; private set; }

        public int CodeFonction { get; private set; }
        public int Service { get; private set; }
        public int MatriculeCarte { get; private set; }

        public DateTime DateEntree { get; private set; }
        public DateTime? DateFinContrat { get; private set; }



        public Usager(DateTime dateEntree, 
            int matricule, 
            int codeFonction, 
            int service, 
            string nom, 
            string prenom, 
            string titre, 
            string paiement,
            int matriculeCarte, 
            DateTime? dateFinContrat = default(DateTime?))
        {
            Paiement = paiement;
            Matricule = matricule;
            DateEntree = dateEntree;
            DateFinContrat = dateFinContrat;
            Nom = nom;
            Prenom = prenom;
            Service = service;
            CodeFonction = codeFonction;
            Titre = titre;
            DateFinContrat = dateFinContrat;
            MatriculeCarte = matriculeCarte;
        }
    }
}
