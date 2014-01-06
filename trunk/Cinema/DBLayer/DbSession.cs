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

        private static SqlParameter paramSessionId = new SqlParameter("@sessionId", SqlDbType.Int);
        private static SqlParameter paramMovieId = new SqlParameter("@movieId", SqlDbType.Int);
        private static SqlParameter paramEnterTime = new SqlParameter("@enterTime", SqlDbType.Time, 7);
        private static SqlParameter paramExitTime = new SqlParameter("@exitTime", SqlDbType.Time, 7);
        private static SqlParameter paramDate = new SqlParameter("@date", SqlDbType.Date);
        private static SqlParameter paramPrice = new SqlParameter("@price", SqlDbType.Float);
        private static SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
        private static SqlParameter paramStatus = new SqlParameter("@status", SqlDbType.NVarChar, 50);

        //insert a seat
        public int insertSession(Session session)
        {
            int result = -1;

            String attrib = "sessionId";
            String table = "Session";
            int max = GetMax.getMax(attrib, table);
            int id = max + 1;

            dbCmd = new SqlCommand();
            string sqlQuery = "INSERT INTO Session VALUES " +
                "(@sessionId, @movieId, @enterTime, @exitTime, @date, @price)";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramSessionId.Value = id;
            dbCmd.Parameters.Add(paramSessionId);

            paramMovieId.Value = session.Movie.MovieId;
            dbCmd.Parameters.Add(paramMovieId);

            paramEnterTime.Value = session.EnterTime;
            dbCmd.Parameters.Add(paramEnterTime);

            paramExitTime.Value = session.ExitTime;
            dbCmd.Parameters.Add(paramExitTime);

            paramDate.Value = session.Date;
            dbCmd.Parameters.Add(paramDate);

            paramPrice.Value = session.Price;
            dbCmd.Parameters.Add(paramPrice);

            try
            {
                result = dbCmd.ExecuteNonQuery();
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

                dbCmd = new SqlCommand();
                string sqlQuery = "INSERT INTO SeatSchedule VALUES " +
                    "(@sessionId, @seatId, @status)";
                dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

                paramSessionId.Value = sessionId;
                dbCmd.Parameters.Add(paramSessionId);

                paramSeatId.Value = seat.SeatId;
                dbCmd.Parameters.Add(paramSeatId);

                paramStatus.Value = seat.Status;
                dbCmd.Parameters.Add(paramStatus);

                try
                {
                    result = dbCmd.ExecuteNonQuery();
                    dbCmd.Parameters.Clear();
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

            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT MAX(rowNumber) AS rowNumber FROM Seat, SeatSchedule WHERE " +
                "Seat.seatId=SeatSchedule.seatId AND sessionId = '" + sessionId + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.Read())
            {
                count = Convert.ToInt32(dbReader["rowNumber"].ToString());
            }

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return count;
        }

        //get the number of columns from the seats in a session/NO
        private static int getColumnCount(int sessionId, int rowNumber)
        {
            int count = 0;

            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT COUNT(seatId) AS count FROM " + 
                "(SELECT SeatSchedule.sessionId, SeatSchedule.seatId, Seat.rowNumber FROM " +
                "SeatSchedule JOIN Seat ON Seat.seatId = SeatSchedule.seatId WHERE " + 
                " rowNumber = '"+ rowNumber + "' AND sessionId = '" + sessionId + "') AS SeatScheduleInfo";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();
            if (dbReader.Read())
            {
                count = Convert.ToInt32(dbReader["count"].ToString());
            }

            dbCmd.Parameters.Clear();
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

            dbCmd = new SqlCommand();
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

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return returnList;
        }
        
        //get all sessions
        public List<Session> getSessions()
        {
            List<Session> returnList = new List<Session>();

            dbCmd = new SqlCommand();
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

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return returnList;
        }

        //get the sessions for a movie
        public List<Session> getMovieSessions(int movieId)
        {
            List<Session> returnList = new List<Session>();

            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT DISTINCT Session.sessionId, Session.movieId, Session.date, " +
                "Session.enterTime, Session.exitTime, Session.price, Seat.roomNumber " +
                "FROM Session JOIN SeatSchedule ON Session.sessionId = SeatSchedule.sessionId " +
                "JOIN Seat ON SeatSchedule.seatId = Seat.seatId WHERE Session.movieId = @movieId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramMovieId.Value = movieId;
            dbCmd.Parameters.Add(paramMovieId);

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

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return returnList;
        }
        
        //get a session - id
        public Session getSessionById(int sessionId)
        {
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT Session.sessionId, Session.movieId, Session.date, Session.price, " +
                "Session.enterTime, Session.exitTime, SeatSchedule.seatId, Seat.roomNumber " +
                "FROM Session JOIN SeatSchedule ON Session.sessionId = SeatSchedule.sessionId " +
                "JOIN Seat ON SeatSchedule.seatId = Seat.seatId WHERE Session.sessionId = @sessionId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramSessionId.Value = sessionId;
            dbCmd.Parameters.Add(paramSessionId);

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

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return session;
        }

        //update a session - id
        public int updateSession(Session session)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE Session SET " +
                "movieId= @movieId, date= @date, enterTime= @enterTime, " +
                "exitTime= @exitTime, price= @price WHERE sessionId= @sessionId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramSessionId.Value = session.SessionId;
            dbCmd.Parameters.Add(paramSessionId);

            paramMovieId.Value = session.Movie.MovieId;
            dbCmd.Parameters.Add(paramMovieId);

            paramEnterTime.Value = session.EnterTime;
            dbCmd.Parameters.Add(paramEnterTime);

            paramExitTime.Value = session.ExitTime;
            dbCmd.Parameters.Add(paramExitTime);

            paramDate.Value = session.Date;
            dbCmd.Parameters.Add(paramDate);

            paramPrice.Value = session.Price;
            dbCmd.Parameters.Add(paramPrice);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();
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

            dbCmd = new SqlCommand();
            string sqlQuery = "DELETE FROM Session WHERE sessionId= @sessionId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramSessionId.Value = sessionId;
            dbCmd.Parameters.Add(paramSessionId);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();
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

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE SeatSchedule SET " +
                "status= @status WHERE sessionId= @sessionId AND " +
                "seatId= @seatId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramSessionId.Value = sessionId;
            dbCmd.Parameters.Add(paramSessionId);

            paramSeatId.Value = seatId;
            dbCmd.Parameters.Add(paramSeatId);

            paramStatus.Value = status;
            dbCmd.Parameters.Add(paramStatus);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();
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

            dbCmd = new SqlCommand();
            String sqlQuery = "DELETE FROM SeatSchedule WHERE sessionId= @sessionId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramSessionId.Value = sessionId;
            dbCmd.Parameters.Add(paramSessionId);
            try
            {
                result = dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }            
    }
}
