using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Usager
{
    public class UserDataAccessLayer : IUserDataAccessLayer
    {
        private SQLService _sQLService;
        
        public UserDataAccessLayer()
        {
            _sQLService = SQLService.Instance;
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
