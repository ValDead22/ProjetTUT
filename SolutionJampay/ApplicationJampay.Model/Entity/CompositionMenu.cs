using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    class CompositionMenu
    {
        private int CodePlat { get; set; }

        private int CodeMenu { get; set; }

        private DateTime Date { get; set; }

        private Menu Menu { get; set; }

        public CompositionMenu(int CodePlat, int CodeMenu, DateTime Date)
        {
            this.CodePlat = CodePlat;
            this.CodeMenu = CodeMenu;
            this.Date = Date;
        }
    }
}
