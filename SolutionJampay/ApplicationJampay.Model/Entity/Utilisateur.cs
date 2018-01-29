using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class Utilisateur
    {
        private string Fonction { get; set; }

        private int idUtilisateur { get; set; }

        public Utilisateur(string Fonction, int idUtilisateur)
        {
            this.Fonction = Fonction;
            this.idUtilisateur = idUtilisateur;
        }

        public Utilisateur()
        {
        }
    }
}
