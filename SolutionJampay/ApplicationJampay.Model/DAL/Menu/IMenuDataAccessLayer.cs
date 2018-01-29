using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Menu
{
    interface IMenuDataAccessLayer
    {
        /// <summary>
        /// Get all menus
        /// </summary>
        /// <returns></returns>
        List<Entity.Menu> GetAllMenus();

        /// <summary>
        /// Add a new Menu
        /// </summary>
        /// <param name="menu">Menu to add</param>
        void AddMenu(Entity.Menu menu);
    }
}
