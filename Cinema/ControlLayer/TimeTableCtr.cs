using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;
using Cinema.DBLayer;

namespace Cinema.ControlLayer
{
    class TimeTableCtr
    {
        private static TimeTableCtr instance = null;

        public static TimeTableCtr getInstance()
        {
            if (instance == null)
            {
                instance = new TimeTableCtr();
            }
            return instance;
        }

        public TimeTable getMovieTimeTable(Movie movie)
        {
            ISession _dbSession = new DbSession();
            TimeTable timeTable = new TimeTable();
            int movieId = movie.MovieId;
            List<Session> movieSessionList = _dbSession.getMovieSessions(movieId);
            timeTable.Movie = movie;
            timeTable.SessionList = movieSessionList;
            return timeTable;
        }
    }
}
