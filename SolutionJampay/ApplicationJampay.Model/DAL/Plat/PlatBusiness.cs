using ApplicationJampay.Model.DAL.Produit;
using System;
using System.Collections.Generic;

namespace ApplicationJampay.Model.DAL.Plat
{
    public class PlatBusiness
    {
        private IPlatDataAccessLayer _platDAL;
        private IProduitDataAccessLayer _produitDAL;

        public PlatBusiness()
        {
            _platDAL = new PlatDataAccessLayer();
            _produitDAL = new ProduitDataAccessLayer();
        }

        public List<Entity.Plat> GetAllPlat()
        {
            try
            {
                List<Entity.Plat> list = _platDAL.GetAllPlat();

                foreach (Entity.Plat p in list)
                {
                    p.SetListProduits(_produitDAL.GetProduitsByPlat(p));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Entity.Plat> GetPlatByMenu(Entity.Menu menu)
        {
            try
            {
                return _platDAL.GetPlatByMenu(menu);
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

        public void DeleteProduitOfPlat(Entity.Plat plat)
        {
            try
            {
                _platDAL.DeleteAllProduitOfPlat(plat);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void AddProduitToPlat(Entity.Plat plat, Entity.Produit produit)
        {
            try
            {
                _platDAL.AddProduitToPlat(plat, produit);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
