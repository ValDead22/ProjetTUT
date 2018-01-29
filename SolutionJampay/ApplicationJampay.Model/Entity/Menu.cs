using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
   public class Menu
    {
        public int CodeMenu { get; set; }

        public int idGerant { get; set; }

        public DateTime DateElaboration { get; set; }

        private string Categorie { get; set; }

        public string Nom { get; set; }

        private string Observation { get; set; }

        private Gerant Gerant { get; set; }

        public Menu(int CodeMenu, int idGerant, DateTime DateElaboration, string Categorie, string Nom, string Observation)
        {
            this.CodeMenu = CodeMenu;
            this.idGerant = idGerant;
            this.DateElaboration = DateElaboration;
            this.Categorie = Categorie;
            this.Nom = Nom;
            this.Observation = Observation;
        }

        
        
    }
}
