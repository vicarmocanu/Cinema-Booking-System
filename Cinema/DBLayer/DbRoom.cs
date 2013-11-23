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
    class DbRoom
    {
        private static SqlCommand dbCmd = null;

        private static Room createRoom(IDataReader dbReader)
        {
            Room room = new Room();

            room.RoomNumber = (int)dbReader["roomNumber"];
            room.NumberOfSeats = (int)dbReader["numberOfSeats"];
           
            return room;
        }

        public int insertCustomer(Room room)
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

        public List<Room> getCustomers()
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

        public int updateRoom(Room room)
        {
            int result = -1;

            string sqlQuery = "UPDATE Room SET " +
                "roomNumber='" + room.RoomNumber + "', " +
                "noOfSeats='" + room.NumberOfSeats + "', " + "'";

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
