using System.Collections.Generic;

namespace ApplicationJampay.Model.DAL.Produit
{
    interface IProduitDataAccessLayer
    {
        /// <summary>
        /// Get a product
        /// </summary>
        /// <returns>The Product</returns>
        List<Entity.Produit> GetAllProduits();

        List<Entity.Produit> GetProduitsByPlatId(int idPlat);

        /// <summary>
        /// Add a new Product
        /// </summary>
        void AddProduit(Entity.Produit produit);
    }
}
