using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class PlatCommandé
    {
        private int CodePlat { get; set; }

        private int CodeCommande { get; set; }

        private Plat Plat { get; set; }

        private Commande Commande { get; set; }

        public PlatCommandé(int CodePlat, int CodeCommande)
        {
            this.CodePlat = CodePlat;
            this.CodeCommande = CodeCommande;
        }
    }
}
