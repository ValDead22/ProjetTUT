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
    class ProductDataAccessLayer : IProductDataAccessLayer
    {
        private SQLService _sQLService;

        public ProductDataAccessLayer()
        {
            _sQLService = SQLService.Instance;
        }

        public void AddProduit(Entity.Produit produit)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Produit> GetAllProduits()
        {
            var query = "SELECT * FROM Produit";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Produit> list = new List<Entity.Produit>();

                while (mySqlDataReader.Read())
                {
                    Entity.Produit produit = new Entity.Produit();

                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        PropertyInfo propertyInfo = typeof(Entity.Produit).GetProperty(mySqlDataReader.GetName(i));
                        propertyInfo.SetValue(produit, mySqlDataReader[mySqlDataReader.GetName(i)], null);
                    }

                    list.Add(produit);
                                        
                }
                
                return list;
            }
            catch
            {
                throw new Exception("Pas de produits !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }
    }
}
