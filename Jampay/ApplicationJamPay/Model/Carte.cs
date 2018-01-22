using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Carte
    {
        private int _MatriculeCarte { get; set; }
        private int _Credit { get; set; }

        public Carte(int _MatriculeCarte , int _Credit )
        {
            this._MatriculeCarte = _MatriculeCarte;
            this._Credit = _Credit;
        }
    }
}
