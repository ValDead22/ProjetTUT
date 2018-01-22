using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJamPay.Model
{
    class Usager
    {

        private int _Matricule { get; set; }

        private int _CodeFonction { get; set; }

        private int _Service { get; set; }

        private DateTime _DateEntree { get; set; }

        private DateTime _DateFinContrat { get; set; }

        private string _Titre { get; set; }

        private string _Nom { get; set; }

        private string _Prenom { get; set; }

        

        // voir pour le enum ou ...

        public Usager(int _Matricule, DateTime _DateEntree, DateTime _DateFinContrat, string _Titre, string _Nom, string _Prenom, int _CodeFonction, int _Service)
        {
            this._CodeFonction = _CodeFonction;
            this._DateEntree = _DateEntree;
            this._DateFinContrat = _DateFinContrat;
            this._Nom = _Nom;
            this._Prenom = _Prenom;
            this._Titre = _Titre;
            this._Service = _Service;
            this._Matricule = _Matricule;
        }
    }
}
