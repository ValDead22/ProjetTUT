using ApplicationJampay.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Utilisateur
{
    public class UtilisateurBusiness
    {
        private IUtilisateurDataAccessLayer _utilisateurDAL;

        public UtilisateurBusiness()
        {
            _utilisateurDAL = new UtilisateurDataAccessLayer();
        }

        public Entity.Utilisateur GetUtilisateur(string matricule, string password)
        {
            return _utilisateurDAL.GetUtilisateur(matricule, password);
        }

        public List<Entity.Utilisateur> GetAllUtilisateurs()
        {
            return _utilisateurDAL.GetAllUtilisateurs();
        }

        public List<string> GetAllFonctions()
        {
            return _utilisateurDAL.GetAllFonctions();
        }
    }
}
