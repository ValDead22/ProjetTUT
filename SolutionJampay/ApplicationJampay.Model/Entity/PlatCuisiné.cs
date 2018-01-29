using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class PlatCuisiné
    {
        private int idCuisinier { get; set; }

        private int CodePlat { get; set; }

        private DateTime DateConfection { get; set; }

        private Cuisinier Cuisinier { get; set; }

        private Plat Plat { get; set; }

        public PlatCuisiné(int idCuisinier, int CodePlat, DateTime DateConfection)
        {
            this.idCuisinier = idCuisinier;
            this.CodePlat = CodePlat;
            this.DateConfection = DateConfection;
        }
    }
}
