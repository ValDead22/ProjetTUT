using ApplicationJampay.Model.Entity;
using ApplicationJampay.Model.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.DAL.Utilisateur
{
    class UtilisateurDataAccessLayer : IUtilisateurDataAccessLayer
    {
        private SQLService _sQLService;
        
        public UtilisateurDataAccessLayer()
        {
            _sQLService = SQLService.Instance;
        }

        public void AddUtilisateur(int matricule, string fonction, string motDePasse)
        {
            var query = "INSERT INTO Utilisateur values("+"\""+matricule+"\",\""+fonction+"\",\""+motDePasse+"\")";

            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            mySqlDataReader.Close();
        }

        public void DeleteUtilisateur(int matricule)
        {
            var query = "DELETE FROM Utilisateur Where idUtilisateur="+"\"" + matricule + "\"";

            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            mySqlDataReader.Close();
        }

        public List<string> GetAllFonctions()
        {
            var query = "SELECT * FROM CategorieRole";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<string> list = new List<string>();

                while (mySqlDataReader.Read())
                {
                    string categ = (string)mySqlDataReader["NomRole"];
                    list.Add(categ);
                }
                return list;
            }
            catch
            {
                throw new Exception("Problème(s) lors du chargement de la liste de fonctions !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        public List<Entity.Utilisateur> GetUtilisateursByFonction(string fonction)
        {
            List<Entity.Utilisateur> list = new List<Entity.Utilisateur>();
            List<Entity.Utilisateur> listUtilisateurs = GetAllUtilisateurs();

            foreach(Entity.Utilisateur ut in GetAllUtilisateurs())
            {
                if(ut.Fonction == fonction)
                {
                    Debug.Write(ut);
                    list.Add(ut);
                }
            }

            return list;
        }

        public List<Entity.Utilisateur> GetAllUtilisateurs()
        {
            var query = "SELECT idUtilisateur, Fonction, Nom, Prenom, Matricule, DateEntree, DateFinC, Titre, CodeFonction, Service, Paiement, MatriculeCarte, Paiement FROM Utilisateur ut, Usager us WHERE ut.idUtilisateur = us.Matricule";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {
                List<Entity.Utilisateur> list = new List<Entity.Utilisateur>();

                while (mySqlDataReader.Read())
                {
                    Entity.Utilisateur user = new Entity.Utilisateur(
                        mySqlDataReader["Fonction"] as string,
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

                    list.Add(user);
                }
                return list;
            }
            catch
            {
                throw new Exception("Problème(s) lors du chargement des utilisateurs !");
            }
            finally
            {
                mySqlDataReader.Close();
            }
        }

        public Entity.Utilisateur GetUtilisateur(string matricule, string password)
        {
            var query = "SELECT idUtilisateur, Fonction, Nom, Prenom, Matricule, DateEntree, DateFinC, Titre, CodeFonction, Service, Paiement, MatriculeCarte, Paiement FROM Utilisateur ut, Usager us WHERE ut.idUtilisateur = us.Matricule AND ut.idUtilisateur=\"" + matricule + "\"" + " AND ut.MotDePasse=\"" + password + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try 
            {
                mySqlDataReader.Read();

                Entity.Utilisateur user = new Entity.Utilisateur(
                         mySqlDataReader["Fonction"] as string,
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

        public void ModifyFonction(int matricule, string fonction)
        {
            var query = "UPDATE Utilisateur SET Fonction=\"" + fonction + "\" WHERE idUtilisateur=\"" + matricule + "\"";
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            mySqlDataReader.Close();
        }
    }
}
