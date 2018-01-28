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
            Initialize();
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

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connecté ma couille");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
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
                throw new Exception(ex.Message);
                
            }
        }

    }
}
