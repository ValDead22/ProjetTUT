﻿using System;
using System.Collections.Generic;

namespace ApplicationJampay.Model.DAL.Plat
{
    public class PlatBusiness
    {
        private IPlatDataAccessLayer _platDAL;

        public PlatBusiness()
        {
            _platDAL = new PlatDataAccessLayer();
        }

        public List<Entity.Plat> GetAllPlat()
        {
            try
            {
                return _platDAL.GetAllPlat();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<Entity.Plat> GetPlatByMenuId(int menuId)
        {
            try
            {
                return _platDAL.GetPlatByMenuID(menuId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void AddPlat(Entity.Plat plat)
        {
            try
            {
                _platDAL.AddPlat(plat);
            }
            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetAllCategories()
        {            
            try
            {
                return _platDAL.GetAllCategories();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entity.Plat> GetPlatbyCateg(string Categorie)
        {            
            try
            {
                return _platDAL.GetPlatbyCateg(Categorie);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ModifyPlat(Entity.Plat plat)
        {
            try
            {
                _platDAL.ModifyPlat(plat);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void DeletePlat(Entity.Plat plat)
        {
            try
            {
                _platDAL.DeletePlat(plat);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
