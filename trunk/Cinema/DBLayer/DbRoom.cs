using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Cinema.ModelLayer;
using Cinema.DBLayer;
using System.Security.Cryptography;

namespace Cinema.DBLayer
{
    class DbRoom: IRoom
    {
        private static SqlCommand dbCmd = null;

        //create a room object based on the data reader
        private static Room createRoom(IDataReader dbReader)
        {
            Room room = new Room();

            room.RoomNumber = Convert.ToInt32(dbReader["roomNumber"].ToString());
            room.NumberOfSeats = Convert.ToInt32(dbReader["noOfSeats"].ToString());
           
            return room;
        }

        //insert a room
        public int insertRoom(Room room)
        {
            int result = -1;

            string attrib = "roomNumber";
            string table = "Room";
            int max = GetMax.getMax(attrib, table);
            int id = max + 1;

            dbCmd = new SqlCommand();
            string sqlQuery = "INSERT INTO Room VALUES " +
                "(@roomNumber, @noOfSeats)";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramRoomNumber = new SqlParameter("@roomNumber", SqlDbType.Int);
            paramRoomNumber.Value = id;
            dbCmd.Parameters.Add(paramRoomNumber);

            SqlParameter paramNoOfSeats = new SqlParameter("@noOfSeats", SqlDbType.Int);
            paramNoOfSeats.Value = room.NumberOfSeats;
            dbCmd.Parameters.Add(paramNoOfSeats);

            try
            {            
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }

        //get all rooms
        public List<Room> getRooms()
        {
            List<Room> returnList = new List<Room>();

            string sqlQuery = "SELECT * FROM Room";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();
            
            while (dbReader.Read())
            {
                Room room = new Room();
                room = createRoom(dbReader);
                returnList.Add(room);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //get a room - number
        public Room getRoomByNumber(int number)
        {
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Room WHERE roomNumber= @roomNumber";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramRoomNumber = new SqlParameter("@roomNumber", SqlDbType.Int);
            paramRoomNumber.Value = number;
            dbCmd.Parameters.Add(paramRoomNumber);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Room room = new Room();

            if (dbReader.Read())
            {
                room = createRoom(dbReader);
            }
            else
            {
                room = null;
            }

            AccessDbSQLClient.Close();

            return room;
        }

        //update a room - number
        public int updateRoom(Room room)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE Room SET " +
                "noOfSeats= @noOfSeats WHERE roomNumber= @roomNumber";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramRoomNumber = new SqlParameter("@roomNumber", SqlDbType.Int);
            paramRoomNumber.Value = room.RoomNumber;
            dbCmd.Parameters.Add(paramRoomNumber);

            SqlParameter paramNoOfSeats = new SqlParameter("@noOfSeats", SqlDbType.Int);
            paramNoOfSeats.Value = room.NumberOfSeats;
            dbCmd.Parameters.Add(paramNoOfSeats);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }

        //delete a room - number
        public int deleteRoom(int number)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "DELETE FROM Room WHERE roomNumber= @roomNumber";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramRoomNumber = new SqlParameter("@roomNumber", SqlDbType.Int);
            paramRoomNumber.Value = number;
            dbCmd.Parameters.Add(paramRoomNumber);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }
    }
}
