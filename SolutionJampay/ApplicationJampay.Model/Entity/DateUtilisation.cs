using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    public class DateUtilisation
    {
        private DateTime DateUtil { get; set; }

        private Menu Menu { get; set; }

        public DateUtilisation(DateTime DateUtil)
        {
            this.DateUtil = DateUtil;
        }


    }
}
