using System;
using System.Collections.Generic;

namespace ApplicationJampay.Model.DAL.Produit
{
    public class ProduitBusiness
    {
        private IProduitDataAccessLayer _productDAL;

        public ProduitBusiness()
        {
            _productDAL = new ProduitDataAccessLayer();
        }
        
        public List<Entity.Produit> GetAllProduits()
        {
            try
            {
                return _productDAL.GetAllProduits();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entity.Produit> GetProduitsByPlatId(int idPlat)
        {            
            try
            {
                return _productDAL.GetProduitsByPlatId(idPlat);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddProduit(Entity.Produit produit)
        {
            try
            {
                _productDAL.AddProduit(produit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddObs(Entity.Produit produit, String Obs)
        {
            try
            {
                _productDAL.AddObs(produit,Obs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
