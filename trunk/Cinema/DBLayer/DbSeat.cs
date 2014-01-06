using Cinema.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DBLayer
{
    class DbSeat: ISeat
    {
        private static SqlCommand dbCmd = null;
        private static DbRoom dbRoom = new DbRoom();

        //build a seat object based on the db reader
        private static Seat createSeat(IDataReader dbReader)
        {
            Seat seat = new Seat();
            Room room = new Room();

            seat.SeatId = Convert.ToInt32(dbReader["seatId"].ToString());
            seat.SeatNumber = Convert.ToInt32(dbReader["seatNumber"].ToString());
            room.RoomNumber = Convert.ToInt32(dbReader["roomNumber"].ToString());
            seat.Room = room;
            seat.RowNumber = Convert.ToInt32(dbReader["rowNumber"].ToString());
            seat.Status = "E";

            return seat;
        }

        //insert the seats for a room
        public List<int> insertSeatMatrix(int rows, int columns, int roomNumber)
        {
            List<int> results = new List<int>();

            string attrib = "seatId";
            string table = "Seat";
            int max = 0;
            int id = 0;

            Room room = new Room();
            room = dbRoom.getRoomByNumber(roomNumber);
            int requiredNoOfSeats = -1;
            int noOfSeats = rows * columns;
            try
            {
                requiredNoOfSeats = room.NumberOfSeats;
            }
            catch (NullReferenceException) { }

            if (requiredNoOfSeats != -1)
            {
                if (noOfSeats == requiredNoOfSeats)
                {
                    for (int i = 1; i <= rows; i++)
                    {
                        for (int j = 1; j <= columns; j++)
                        {
                            int result = -1;
                            max = GetMax.getMax(attrib, table);
                            id = max + 1;

                            int seatNumber = (i * columns) - (columns - j);

                            dbCmd = new SqlCommand();
                            string sqlQuery = "INSERT INTO Seat VALUES " +
                                "(@seatId, @seatNumber, @roomNumber, @rowNumber)";
                            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

                            SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
                            paramSeatId.Value = id;
                            dbCmd.Parameters.Add(paramSeatId);

                            SqlParameter paramSeatNumber = new SqlParameter("@seatNumber", SqlDbType.Int);
                            paramSeatNumber.Value = seatNumber;
                            dbCmd.Parameters.Add(paramSeatNumber);

                            SqlParameter paramRoomNumber = new SqlParameter("@roomNumber", SqlDbType.Int);
                            paramRoomNumber.Value = roomNumber;
                            dbCmd.Parameters.Add(paramRoomNumber);

                            SqlParameter paramRowNumber = new SqlParameter("@rowNumber", SqlDbType.Int);
                            paramRowNumber.Value = i;
                            dbCmd.Parameters.Add(paramRowNumber);

                            try
                            {
                                result = dbCmd.ExecuteNonQuery();
                                AccessDbSQLClient.Close();
                            }
                            catch (SqlException) { }

                            results.Add(result);
                        }
                    }
                }
                else { }
            }
            else
            { }
            return results;
        }

        //insert a seat
        public int insertSeat(Seat seat)
        {
            int result = -1;

            string attrib = "seatId";
            string table = "Seat";
            int max = GetMax.getMax(attrib, table);
            int id = max + 1;

            dbCmd = new SqlCommand();
            string sqlQuery = "INSERT INTO Seat VALUES " +
                "(@seatId, @seatNumber, @roomNumber, @rowNumber)";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
            paramSeatId.Value = id;
            dbCmd.Parameters.Add(paramSeatId);

            SqlParameter paramSeatNumber = new SqlParameter("@seatNumber", SqlDbType.Int);
            paramSeatNumber.Value = seat.SeatNumber;
            dbCmd.Parameters.Add(paramSeatNumber);

            SqlParameter paramRoomNumber = new SqlParameter("@roomNumber", SqlDbType.Int);
            paramRoomNumber.Value = seat.Room.RoomNumber;
            dbCmd.Parameters.Add(paramRoomNumber);

            SqlParameter paramRowNumber = new SqlParameter("@rowNumber", SqlDbType.Int);
            paramRowNumber.Value = seat.RowNumber;
            dbCmd.Parameters.Add(paramRowNumber);
   
            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }

        //get all seats from a room
        public List<Seat> getRoomSeats(int roomNumber)
        {
            List<Seat> returnList = new List<Seat>();

            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Seat WHERE roomNumber= @roomNumber";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramRoomNumber = new SqlParameter("@roomNumber", SqlDbType.Int);
            paramRoomNumber.Value = roomNumber;
            dbCmd.Parameters.Add(paramRoomNumber);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            while (dbReader.Read())
            {
                Seat seat = new Seat();
                seat = createSeat(dbReader);
                returnList.Add(seat);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //get all seats
        public List<Seat> getSeats()
        {
            List<Seat> returnList = new List<Seat>();

            string sqlQuery = "SELECT * FROM Seat";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();
            
            while (dbReader.Read())
            {
                Seat seat = new Seat();
                seat = createSeat(dbReader);
                returnList.Add(seat);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //get a seat by its id
        public Seat getSeatById(int id)
        {
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Seat WHERE seatId= @seatId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
            paramSeatId.Value = id;
            dbCmd.Parameters.Add(paramSeatId);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Seat seat = new Seat();

            if (dbReader.Read())
            {
                seat = createSeat(dbReader);
            }
            else
            {
                seat = null;
            }

            AccessDbSQLClient.Close();

            return seat;
        }

        //update a seat  - id
        public int updateSeat(Seat seat)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE Seat SET " +
                "seatNumber= @seatNumber, roomNumber= @roomNumber, " +
                "rowNumber= @rowNumber WHERE seatId= @seatId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
            paramSeatId.Value = seat.SeatId;
            dbCmd.Parameters.Add(paramSeatId);

            SqlParameter paramSeatNumber = new SqlParameter("@seatNumber", SqlDbType.Int);
            paramSeatNumber.Value = seat.SeatNumber;
            dbCmd.Parameters.Add(paramSeatNumber);

            SqlParameter paramRoomNumber = new SqlParameter("@roomNumber", SqlDbType.Int);
            paramRoomNumber.Value = seat.Room.RoomNumber;
            dbCmd.Parameters.Add(paramRoomNumber);

            SqlParameter paramRowNumber = new SqlParameter("@rowNumber", SqlDbType.Int);
            paramRowNumber.Value = seat.RowNumber;
            dbCmd.Parameters.Add(paramRowNumber);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }

        //delete a seat - id
        public int deleteSeat(int id)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            String sqlQuery = "DELETE FROM Seat WHERE seatId= @seatId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
            paramSeatId.Value = id;
            dbCmd.Parameters.Add(paramSeatId);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }
            return result;
        }

        //delete the seats from a room
        public int deleteRoomSeats(int roomNumber)
        {
            int result = -1;
            dbCmd = new SqlCommand();
            String sqlQuery = "DELETE FROM Seat WHERE roomNumber= @roomNumber";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramRoomNumber = new SqlParameter("@roomNumber", SqlDbType.Int);
            paramRoomNumber.Value = roomNumber;
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
