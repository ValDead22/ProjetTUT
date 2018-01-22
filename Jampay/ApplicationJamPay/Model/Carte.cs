using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Carte
    {
        private int MatriculeCarte { get; set; }

        private int Credit { get; set; }

        public Carte(int MatriculeCarte,int Credit)
        {
            this.MatriculeCarte = MatriculeCarte;
            this.Credit = Credit;
        }
    }
}
