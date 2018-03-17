﻿using System;
using System.Collections.Generic;

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
            try
            {
                return _usagerDAL.GetUsager(matricule, password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entity.Usager> GetAllUsagers()
        {
            try
            {
                return _usagerDAL.GetAllUsagers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entity.Usager> GetAllUsagersNonUtilisateur()
        {
            try
            {
                return _usagerDAL.GetAllUsagersNonUtilisateur();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetAllMoyenDePaiements()
        {
            try
            {
                return _usagerDAL.GetAllMoyenDePaiements();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ModifyMoyenDePaiement(int matricule, string moyenDePaiement)
        {
            try
            {
                _usagerDAL.ModifyMoyenDePaiement(matricule, moyenDePaiement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public float GetCardCredit(Entity.Usager usager)
        {
            try
            {
                return _usagerDAL.GetCardCredit(usager);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Entity.Usager GetUsagerByMatriculeCarte(int matricule)
        {
            try
            {
                return _usagerDAL.GetUsagerByMatriculeCarte(matricule);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SetCardCredit(Entity.Usager usager, float newCredit)
        {
            try
            {
                _usagerDAL.SetCardCredit(usager, newCredit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
