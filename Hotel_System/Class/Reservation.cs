using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Class
{
    class Reservation
    {   
        Connect connect = new Connect();


        public DataTable getReservation()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `reservation`", connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        
        public bool addtRoom(int reservationID, int roomNumber, int clientID, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `reservation`(`ReservationID`, `RoomNumber`, `ClientID`, `DateIN`, `DateOUT`) VALUES (@rid,@rnm,@cid,@din,@out)";
            command.CommandText = insertQuery;
            command.Connection = connect.GetConnection();


            //@rid,@rnm,@cid,@din,@out
            command.Parameters.Add("@rid", MySqlDbType.Int32).Value = reservationID;
            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = roomNumber;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientID;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@out", MySqlDbType.Date).Value = dateOut;

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





        public bool editReservation(int reservationID, int roomNumber, int clientID, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `rooms` SET `RoomNumber`=@rnm, `ClientID`=@cid, `DateIN`=@din, `DateOUT`=@out WHERE `ReservationID`=@rid";
            command.CommandText = editQuery;
            command.Connection = connect.GetConnection();


            //@cid,@fnm,@snm,@phn,@cou
            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = roomNumber;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientID;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@out", MySqlDbType.Date).Value = dateOut;

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

        public bool removeReservation(int reservationID)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM `reservation` WHERE `ReservationID`=@rid";
            command.CommandText = removeQuery;
            command.Connection = connect.GetConnection();

            command.Parameters.Add("@rid", MySqlDbType.Int32).Value = reservationID;

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
