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
        public bool insertClient( String firstName, String lastName,String phoneNumber,String country)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `clients`(`First_name`, `Last_name`, `Phone_number`, `Country`) VALUES (@fnm,@snm,@phn,@cou)";
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
        /// 
        public bool editClient(int id, String firstName, String lastName, String phoneNumber, String country)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `clients` SET `First_name`= @fnm,`Last_name`= @snm,`Phone_number`= @phn ,`Country`= @cou WHERE `ID`= @cid";
            command.CommandText = editQuery;
            command.Connection = connect.GetConnection();


            //@cid,@fnm,@snm,@phn,@cou
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("@snm", MySqlDbType.VarChar).Value = lastName;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phoneNumber;
            command.Parameters.Add("@cou", MySqlDbType.VarChar).Value = country;

            connect.openConnection();

            if (command.ExecuteNonQuery() == 1)
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
        /// Remove data from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool removeClient(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM `clients` WHERE `ID`=@cid";
            command.CommandText = removeQuery;
            command.Connection = connect.GetConnection();

            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;

            connect.openConnection();

            if (command.ExecuteNonQuery() == 1)
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
    }
}

