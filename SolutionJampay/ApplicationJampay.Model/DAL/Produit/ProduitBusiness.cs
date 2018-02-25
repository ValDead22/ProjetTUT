using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _productDAL.GetAllProduits();
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
            _productDAL.AddProduit(produit);
        }
    }
}
