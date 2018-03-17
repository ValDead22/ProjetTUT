using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;

namespace ApplicationJampay.Model.DAL.Commande
{
    public class CommandeDataAccessLayer : ICommandeDataAccessLayer
    {
        private SQLService _sQLService;

        public CommandeDataAccessLayer()
        {
            _sQLService = SQLService.Instance;
        }

        public Entity.Commande GetTheLastInsertedCommande()
        {
            var query = "SELECT * FROM Commande Where CodeCommande=(SELECT MAX(CodeCommande) FROM Commande)";
            var mySqlDataReader = _sQLService.Load(query);
            try
            {

                mySqlDataReader.Read();


                Entity.Commande commande = new Entity.Commande(
                        (int)mySqlDataReader["idCaissier"],
                        mySqlDataReader["MoyenDePaiement"] as string,
                        (DateTime)mySqlDataReader["Date"],
                        (int)mySqlDataReader["MatriculeClient"],
                        (float)mySqlDataReader["PrixTotal"],
                        (int)mySqlDataReader["CodeCommande"]
                        );
                
        
                return commande;
            }
            catch
            {
                throw new Exception("Problème lors du chargement de la dernière commande !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        public void AddCommande(Entity.Commande commande)
        {
            var query = "INSERT INTO Commande VALUES(\"" + null + "\"" + ",\"" + commande.PrixTotal + "\"" + ",\"" + commande.Date.ToString("yyyy-MM-dd") + "\"" + ",\"" + commande.MoyenDePaiement + "\"" + ",\"" + commande.MatriculeClient + "\"" + ",\"" + commande.IDCaissier + "\"" + ")";
            var mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();
        }

        public List<Entity.Commande> GetAllCommandes()
        {
            var query = "SELECT * FROM Commande";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Commande> list = new List<Entity.Commande>();

                while (mySqlDataReader.Read())
                {

                    Entity.Commande commande = new Entity.Commande(
                         (int)mySqlDataReader["idCaissier"],
                         mySqlDataReader["MoyenDePaiement"] as string,
                         (DateTime)mySqlDataReader["Date"],
                        (int)mySqlDataReader["MatriculeClient"],
                        (float)mySqlDataReader["PrixTotal"],
                         (int)mySqlDataReader["CodeCommande"]
                         );
                    list.Add(commande);
                }

                return list;
            }
            catch
            {
                throw new Exception("Problème lors du chargement des commandes !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        public void AddPlatToCommande(Entity.Plat plat, Entity.Commande commande)
        {
            var query = "INSERT INTO PlatCommande VALUES(\""+plat.CodePlat+"\"" + "," + "\"" + commande.CodeCommande + "\"" + ")";
            var mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();
        }
    }
}
