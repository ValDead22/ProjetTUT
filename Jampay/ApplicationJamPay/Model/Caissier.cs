using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Caissier : Utilisateur
    {
        private int idCaissier { get; set; }

        private string Fonction { get; set; }

        private int idUtilisateur { get; set; }

        public Caissier(int idCaissier, string Fonction, int idUtilisateur) : base(Fonction,idUtilisateur)
        {
            this.idCaissier = idCaissier;

        }
    }
}
