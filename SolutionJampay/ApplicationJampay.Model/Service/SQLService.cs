using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationJampay.Model.Service
{
    public class SQLService
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;



        private static SQLService _instance;
        public static SQLService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SQLService();

                return _instance;
            }
        }

        //Constructor
        private SQLService()
        {
            try
            {
                Initialize();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Initialize values
        private void Initialize()
        {
            server = "kebabhurlant.ddns.net";
            database = "PROJET_TUTEURE";
            uid = "seumards_remote";
            password = "Mwakamoon";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

            OpenConnection();
        }


        private void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception("Impossible de se connecter à la base de donnée.\n" + ex.Message);
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Select statement
        public MySqlDataReader Load(string query)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                return dataReader;
            }

            catch (MySqlException ex)
            {
                throw new Exception("Problème lors de l'accès aux données." + "\n" + ex.Message);
                
            }
        }

    }
}
