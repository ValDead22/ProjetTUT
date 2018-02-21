using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;

namespace ApplicationJampay.Model.DAL.Usager
{
    public class UsagerDataAccessLayer : IUsagerDataAccessLayer
    {
        private SQLService _sQLService;

        public UsagerDataAccessLayer()
        {
            _sQLService = SQLService.Instance;
        }

        public List<string> GetAllMoyenDePaiements()
        {
            var query = "SELECT * FROM CategoriePaiement";
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
                throw new Exception("Problème(s) lors du chargement de la liste des moyens de paiement !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        public List<Entity.Usager> GetAllUsagers()
        {
            var query = "SELECT * FROM Usager";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Usager> list = new List<Entity.Usager>();

                while (mySqlDataReader.Read())
                {
                    

                    Entity.Usager usager = new Entity.Usager(
                        (DateTime)mySqlDataReader["DateEntree"],
                        (int)mySqlDataReader["Matricule"],
                        (int)mySqlDataReader["CodeFonction"],
                        (int)mySqlDataReader["Service"],
                        mySqlDataReader["Nom"] as string,
                        mySqlDataReader["Prenom"] as string,
                        mySqlDataReader["Titre"] as string,
                        mySqlDataReader["Paiement"] as string,
                        mySqlDataReader["MatriculeCarte"] as int?,
                        mySqlDataReader["DateFinC"] as DateTime?
                        );

                    list.Add(usager);
                }
                return list;
            }
            catch (MySqlException)
            {
                throw new Exception("Problème(s) lors du chargement des usagers !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        public Entity.Usager GetUsager(string matricule, string nom)
        {
            throw new NotImplementedException();
        }

        public void ModifyMoyenDePaiement(int matricule, string moyenDePaiement)
        {
            var query = "UPDATE Usager SET Paiement=\"" + moyenDePaiement + "\" WHERE Matricule=\"" + matricule + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            mySqlDataReader.Close();
        }
    }
}
