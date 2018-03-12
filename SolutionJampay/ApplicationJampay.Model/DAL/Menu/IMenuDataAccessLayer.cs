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

        /// <summary>
        /// Modify an existing Menu
        /// </summary>
        /// <param name="menu"></param>
        void ModifyMenu(Entity.Menu menu);

        /// <summary>
        /// Delete an exiting Menu
        /// </summary>
        /// <param name="menu"></param>
        void DeleteMenu(Entity.Menu menu);

        /// <summary>
        /// Delete a Plat from a Menu
        /// </summary>
        /// <param name="menu"></param>
        void DeletePlatfromMenu(Entity.Menu menu, Entity.Plat plat);

        void AddPlatToMenu(Entity.Plat plat, Entity.Menu menu);

        void DeleteAllPlatOfMenu(Entity.Menu menu);
    }
}
