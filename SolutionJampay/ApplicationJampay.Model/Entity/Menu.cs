using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
   public class Menu
    {
        public int? CodeMenu { get; private set; }
        public string Nom { get; private set; }
        public int IdGerant { get; private set; }

        public DateTime DateElaboration { get; private set; }
        public string Categorie { get; private set; }        
        public string Observation { get; private set; }
        public List<Plat> ListPLats { get; private set; }
 
        public Menu(
            int idGerant, 
            DateTime dateElaboration, 
            string categorie, 
            string nom, 
            string observation,
            int? codeMenu = default(int))
        {
            CodeMenu = codeMenu;
            IdGerant = idGerant;
            DateElaboration = dateElaboration;
            Categorie = categorie;
            Nom = nom;
            Observation = observation;
        }

        public void SetListPlats(List<Plat> list)
        {
            ListPLats = list;
        }



    }
}
