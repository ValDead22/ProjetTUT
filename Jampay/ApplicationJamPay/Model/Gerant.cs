using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Gerant : Utilisateur
    {
        private int idGerant { get; set; }

        private string Fonction { get; set; }

        private int idUtilisateur { get; set; }

        public Gerant(int idGerant, string Fonction, int idUtilisateur) : base(Fonction,idUtilisateur)
        {
            this.idGerant = idGerant;
        }
    }
}
