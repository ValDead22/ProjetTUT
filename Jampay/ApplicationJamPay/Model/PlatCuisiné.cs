using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class PlatCuisiné
    {
        private int Matricule { get; set; }

        private int CodePlat { get; set; }

        private DateTime DateConfection { get; set; }

        private Cuisinier Cuisinier { get; set; }

        private Plat Plat { get; set; }

        public PlatCuisiné(int Matricule, int CodePlat, DateTime DateConfection)
        {
            this.Matricule = Matricule;
            this.CodePlat = CodePlat;
            this.DateConfection = DateConfection;
        }
    }
}
