using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public List<Entity.Plat> GetPlatByMenuID(int menuID)
        {
            var query = "SELECT pl.CodePlat, pl.IdTarif, pl.DateEffet, pl.DateFin, pl.Categorie, pl.Nom FROM Plat pl, Menu m, CompositionMenu cpm WHERE m.CodeMenu =" + "\"" + menuID + "\"" + "and pl.CodePlat = cpm.CodePlat and m.CodeMenu = cpm.CodeMenu";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Plat> list = new List<Entity.Plat>();

                while (mySqlDataReader.Read())
                {
                    Entity.Plat plat = new Entity.Plat((int)mySqlDataReader["CodePlat"], (int)mySqlDataReader["idTarif"], (DateTime)mySqlDataReader["DateEffet"], (DateTime)mySqlDataReader["DateFin"], mySqlDataReader["Categorie"] as string, mySqlDataReader["Nom"] as string);

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
    }
}
