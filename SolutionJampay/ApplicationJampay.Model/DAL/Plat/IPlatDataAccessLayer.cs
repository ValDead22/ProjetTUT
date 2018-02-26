using System.Collections.Generic;

namespace ApplicationJampay.Model.DAL.Plat
{
    public interface IPlatDataAccessLayer
    {
        List<Entity.Plat> GetPlatByMenuID(int menuID);

        List<Entity.Plat> GetAllPlat();

        void AddPlat(Entity.Plat plat);

        List<string> GetAllCategories();

        List<Entity.Plat> GetPlatbyCateg(string Categorie);

        void ModifyPlat(Entity.Plat plat);

        void DeletePlat(Entity.Plat plat);
    }
}
