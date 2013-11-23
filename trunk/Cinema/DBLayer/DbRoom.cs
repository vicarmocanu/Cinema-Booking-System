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

        private static Room createRoom(IDataReader dbReader)
        {
            Room room = new Room();

            room.RoomNumber = Convert.ToInt32(dbReader["roomNumber"].ToString());
            room.NumberOfSeats = Convert.ToInt32(dbReader["numberOfSeats"].ToString());
           
            return room;
        }

        public int insertRoom(Room room)
        {
            int result = -1;
            string sqlQuery = "INSERT INTO Room VALUES " +
                "('" + room.RoomNumber +
                "','" + room.NumberOfSeats +"')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException sqlEx)
            { }

            return result;
        }

        public List<Room> getRooms()
        {
            List<Room> returnList = new List<Room>();

            string sqlQuery = "SELECT * FROM Room";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Room room;

            while (dbReader.Read())
            {
                room = createRoom(dbReader);
                returnList.Add(room);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        public Room getRoomByNumber(int number)
        {
            string sqlQuery = "SELECT * FROM Room WHERE roomNumber= '" + number + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Room room;
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

        public int updateRoom(Room room)
        {
            int result = -1;

            string sqlQuery = "UPDATE Room SET " +
                "noOfSeats='" + room.NumberOfSeats + "' " + 
                "WHERE roomNumber='" + room.RoomNumber + "'";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException sqlEx)
            { }

            return result;
        }
    }
}
