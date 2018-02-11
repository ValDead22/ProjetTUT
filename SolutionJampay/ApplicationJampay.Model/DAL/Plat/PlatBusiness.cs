using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Plat
{
    public class PlatBusiness
    {
        private IPlatDataAccessLayer _platDAL;

        public PlatBusiness()
        {
            _platDAL = new PlatDataAccessLayer();
        }

        public List<Entity.Plat> GetAllPlat()
        {
            return _platDAL.GetAllPlat();
        }

        public List<Entity.Plat> GetPlatByMenuId(int menuId)
        {
            return _platDAL.GetPlatByMenuID(menuId);
        }

        public void AddPlat(Entity.Plat plat)
        {
            _platDAL.AddPlat(plat);
        }

        public List<string> GetAllCategories()
        {
            return _platDAL.GetAllCategories();
        }
    }
}
