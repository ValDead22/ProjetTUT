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
            _platDAL = new PlatAccessLayer();
        }

        public List<Entity.Plat> GetPlatByMenuId(int menuId)
        {
            return _platDAL.GetPlatByMenuID(menuId);
        }


        public void AddPlat(Entity.Plat plat)
        {
            _platDAL.AddPlat(plat);
        }
    }
}
