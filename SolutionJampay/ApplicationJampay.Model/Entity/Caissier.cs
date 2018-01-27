using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    class Caissier : Usager
    {
        private DateTime DateEntree { get; set; }

        private DateTime DateFinContrat { get; set; }

        private int Matricule { get; set; }

        private int CodeFonction { get; set; }

        private int Service { get; set; }

        private string Nom { get; set; }

        private string Prenom { get; set; }

        private string Titre { get; set; }

        private int idCaissier { get; set; }

        public Caissier(DateTime DateEntree, DateTime DateFinContrat, int Matricule, int CodeFonction, int Service, string Nom, string Prenom, string Titre, int idCaissier) : base(DateEntree, DateFinContrat, Matricule, CodeFonction, Service, Nom, Prenom, Titre)
        {
            this.idCaissier = idCaissier;
        }
    }
}
