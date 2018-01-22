using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Menu
    {
        private int CodeMenu { get; set; }

        private DateTime DateElaboration { get; set; }

        private string Categorie { get; set; }

        private string Nom { get; set; }

        private string Observation { get; set; }

        public Menu(int CodeMenu, DateTime DateElaboration, string Categorie, string Nom, string Observation)
        {
            this.CodeMenu = CodeMenu;
            this.DateElaboration = DateElaboration;
            this.Categorie = Categorie;
            this.Nom = Nom;
            this.Observation = Observation;
        }
    }
}
