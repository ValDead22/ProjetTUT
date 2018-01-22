using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Cuisinier : Utilisateur
    {
        private int idCuisinier { get; set; }

        private string Fonction { get; set; }

        private int idUtilisateur { get; set; }

        public Cuisinier(int idCuisinier, string Fonction, int idUtilisateur) : base(Fonction,idUtilisateur)
        {
            this.idCuisinier = idCuisinier;
        }
    }
}
