using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class Utilisateur
    {
        public string Fonction { get; private set; }

        public int IdUtilisateur { get; private set; }

        public Utilisateur(string Fonction, int idUtilisateur)
        {
            this.Fonction = Fonction;
            this.IdUtilisateur = idUtilisateur;
        }
                
    }
}
