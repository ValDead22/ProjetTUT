﻿using System;
using System.Collections.Generic;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;

namespace ApplicationJampay.Model.DAL.Plat
{
    public class PlatDataAccessLayer : IPlatDataAccessLayer
    {
        private SQLService _sQLService = SQLService.Instance;

        public void AddPlat(Entity.Plat plat)
        {
            var query = "INSERT INTO Plat VALUES(\"" + null + "\"" + ",\"" + plat.DateEffet + "\"" + ",\"" + plat.DateFin + "\"" + ",\"" + plat.Categorie + "\"" + ",\"" + plat.Nom + "\"" + ",\"" + plat.Tarif + "\"" + ")";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();
        }

        /// <summary>
        /// Get all categories of Plat
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllCategories()
        {
            var query = "SELECT * FROM CategoriePlat";
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
        /// Get a Plat List by Category
        /// </summary>
        /// <param name="Categorie"></param>
        /// <returns></returns>
        public List<Entity.Plat> GetPlatbyCateg(string Categorie)
        {
            var query = "SELECT * FROM Plat WHERE Categorie=\"" + Categorie + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Plat> list = new List<Entity.Plat>();

                while (mySqlDataReader.Read())
                {
                    Entity.Plat plat = new Entity.Plat((int)mySqlDataReader["CodePlat"],
                        (int)mySqlDataReader["idTarif"],
                        (DateTime)mySqlDataReader["DateEffet"],
                        (DateTime)mySqlDataReader["DateFin"],
                        mySqlDataReader["Categorie"] as string,
                        mySqlDataReader["Nom"] as string);

                    list.Add(plat);
                }
                return list;
            }
            catch
            {
                throw new Exception("Pas de plats !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        /// <summary>
        /// Get all avalaible Plat
        /// </summary>
        /// <returns></returns>
        public List<Entity.Plat> GetAllPlat()
        {
            var query = "SELECT * FROM Plat";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Plat> list = new List<Entity.Plat>();

                while (mySqlDataReader.Read())
                {
                    Entity.Plat plat = new Entity.Plat((int)mySqlDataReader["CodePlat"],
                        (int)mySqlDataReader["idTarif"],
                        (DateTime)mySqlDataReader["DateEffet"],
                        (DateTime)mySqlDataReader["DateFin"],
                        mySqlDataReader["Categorie"] as string,
                        mySqlDataReader["Nom"] as string);

                    list.Add(plat);
                }
                return list;
            }
            catch
            {
                throw new Exception("Pas de plats !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        /// <summary>
        /// Get List of Plat by Menu ID
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public List<Entity.Plat> GetPlatByMenuID(int menuID)
        {
            var query = "SELECT pl.CodePlat, pl.IdTarif, pl.DateEffet, pl.DateFin, pl.Categorie, pl.Nom " +
                "FROM Plat pl, Menu m, CompositionMenu cpm " +
                "WHERE m.CodeMenu =" + "\"" + menuID + "\"" + "and pl.CodePlat = cpm.CodePlat and m.CodeMenu = cpm.CodeMenu";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Plat> list = new List<Entity.Plat>();

                while (mySqlDataReader.Read())
                {
                    Entity.Plat plat = new Entity.Plat((int)mySqlDataReader["CodePlat"], 
                        (int)mySqlDataReader["idTarif"], 
                        (DateTime)mySqlDataReader["DateEffet"], 
                        (DateTime)mySqlDataReader["DateFin"], 
                        mySqlDataReader["Categorie"] as string,
                        mySqlDataReader["Nom"] as string);

                    list.Add(plat);
                }
                return list;
            }
            catch
            {
                throw new Exception("Pas de plats !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        /// <summary>
        /// Modify an existing Plat
        /// </summary>
        /// <param name="plat"></param>
        public void ModifyPlat(Entity.Plat plat)
        {
            var query = " UPDATE Plat SET DateEffet="+ "\""+plat.DateEffet +"\"" + ", DateFin="+ "\"" + plat.DateFin + "\"" +", Categorie=" + "\"" + plat.Categorie+", Nom="+ "\"" + plat.Nom+ "\""+ "idTarif =" + "\"" + plat.Tarif + "\"" + " WHERE CodePlat= " + "\"" + plat.CodePlat + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

        }

        /// <summary>
        /// Delete an existing Plat
        /// </summary>
        /// <param name="plat"></param>
        public void DeletePlat(Entity.Plat plat)
        {
            var query = "DELETE FROM CompositionPlat WHERE CodePlat = " + "\"" + plat.CodePlat + "\"; DELETE FROM CompositionMenu WHERE CodePlat = " + "\"" + plat.CodePlat + "\"; DELETE FROM Plat WHERE CodePlat = " + "\"" + plat.CodePlat + "\"; ";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();
        }
    }
}
