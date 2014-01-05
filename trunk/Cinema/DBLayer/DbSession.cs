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
        private static DbMovie dbMovie = new DbMovie();
        private static DbRoom dbRoom = new DbRoom();

        //insert a seat
        public int insertSession(Session session)
        {
            int result = -1;

            String attrib = "sessionId";
            String table = "Session";
            int max = GetMax.getMax(attrib, table);
            int id = max + 1;

            string sqlQuery = "INSERT INTO Session VALUES " +
                "('" + id +
                "','" + session.Movie.MovieId +
                "','" + session.EnterTime +
                "','" + session.ExitTime +
                "','" + session.Date +
                "','" + session.Price + "')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException) { }

            return result;
        }

        //insert into the SeatSchedule table
        public List<int> insertSeatSchedule(int sessionId, List<Seat> sessionSeats)
        {            
            List<int> results = new List<int>();

            foreach (Seat seat in sessionSeats)
            {
                int result = -1;

                string sqlQuery = "INSERT INTO SeatSchedule VALUES " +
                    "('" + sessionId +
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

        //get the number of rows from the seats in a session/NO
        private static int getRowCount(int sessionId)
        {
            int count = 0;

            string sqlQuery = "SELECT MAX(rowNumber) AS rowNumber FROM Seat, SeatSchedule WHERE " +
                "Seat.seatId=SeatSchedule.seatId AND sessionId = '" + sessionId + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();
            if (dbReader.Read())
            {
                count = Convert.ToInt32(dbReader["rowNumber"].ToString());
            }
            AccessDbSQLClient.Close();

            return count;
        }

        //get the number of columns from the seats in a session/NO
        private static int getColumnCount(int sessionId, int rowNumber)
        {
            int count = 0;

            string sqlQuery = "SELECT COUNT(seatId) AS count FROM " + 
                "(SELECT SeatSchedule.sessionId, SeatSchedule.seatId, Seat.rowNumber FROM " +
                "SeatSchedule JOIN Seat ON Seat.seatId = SeatSchedule.seatId WHERE " + 
                " rowNumber = '" + rowNumber + "' AND sessionId = '" + sessionId + "') AS SeatScheduleInfo";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();
            if (dbReader.Read())
            {
                count = Convert.ToInt32(dbReader["count"].ToString());
            }

            AccessDbSQLClient.Close();

            return count;
        }

        //create the seats jagged array/OK
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
                while (j < columnCount)
                {
                    seats[i][j] = scheduledRow[j];
                    j++;
                }
            }

            return seats;
        }

        //get a row of seats from the scheduled seats for a session
        private static List<Seat> getScheduledSeatsFromRow(int sessionId, int rowNumber)
        {
            List<Seat> returnList = new List<Seat>();

            string sqlQuery = "SELECT SeatSchedule.sessionId, SeatSchedule.seatId, " + 
                "Seat.seatNumber, Seat.rowNumber, Seat.roomNumber, SeatSchedule.status " +
                "FROM SeatSchedule JOIN Seat ON Seat.seatId = SeatSchedule.seatId " +
                "WHERE rowNumber = '" + rowNumber + "' AND sessionId = '" + sessionId + "' ORDER BY seatNumber";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            while (dbReader.Read())
            {
                Room room = new Room();
                Seat scheduledSeat = new Seat();

                scheduledSeat.SeatId = Convert.ToInt32(dbReader["seatId"].ToString());
                scheduledSeat.SeatNumber = Convert.ToInt32(dbReader["seatNumber"].ToString());
                scheduledSeat.RowNumber = Convert.ToInt32(dbReader["rowNumber"].ToString());
                room.RoomNumber = Convert.ToInt32(dbReader["roomNumber"].ToString());
                scheduledSeat.Room = room;
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

            string sqlQuery = "SELECT DISTINCT Session.sessionId, Session.movieId, Session.date, " +
                "Session.enterTime, Session.exitTime, Session.price, Seat.roomNumber " +
                "FROM Session JOIN SeatSchedule ON Session.sessionId = SeatSchedule.sessionId " +
                "JOIN Seat ON SeatSchedule.seatId = Seat.seatId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            while (dbReader.Read())
            {
                Session session = new Session();
                Movie movie = new Movie();
                Room room = new Room();
                
                movie.MovieId = Convert.ToInt32(dbReader["movieId"].ToString());
                room.RoomNumber = Convert.ToInt32(dbReader["roomNumber"].ToString());

                session.SessionId = Convert.ToInt32(dbReader["sessionId"].ToString());
                session.Movie = movie;
                session.Room = room;
                session.Date = dbReader["date"].ToString();
                session.EnterTime = session.suitableTime(dbReader["enterTime"].ToString());
                session.ExitTime = session.suitableTime(dbReader["exitTime"].ToString());
                session.Price = Convert.ToDouble(dbReader["price"].ToString());

                returnList.Add(session);
            }

            return returnList;
        }

        //get the sessions for a movie
        public List<Session> getMovieSessions(int movieId)
        {
            List<Session> returnList = new List<Session>();

            string sqlQuery = "SELECT DISTINCT Session.sessionId, Session.movieId, Session.date, " +
                "Session.enterTime, Session.exitTime, Session.price, Seat.roomNumber " +
                "FROM Session JOIN SeatSchedule ON Session.sessionId = SeatSchedule.sessionId " +
                "JOIN Seat ON SeatSchedule.seatId = Seat.seatId WHERE Session.movieId = '" + movieId + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            while (dbReader.Read())
            {
                Session session = new Session();
                Movie movie = new Movie();
                Room room = new Room();
                

                movie.MovieId = Convert.ToInt32(dbReader["movieId"].ToString());
                room.RoomNumber = Convert.ToInt32(dbReader["roomNumber"].ToString());

                session.Movie = movie;
                session.Room = room;

                session.SessionId = Convert.ToInt32(dbReader["sessionId"].ToString());                
                session.Date = dbReader["date"].ToString();
                session.EnterTime = session.suitableTime(dbReader["enterTime"].ToString());
                session.ExitTime = session.suitableTime(dbReader["exitTime"].ToString());
                session.Price = Convert.ToDouble(dbReader["price"].ToString());

                returnList.Add(session);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }
        
        //get a session - id
        public Session getSessionById(int sessionId)
        {
            string sqlQuery = "SELECT Session.sessionId, Session.movieId, Session.date, Session.price, " +
                "Session.enterTime, Session.exitTime, SeatSchedule.seatId, Seat.roomNumber " +
                "FROM Session JOIN SeatSchedule ON Session.sessionId = SeatSchedule.sessionId " +
                "JOIN Seat ON SeatSchedule.seatId = Seat.seatId WHERE Session.sessionId = '" + sessionId + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Session session = new Session();

            if (dbReader.Read())
            {
                Movie movie = new Movie();
                Room room = new Room();

                movie.MovieId = Convert.ToInt32(dbReader["movieId"].ToString());
                room.RoomNumber = Convert.ToInt32(dbReader["roomNumber"].ToString());

                session.Movie = movie;
                session.Room = room;

                session.SessionId = Convert.ToInt32(dbReader["sessionId"].ToString());
                session.Date = dbReader["date"].ToString();
                session.EnterTime = session.suitableTime(dbReader["enterTime"].ToString());
                session.ExitTime = session.suitableTime(dbReader["exitTime"].ToString());
                session.Price = Convert.ToDouble(dbReader["price"].ToString());    
            }
            else
            {
                session = null;
            }

            return session;
        }

        //update a session - id
        public int updateSession(Session session)
        {
            int result = -1;

            string sqlQuery = "UPDATE Session SET " +
                "movieId='" + session.Movie.MovieId + "', " +
                "date='" + session.Date + "', " +
                "enterTime='" + session.EnterTime + "', " +
                "exitTime='" + session.ExitTime + "', " +
                "price='" + session.Price + "' " +
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

        //delete a session - id
        public int deleteSession(int sessionId)
        {
            int result = -1;
            string sqlQuery = "DELETE FROM Session WHERE sessionId= '" + sessionId + "'";
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

        //update a seat schedule
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

        //delete the seats from a session
        public int deleteSeatsFromSession(int sessionId)
        {
            int result = -1;
            String sqlQuery = "DELETE FROM SeatSchedule WHERE sessionId= '" + sessionId + "'";
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
