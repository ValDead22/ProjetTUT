using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Usager
{
    public class UsagerBusiness
    {
        private IUsagerDataAccessLayer _usagerDAL;

        public UsagerBusiness()
        {
            _usagerDAL = new UsagerDataAccessLayer();
        }

        public Entity.Usager GetUsager(string matricule, string password)
        {
            return _usagerDAL.GetUsager(matricule, password);
        }

        public List<Entity.Usager> GetAllUsagers()
        {
            return _usagerDAL.GetAllUsagers();
        }

        public List<Entity.Usager> GetAllUsagersNonUtilisateur()
        {
            return _usagerDAL.GetAllUsagersNonUtilisateur();
        }

        public List<string> GetAllMoyenDePaiements()
        {
            return _usagerDAL.GetAllMoyenDePaiements();
        }

        public void ModifyMoyenDePaiement(int matricule, string moyenDePaiement)
        {
            _usagerDAL.ModifyMoyenDePaiement(matricule, moyenDePaiement);
        }
    }
}
