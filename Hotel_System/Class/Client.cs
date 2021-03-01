using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Class
{
     /*
      * class client adding a new client into DB, 
      *                         edit client data,
      *                         remove client from DB
      *                         get all clients
      */
    public class Client
    {
        //function to insert new customers
        Connect connect = new Connect();
        public bool insertClient(string firstName, string lastName,string phoneNumber,string country)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `clients`(`First_name`, `Last_name`, `Phone_number`, `Country`) VALUES (@fnm,@snm,@phn,@cou)";
            command.CommandText = insertQuery;
            command.Connection = connect.GetConnection();


            //@fnm,@snm,@phn,@cou
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("@snm", MySqlDbType.VarChar).Value = lastName ;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phoneNumber;
            command.Parameters.Add("@cou", MySqlDbType.VarChar).Value = country;

            connect.openConnection(); 

            if(command.ExecuteNonQuery() == 1)
            {
                connect.closeConnection();
                return true;
            }
            else
            {
                connect.closeConnection();
                return false;
            }
        }
        /// <summary>
        /// Function to get the client list
        /// </summary>
        /// <returns>Clients list</returns>
        public DataTable GetClients()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients`", connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        /// <summary>
        /// Edit data in DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="country"></param>
        /// <returns>Edited data</returns>
        public bool editClient(int id, string firstName, string lastName, string phoneNumber, string country)
        {
            return;
        }
    }
}

