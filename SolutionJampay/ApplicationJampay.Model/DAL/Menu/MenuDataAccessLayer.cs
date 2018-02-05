using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;

namespace ApplicationJampay.Model.DAL.Menu
{
    class MenuDataAccessLayer : IMenuDataAccessLayer
    {

        private SQLService _sQLService = SQLService.Instance;



        public void AddMenu(Entity.Menu menu)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Menu> GetAllMenus()
        {
            var query = "SELECT * FROM Menu";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Menu> list = new List<Entity.Menu>();

                while (mySqlDataReader.Read())
                {
                    Entity.Menu produit = new Entity.Menu((int)mySqlDataReader["CodeMenu"], (int)mySqlDataReader["idGerant"], (DateTime)mySqlDataReader["DateElaboration"], mySqlDataReader["Categorie"] as string, mySqlDataReader["Nom"] as string, mySqlDataReader["Observation"] as string);

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
    }
}
