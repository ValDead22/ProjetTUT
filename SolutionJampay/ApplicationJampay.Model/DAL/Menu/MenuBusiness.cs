using ApplicationJampay.Model.DAL.Plat;
using System;
using System.Collections.Generic;

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
            try
            {
                List<Entity.Menu> list = _menuDAL.GetAllMenus();

                foreach (Entity.Menu m in list)
                {
                    m.SetListPlats(_platDAL.GetPlatByMenuID(m.CodeMenu ?? default(int)));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddMenu(Entity.Menu menu)
        {
            try
            {
                _menuDAL.AddMenu(menu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetAllCategories()
        {

            try
            {
                return _menuDAL.GetAllCategories();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ModifyMenu(Entity.Menu menu)
        {
            try
            {
                _menuDAL.ModifyMenu(menu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeleteMenu(Entity.Menu menu)
        {
            try
            {
                _menuDAL.DeleteMenu(menu);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void AddPlatToMenu(Entity.Plat plat, Entity.Menu menu)
        {
            try
            {
                _menuDAL.AddPlatToMenu(plat, menu);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void DeleteAllPlatOfMenu(Entity.Menu menu)
        {
            try
            {
                _menuDAL.DeleteAllPlatOfMenu(menu);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
