﻿using System;
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
            var query = "INSERT INTO Menu VALUES(\"" + null + "\"" + ",\"" + menu.DateElaboration + "\"" + ",\"" + menu.Categorie + "\"" + ",\"" + menu.Nom + "\"" + ",\"" + menu.Observation + "\"" + ",\"" + menu.IdGerant+ "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
        }

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

        public void ModifyMenu(Entity.Menu menu)
        {
            var query = "UPDATE Menu SET DateElaboration=" + "\"" + menu.DateElaboration + "\"" + ", Categorie=" + "\"" + menu.Categorie + "\"" + ", nom=" + "\"" + menu.Nom + ", Observation=" + "\"" + menu.Observation + "\"" + "idGerant =" + "\"" + menu.IdGerant + "\"" + " WHERE CodeMenu= " + "\"" + menu.CodeMenu + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query); 

        }
    }
}
