using System.Collections.Generic;

namespace ApplicationJampay.Model.DAL.Plat
{
    public interface IPlatDataAccessLayer
    {
        List<Entity.Plat> GetPlatByMenu(Entity.Menu menu);

        List<Entity.Plat> GetAllPlat();

        void AddPlat(Entity.Plat plat);

        List<string> GetAllCategories();

        List<Entity.Plat> GetPlatbyCateg(string Categorie);

        void ModifyPlat(Entity.Plat plat);

        void DeletePlat(Entity.Plat plat);

        void DeleteAllProduitOfPlat(Entity.Plat plat);

        void AddProduitToPlat(Entity.Plat plat, Entity.Produit produit);

        List<Entity.Plat> GetPlatByCodeCommande(Entity.Commande commande);

        void DeletePlatFromCommande(Entity.Commande commande, Entity.Plat plat);
    }
}
