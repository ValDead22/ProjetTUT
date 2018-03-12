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

        List<Entity.Produit> GetProduitsByPlat(Entity.Plat plat);

        /// <summary>
        /// Add a new Product
        /// </summary>
        void AddProduit(Entity.Produit produit);

        /// <summary>
        /// Add an Observation to a Product
        /// </summary>
        void AddObs(Entity.Produit produit,string Obs);
    }
}
