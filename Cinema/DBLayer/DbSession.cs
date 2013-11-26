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
    class DbSession :ISession
    {
        private static SqlCommand dbCmd = null;

        public int insertSession(Session session)
        {
            int result = -1;
            string sqlQuery = "INSERT INTO Session VALUES " +
                "('" + session.SessionId +
                "','" + session.Movie.MovieId +
                "','" + session.convertTime(session.EnterTime) +
                "','" + session.convertTime(session.ExitTime) + 
                "','" + session.convertDate(session.Date) + "')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException) { }

            return result;
        }

        public List<int> insertSeatSchedule(Session session, List<Seat> sessionSeats)
        {            
            List<int> results = new List<int>();
            foreach (Seat seat in sessionSeats)
            {
                int result = -1;
                string sqlQuery = "INSERT INTO SeatSchedule VALUES " +
                    "('" + session.SessionId +
                    "','" + seat.SeatId +
                    "','" + seat.Status + "')";
                try
                {
                    SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                    result = cmd.ExecuteNonQuery();
                    AccessDbSQLClient.Close();
                    results.Add(result);
                }
                catch (SqlException) { }
            }
            return results;
        }

        public int getRowCount(int sessionId)
        {
            int count = 0;

            string sqlQuery = "SELECT MAX(rowNumber) AS rowNumber FROM Seat, SeatSchedule WHERE " +
                "Seat.seatId=SeatSchedule.seatId AND sessionId = '" + sessionId + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            count = Convert.ToInt32(dbReader["rowNumber"].ToString());

            AccessDbSQLClient.Close();

            return count;
        }

        public int getColumnCount(int sessionId, int rowNumber)
        {
            int count = 0;

            string sqlQuery = "SELECT COUNT(seatId) AS count FROM " + 
                "(SELECT SeatSchedule.sessionId, SeatSchedule.seatId, Seat.rowNumber FROM " +
                "SeatSchedule JOIN Seat ON Seat.seatId = SeatSchedule.seatId WHERE " + 
                " rowNumber = '" + rowNumber + "' AND sessionId = '" + sessionId + "') AS SeatScheduleInfo";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            count = Convert.ToInt32(dbReader["count"].ToString());

            AccessDbSQLClient.Close();

            return count;
        }

        public Seat[][] getSeatsForJaggedArray(int sessionId)
        {
            int rowCount = 0;
            rowCount = getRowCount(sessionId);
            Seat[][] seats = new Seat[rowCount][];
            for(int i = 0; i<rowCount; i++)
            {
                List<Seat> scheduledRow = getScheduledSeatsFromRow(sessionId, i+1);
                int columnCount = scheduledRow.Count();
                seats[i] = new Seat[columnCount];
                int j = 0;
                int k = 0;
                while (j < columnCount && k < columnCount)
                {
                    seats[i][j] = scheduledRow[k];
                    k++; j++;
                }
            }
            return seats;
        }

        public List<Seat> getScheduledSeatsFromRow(int sessionId, int rowNumber)
        {
            List<Seat> returnList = new List<Seat>();
            string sqlQuery = "SELECT SeatSchedule.sessionId, SeatSchedule.seatId, " + 
                "Seat.seatNumber, Seat.rowNumber, Seat.roomNumber, SeatSchedule.status " +
                "FROM SeatSchedule JOIN Seat ON Seat.seatId = SeatSchedule.seatId " +
                "WHERE rowNumber = '" + rowNumber + "' AND sessionId = '" + sessionId + "' ORDER BY seatNumber";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            DbRoom dbRoom = new DbRoom();

            while (dbReader.Read())
            {
                Seat scheduledSeat = new Seat();
                scheduledSeat.SeatId = Convert.ToInt32(dbReader["seatId"].ToString());
                scheduledSeat.SeatNumber = Convert.ToInt32(dbReader["seatNumber"].ToString());
                scheduledSeat.RowNumber = Convert.ToInt32(dbReader["rowNumber"].ToString());
                scheduledSeat.Room = dbRoom.getRoomByNumber(Convert.ToInt32(dbReader["roomNumber"].ToString()));
                scheduledSeat.Status = dbReader["status"].ToString();
                returnList.Add(scheduledSeat);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }
        
        //get all sessions
        public List<Session> getSessions()
        {
            List<Session> returnList = new List<Session>();

            string sqlQuery = "SELECT Session.sessionId, Session.movieId, Session.date, " +
                "Session.enterTime, Session.exitTime, SeatSchedule.seatId, Seat.roomNumber " + 
                "FROM Session JOIN SeatSchedule ON Session.sessionId = SeatSchedule.sessionId " + 
                "JOIN Seat ON SeatSchedule.seatId = Seat.seatId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Session session = new Session();
            DbMovie dbMovie = new DbMovie();
            DbRoom dbRoom = new DbRoom();

            while (dbReader.Read())
            {
                session.SessionId = Convert.ToInt32(dbReader["sessionId"].ToString());
                session.Movie = dbMovie.getMovieByID(Convert.ToInt32(dbReader["movieId"].ToString()));
                session.Room = dbRoom.getRoomByNumber(Convert.ToInt32(dbReader["movieId"].ToString()));
                session.Date = dbReader["date"].ToString();
                session.EnterTime = session.suitableTime(dbReader["enterTime"].ToString());
                session.ExitTime = session.suitableTime(dbReader["exitTime"].ToString());

                returnList.Add(session);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //get a particular session
        public Session getSession(int sessionId)
        {
            string sqlQuery = "SELECT Session.sessionId, Session.movieId, Session.date, " +
                "Session.enterTime, Session.exitTime, SeatSchedule.seatId, Seat.roomNumber " +
                "FROM Session JOIN SeatSchedule ON Session.sessionId = SeatSchedule.sessionId " +
                "JOIN Seat ON SeatSchedule.seatId = Seat.seatId WHERE Session.sessionId = '" + sessionId + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Session session = new Session();
            DbMovie dbMovie = new DbMovie();
            DbRoom dbRoom = new DbRoom();

            if (dbReader.Read())
            {
                session.SessionId = Convert.ToInt32(dbReader["sessionId"].ToString());
                session.Movie = dbMovie.getMovieByID(Convert.ToInt32(dbReader["movieId"].ToString()));
                session.Room = dbRoom.getRoomByNumber(Convert.ToInt32(dbReader["movieId"].ToString()));
                session.Date = dbReader["date"].ToString();
                session.EnterTime = session.suitableTime(dbReader["enterTime"].ToString());
                session.ExitTime = session.suitableTime(dbReader["exitTime"].ToString());
            }
            else
            {
                session = null;
            }

            return session;
        }

        //update a session
        public int updateSession(Session session)
        {
            int result = -1;

            string sqlQuery = "UPDATE Session SET " +
                "movieId='" + session.Movie.MovieId + "', " +
                "date='" + session.Date + "', " +
                "enterTime='" + session.EnterTime + "', " +
                "exitTime='" + session.ExitTime + "' " +
                "WHERE sessionId='" + session.SessionId + "'";

            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }

        //update seat schedule
        public int updateSeatSchedule(int sessionId, int seatId, String status)
        {
            int result = -1;

            string sqlQuery = "UPDATE SeatSchedule SET " +
                "status = '" + status + "' " +
                "WHERE sessionId = '" + sessionId + "' " +
                "AND seatId = '" + seatId + "'";

            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }
    }
}
