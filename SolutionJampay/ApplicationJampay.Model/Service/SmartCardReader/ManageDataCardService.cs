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
            try
            {
                var byteArray = SmartCardReaderService.GetDataFromTheCard();

                return byteArray[0];
            }
            catch (Exception ex) 
            {

                throw new Exception("Problème avec le l'obtention du code de fonction depuis la carte" + "\n" + ex.Message);
            }
        }

        public static int GetCodeUser()
        {
            try
            {
                var byteArray = SmartCardReaderService.GetDataFromTheCard();

                return byteArray[0];
            }
            catch(Exception ex)
            {
                throw new Exception("Problème avec l'obtention du code de l'utilisateur depuis la carte" + "\n" + ex.Message);
            }
           
        }
    }
}
