using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Service.SmartCardReader
{
    public static class ManageDataCardService
    {
        public static int GetCodeFonction()
        {
            var byteArray = SmartCardReaderService.GetDataFromTheCard();

            return byteArray[0];
        }

        public static int GetCodeUser()
        {
            var byteArray = SmartCardReaderService.GetDataFromTheCard();

            return byteArray[0];
        }
    }
}
