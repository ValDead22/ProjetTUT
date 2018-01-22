using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Usager
    {

        

        private DateTime _DateEntree { get; set; }

        private DateTime _DateFinContrat { get; set; }

        private int _Matricule { get; set; }

        private int _CodeFonction { get; set; }

        private int _Service { get; set; }
        
        private string _Nom { get; set; }

        private string _Prenom { get; set; }

        private string _Titre { get; set; }

       

        public Usager(int _Matricule, int _CodeFonction, int _Service, DateTime _DateEntree, DateTime _DateFinContrat, string _Titre, string _Nom, string _Prenom)
        {
            this._Matricule = _Matricule;
            this._DateEntree = _DateEntree;
            this._DateFinContrat = _DateFinContrat;
            this._Nom = _Nom;
            this._Prenom = _Prenom;
            this._Service = _Service;
            this._CodeFonction = _CodeFonction;
            this._Titre = _Titre;
        }
    }
}
}
