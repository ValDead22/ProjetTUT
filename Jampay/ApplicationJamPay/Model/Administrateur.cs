using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Administrateur : Utilisateur
    {
        private int idAdmin { get; set; }

        private string Fonction;

        private int idUtilisateur;

        public Administrateur(int idAdmin, string Fonction, int idUtilisateur)
        {
            base(Fonction, idUtilisateur);
            this.idAdmin = idAdmin;
        }


    }
}
