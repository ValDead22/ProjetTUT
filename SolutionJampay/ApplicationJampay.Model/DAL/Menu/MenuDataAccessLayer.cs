using System;
using System.Collections.Generic;
using System.Diagnostics;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;

namespace ApplicationJampay.Model.DAL.Menu
{
    class MenuDataAccessLayer : IMenuDataAccessLayer
    {

        private SQLService _sQLService = SQLService.Instance;


        /// <summary>
        /// Create a new Menu
        /// </summary>
        /// <param name="menu"></param>
        public void AddMenu(Entity.Menu menu)
        {
            var query = "INSERT INTO Menu VALUES(\"" + null + "\"" + ",\"" + menu.DateElaboration.ToString("yyyy-MM-dd") + "\"" + ",\"" + menu.Categorie + "\"" + ",\"" + menu.Nom + "\"" + ",\"" + menu.Observation + "\"" + ",\"" + menu.IdGerant+ "\""+")";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();
        }

        public void AddPlatToMenu(Entity.Plat plat, Entity.Menu menu)
        {
            var query = "INSERT INTO CompositionMenu VALUES(\"" + plat.CodePlat + "\"" + ",\"" + menu.CodeMenu + "\"" + ",\"" + menu.DateElaboration +  "\"" + ")";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();
        }

        public void DeleteAllPlatOfMenu(Entity.Menu menu)
        {
            var query = "DELETE FROM CompositionMenu WHERE CodeMenu = " + "\"" + menu.CodeMenu + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();
        }

        /// <summary>
        /// Delete an existing Menu
        /// </summary>
        /// <param name="menu"></param>
        public void DeleteMenu(Entity.Menu menu)
        {
            
            var query = "DELETE FROM Menu WHERE CodeMenu = " + "\"" + menu.CodeMenu + "\"; DELETE FROM CompositionMenu WHERE CodeMenu = " + "\"" + menu.CodeMenu + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();
        }

        /// <summary>
        /// Get all categories of Menu
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllCategories()
        {
            var query = "SELECT * FROM CategorieMenu ";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<string> list = new List<string>();
                while (mySqlDataReader.Read())
                {
                    string categ = (string)mySqlDataReader["Libelle"];

                    list.Add(categ);
                }
                return list;
            }
            catch
            {
                throw new Exception("Aucune catégories !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        /// <summary>
        /// Get all avalaible Menu
        /// </summary>
        /// <returns></returns>
        public List<Entity.Menu> GetAllMenus()
        {
            var query = "SELECT * FROM Menu";

            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Menu> list = new List<Entity.Menu>();

                while (mySqlDataReader.Read())
                {
                    Entity.Menu produit = new Entity.Menu((int)mySqlDataReader["idGerant"], (DateTime)mySqlDataReader["DateElaboration"], mySqlDataReader["Categorie"] as string, mySqlDataReader["Nom"] as string, mySqlDataReader["Observation"] as string, (int)mySqlDataReader["CodeMenu"]);

                    list.Add(produit);
                }
                return list;
            }
            catch
            {
                throw new Exception("Pas de menus !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        /// <summary>
        /// Modify an existing Menu
        /// </summary>
        /// <param name="menu"></param>
        public void ModifyMenu(Entity.Menu menu)
        {

            var query = "UPDATE Menu SET DateElaboration=" + "\"" + menu.DateElaboration.ToString("yyyy-MM-dd") + "\"" + ", Categorie=" + "\"" + menu.Categorie + "\"" + ", Nom=" + "\"" + menu.Nom + "\"" + ", Observation=" + "\"" + menu.Observation + "\"" + ", idGerant=" + "\"" + menu.IdGerant + "\"" + " WHERE CodeMenu= " + "\"" + menu.CodeMenu + "\"";
            Debug.WriteLine(query);
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();

        }

        public void DeletePlatfromMenu(Entity.Menu menu, Entity.Plat plat)
        {
            var query = "DELETE FROM CompositionMenu WHERE CodePlat="+ "\"" + plat.CodePlat + "\"" + ", AND CodeMenu=" + "\"" + menu.CodeMenu;
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();

        }


    }
}
