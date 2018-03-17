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
            try
            {
                return _utilisateurDAL.GetUtilisateur(matricule, password);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Entity.Utilisateur> GetAllUtilisateurs()
        {
            try
            {
                return _utilisateurDAL.GetAllUtilisateurs();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<string> GetAllFonctions()
        {
            try
            {
                return _utilisateurDAL.GetAllFonctions();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ModifyFonction(int matricule, string fonction)
        {
            try
            {
                _utilisateurDAL.ModifyFonction(matricule, fonction);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void AddUtilisateur(int matricule, string fonction, string motDePasse)
        {
            try
            {
                _utilisateurDAL.AddUtilisateur(matricule, fonction, motDePasse);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void DeleteUtilisateur(int matricule)
        {
            try
            {
                _utilisateurDAL.DeleteUtilisateur(matricule);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Entity.Utilisateur> GetUtilisateursByFonction(string fonction)
        {
            try
            {
                return _utilisateurDAL.GetUtilisateursByFonction(fonction);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Entity.Utilisateur GetUtilisateurByMatriculeCarte(int matrciculdeCarte)
        {
            try
            {
                return _utilisateurDAL.GetUtilisateurByMatriculeCarte(matrciculdeCarte);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
