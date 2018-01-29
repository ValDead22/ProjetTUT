using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Produit
{
    interface IProductDataAccessLayer
    {
        /// <summary>
        /// Get a product
        /// </summary>
        /// <returns>The Product</returns>
        List<Entity.Produit> GetAllProduits();

        /// <summary>
        /// Add a new Product
        /// </summary>
        void AddProduit(Entity.Produit produit);
    }
}
