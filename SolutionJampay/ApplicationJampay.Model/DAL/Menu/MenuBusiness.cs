using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Menu
{
    class MenuBusiness
    {
        private IMenuDataAccessLayer _menuDAL;

        public MenuBusiness()
        {
            _menuDAL = new MenuDataAccessLayer();
        }

        public List<Entity.Menu> GetAllMenus()
        {
            return _menuDAL.GetAllMenus();
        }


        public void AddProduit(Entity.Menu menu)
        {
            _menuDAL.AddMenu(menu);
        }
    }
}
