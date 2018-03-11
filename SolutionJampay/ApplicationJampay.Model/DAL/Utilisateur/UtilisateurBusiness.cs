﻿using ApplicationJampay.Model.Service;
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

        public void ModifyFonction(int matricule, string fonction)
        {
            _utilisateurDAL.ModifyFonction(matricule, fonction);
        }

        public void AddUtilisateur(int matricule, string fonction, string motDePasse)
        {
            _utilisateurDAL.AddUtilisateur(matricule, fonction, motDePasse);
        }

        public void DeleteUtilisateur(int matricule)
        {
            _utilisateurDAL.DeleteUtilisateur(matricule);
        }

        public List<Entity.Utilisateur> GetUtilisateursByFonction(string fonction)
        {
            return _utilisateurDAL.GetUtilisateursByFonction(fonction);
        }
    }
}
