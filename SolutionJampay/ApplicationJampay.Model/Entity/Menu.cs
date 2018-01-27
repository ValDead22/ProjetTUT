using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Entity
{
    class Menu
    {
        private int CodeMenu { get; set; }

        private int idGerant { get; set; }

        private DateTime DateElaboration { get; set; }

        private string Categorie { get; set; }

        private string Nom { get; set; }

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
