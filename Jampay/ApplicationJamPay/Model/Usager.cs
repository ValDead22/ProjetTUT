using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Usager
    {
        private DateTime DateEntree { get; set; }

        private DateTime DateFinContrat { get; set; }

        private int Matricule { get; set; }

        private int CodeFonction { get; set; }

        private int Service { get; set; }
        
        private string Nom { get; set; }

        private string Prenom { get; set; }

        private string Titre { get; set; }

       

        public Usager(int Matricule, int CodeFonction, int Service, DateTime DateEntree, DateTime DateFinContrat, string Titre, string Nom, string Prenom)
        {
            this.Matricule = Matricule;
            this.DateEntree = DateEntree;
            this.DateFinContrat = DateFinContrat;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Service = Service;
            this.CodeFonction = CodeFonction;
            this.Titre = Titre;
        
        }
    }
}
