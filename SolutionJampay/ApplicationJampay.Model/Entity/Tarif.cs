using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    class Tarif
    {
        private float Prix { get; set; }

        private DateTime Date { get; set; }

        public Tarif(float Prix, DateTime Date)
        {
            this.Prix = Prix;
            this.Date = Date;
        }
    }
}
