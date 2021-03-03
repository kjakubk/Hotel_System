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
     * Hotel room managment
     * We using room table
     */
    public class Room
    {
        Connect connect = new Connect();

        public DataTable roomTypeList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms_category`", connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool insertRoom(int roomNumber, int RoomType, String phoneNumber, String isAvailable)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `rooms`(`RoomNumber`, `RoomType`, `RoomPhone`, `Available`) VALUES (@rnm,@rty,@phn,@isa)";
            command.CommandText = insertQuery;
            command.Connection = connect.GetConnection();


            //@rnm,@rty,@phn,@isa
            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = roomNumber;
            command.Parameters.Add("@rty", MySqlDbType.Int32).Value = RoomType;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phoneNumber;
            command.Parameters.Add("@isa", MySqlDbType.VarChar).Value = isAvailable;

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

        public DataTable GetRooms()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms`", connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool editRoom(int roomNumber, int roomType, String phoneNumber, String isAvailable)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `rooms` SET `RoomType`=@rty,`RoomPhone`=@phn,`Available`=@isa WHERE `RoomNumber`=@rnm";
            command.CommandText = editQuery;
            command.Connection = connect.GetConnection();


            //@cid,@fnm,@snm,@phn,@cou
            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = roomNumber;
            command.Parameters.Add("@rty", MySqlDbType.Int32).Value = roomType;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phoneNumber;
            command.Parameters.Add("@isa", MySqlDbType.VarChar).Value = isAvailable;

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

        public bool removeRoom(int roomNumber)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM `rooms` WHERE `RoomNumber`=@rnm";
            command.CommandText = removeQuery;
            command.Connection = connect.GetConnection();

            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = roomNumber;

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

        public DataTable roomByTypeList(int roomType)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms` WHERE `RoomType` = @rty and `Available` = 'YES'", connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@rty", MySqlDbType.Int32).Value = roomType;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        //functio  to set room avilable column to NO
        public bool setRoomToNo(int roomNumber)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `rooms` SET `Available`= 'NO' WHERE `RoomNumber` = @rnm", connect.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = roomNumber;

            connect.openConnection();

            if(command.ExecuteNonQuery() > 1)
            {
                connect.closeConnection();
                return false;
            }
            else
            {
                connect.closeConnection();
                return true;
            }

            

         
        }
    }
}
