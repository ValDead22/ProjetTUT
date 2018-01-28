using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Usager
{
    class UserDataAccessLayer : IUserDataAccessLayer
    {
        private SQLService _sQLService;
        
        public UserDataAccessLayer()
        {
            _sQLService = SQLService.Instance;
        }

        public string GetUser(string matricule, string password)
        {
            var query = "SELECT * FROM Utilisateur WHERE idUtilisateur=" + matricule + " AND MotDePasse=\"" + password + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try 
            {
                mySqlDataReader.Read();
                return mySqlDataReader["Fonction"] as string;
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
