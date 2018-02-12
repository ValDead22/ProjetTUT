using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Utilisateur
{
    class UserDataAccessLayer : IUserDataAccessLayer
    {
        private SQLService _sQLService;
        
        public UserDataAccessLayer()
        {
            _sQLService = SQLService.Instance;
        }

        public List<Entity.Utilisateur> GetAllUser()
        {
            var query = "SELECT idUtilisateur, Fonction, Nom, Prenom FROM Utilisateur ut, Usager us WHERE ut.idUtilisateur = us.Matricule";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Utilisateur> list = new List<Entity.Utilisateur>();

                while (mySqlDataReader.Read())
                {
                    Entity.Utilisateur user = new Entity.Utilisateur((int)mySqlDataReader["idUtilisateur"],
                        mySqlDataReader["Fonction"] as string,
                        mySqlDataReader["Nom"] as string,
                        mySqlDataReader["Prenom"] as string);

                    list.Add(user);
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

        public Entity.Utilisateur GetUser(string matricule, string password)
        {
            var query = "SELECT * FROM Utilisateur WHERE idUtilisateur=\"" + matricule + "\"" + " AND MotDePasse=\"" + password + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try 
            {
                mySqlDataReader.Read();

                Entity.Utilisateur user = new Entity.Utilisateur(mySqlDataReader["Fonction"] as string, (int)mySqlDataReader["idUtilisateur"]);
                
                return user;
            }
            catch
            {
                throw new Exception("Utilisateur introuvable !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
            
        }
    }
}
