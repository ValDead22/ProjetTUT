using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
   public class Menu
    {
        public int CodeMenu { get; private set; }

        public int IdGerant { get; private set; }

        public DateTime DateElaboration { get; private set; }

        public string Categorie { get; private set; }

        public string Nom { get; private set; }

        public string Observation { get; private set; }

        public Gerant Gerant { get; private set; }

        public List<Plat> ListPLats { get; private set; }
 
        public Menu(int CodeMenu, int idGerant, DateTime DateElaboration, string Categorie, string Nom, string Observation)
        {
            this.CodeMenu = CodeMenu;
            this.IdGerant = idGerant;
            this.DateElaboration = DateElaboration;
            this.Categorie = Categorie;
            this.Nom = Nom;
            this.Observation = Observation;
        }

        public void SetListPlats(List<Plat> list)
        {
            this.ListPLats = list;
        }



    }
}
