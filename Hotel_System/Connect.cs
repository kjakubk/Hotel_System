using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System
{   /*
     * This class will make the connection between app and mysql DB
     * First you need to download the mysql connectro and add it to your orihect
     */
    class Connect
    {
        private MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=Hotel_System_DB");

        //function to return our connection

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        //function to open the connection

        public void openConnection()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        //Function to close the connection

        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
