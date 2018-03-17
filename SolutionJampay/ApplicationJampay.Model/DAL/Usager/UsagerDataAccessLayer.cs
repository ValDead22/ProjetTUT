using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                        (int)mySqlDataReader["MatriculeCarte"],
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

        public List<Entity.Usager> GetAllUsagersNonUtilisateur()
        {
            var query = "SELECT * FROM Usager WHERE Matricule NOT IN (SELECT idUtilisateur FROM Utilisateur)";
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
                        (int)mySqlDataReader["MatriculeCarte"],
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

        public float GetCardCredit(Entity.Usager usager)
        {

            float credit = 0;

            var query = "SELECT Credit FROM Carte WHERE MatriculeCarte=\"" + usager.MatriculeCarte + "\"";
            
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);

            try
            {

                while (mySqlDataReader.Read())
                {
                    credit = (float)mySqlDataReader["Credit"];
                    
                }
                
            }
            catch
            {
                throw new Exception("Problème(s) lors de l'accès au crédit de l'usager !");
            }
            
            mySqlDataReader.Close();
            return credit;

        }
        

        public Entity.Usager GetUsagerByMatriculeCarte(int matricule)
        {
            var query = "SELECT * FROM Usager WHERE MatriculeCarte="+"\""+matricule+"\"";
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
                        (int)mySqlDataReader["MatriculeCarte"],
                        mySqlDataReader["DateFinC"] as DateTime?
                        );

                    list.Add(usager);
                }
                return list[0];
            }
            catch (MySqlException)
            {
                throw new Exception("Problème(s) lors l'obtention de l'usager !");
            }
            finally
            {
                mySqlDataReader.Close();
            }

        }

        public void SetCardCredit(Entity.Usager usager, float newCredit)
        {
            
            var query = "UPDATE Carte SET Credit=\"" + newCredit + "\"" + " WHERE MatriculeCarte=(SELECT MatriculeCarte FROM Usager WHERE Matricule=\"" + usager.Matricule + "\"" + ")";
            Debug.WriteLine(query);
            MySqlDataReader mySqlDataReader = _sQLService.Load(query);
            mySqlDataReader.Close();
            
        }
    }
}
