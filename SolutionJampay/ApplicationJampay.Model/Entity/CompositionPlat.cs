using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    class CompositionPlat
    {
        private int CodePlat { get; set; }

        private int CodeProduit { get; set; }

        private Plat Plat { get; set; }

        private Produit Produit { get; set; }

        public CompositionPlat(int CodePlat, int CodeProduit)
        {
            this.CodePlat = CodePlat;
            this.CodeProduit = CodeProduit;
        }
    }
}
