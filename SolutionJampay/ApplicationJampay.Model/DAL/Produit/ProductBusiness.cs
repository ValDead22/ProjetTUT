using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Produit
{
    class ProductBusiness
    {
        private IProductDataAccessLayer _productDAL;

        public ProductBusiness()
        {
            _productDAL = new ProductDataAccessLayer();
        }
        
        public List<Entity.Produit> GetAllProduits()
        {
            return _productDAL.GetAllProduits();
        }

        
        public void AddProduit(Entity.Produit produit)
        {
            _productDAL.AddProduit(produit);
        }
    }
}
