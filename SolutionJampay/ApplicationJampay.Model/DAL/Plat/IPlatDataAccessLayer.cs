using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
