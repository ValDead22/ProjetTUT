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
        public void AddProduit(Entity.Produit produit)
        {
            throw new NotImplementedException();
        }

        public List<Entity.Produit> GetAllProduits()
        {
            throw new NotImplementedException();
        }
    }
}
