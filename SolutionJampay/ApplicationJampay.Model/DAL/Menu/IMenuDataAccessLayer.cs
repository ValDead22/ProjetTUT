using System.Collections.Generic;

namespace ApplicationJampay.Model.DAL.Menu
{
    public interface IMenuDataAccessLayer
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

        /// <summary>
        /// Get all categories of menu
        /// </summary>
        /// <returns></returns>
        List<string> GetAllCategories();

        void ModifyMenu(Entity.Menu menu);
    }
}
