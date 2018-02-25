using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;

namespace ApplicationJampay.Model.DAL.Produit
{
    class ProduitDataAccessLayer : IProduitDataAccessLayer
    {
        private SQLService _sQLService = SQLService.Instance;


        public void AddProduit(Entity.Produit produit)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Produit> GetAllProduits()
        {
            throw new NotImplementedException();
        }

        public List<Entity.Produit> GetProduitsByPlatId(int idPlat)
        {
            var query = "SELECT pr.CodeProduit, pr.DateEffet, pr.DateFin, pr.Categorie, pr.Nom, pr.Observation " +
                "FROM Produit pr, Plat pl, CompositionPlat cpp " +
                "WHERE pl.CodePlat =" + "\"" + idPlat + "\"" + "and pl.CodePlat = cpp.CodePlat and pr.CodeProduit = cpp.CodeProduit";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Produit> list = new List<Entity.Produit>();
                
                while (mySqlDataReader.Read())
                {
                    Entity.Produit plat = new Entity.Produit(
                        (int)mySqlDataReader["CodeProduit"],
                        (DateTime)mySqlDataReader["DateEffet"],
                        (DateTime)mySqlDataReader["DateFin"],
                        mySqlDataReader["Categorie"] as string,
                        mySqlDataReader["Nom"] as string,
                        mySqlDataReader["Observation"] as string);

                    list.Add(plat);
                }
                return list;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Problème lors du chargement des plats !" + "\n" + ex.Message);
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }
    }
}
