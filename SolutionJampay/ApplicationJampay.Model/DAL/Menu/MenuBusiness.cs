using ApplicationJampay.Model.DAL.Plat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Menu
{
    public class MenuBusiness
    {
        private IMenuDataAccessLayer _menuDAL;
        private IPlatDataAccessLayer _platDAL;

        public MenuBusiness()
        {
            _menuDAL = new MenuDataAccessLayer();
            _platDAL = new PlatDataAccessLayer();
        }

        public List<Entity.Menu> GetAllMenus()
        {
            List<Entity.Menu> list = _menuDAL.GetAllMenus();

            foreach(Entity.Menu m in list)
            {
                m.SetListPlats(_platDAL.GetPlatByMenuID(m.CodeMenu));
            }         

            return list;
        }

        public void AddMenu(Entity.Menu menu)
        {
            _menuDAL.AddMenu(menu);
        }

        public List<string> GetAllCategories()
        {
            return _menuDAL.GetAllCategories();
        }
    }
}
