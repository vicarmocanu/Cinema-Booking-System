using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;
using Cinema.DBLayer;

namespace Cinema.ControlLayer
{
    public class SessionCtr
    {
         private static SessionCtr instance = null;

        public static SessionCtr getInstance()
        {
            if (instance == null)
            {
                instance = new SessionCtr();
            }
            return instance;
        }

        public SessionCtr(){}
        
        public Seat[][] getSeatsForJaggedArray(int sessionId)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.getSeatsForJaggedArray(sessionId);
        }
        
        public List<Session> getSessions()
        {
            ISession _dbSession = new DbSession();

            List<Session> returnList = new List<Session>();            
            returnList = _dbSession.getSessions();

            return returnList;
        }

        public Session getSessionById(int sessionId)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.getSessionById(sessionId);
        }
        
        public int insertSession(int movieId, String EnterTime, String ExitTime, String Date, Double Price)
        { 
            ISession _dbSession = new DbSession();
            Movie mov= new Movie();
            Session ses = new Session();

            mov.MovieId = movieId;
            ses.Movie = mov;
            ses.EnterTime = EnterTime;
            ses.ExitTime = ExitTime;
            ses.Date = Date;

            ses.Price = Price;

            return _dbSession.insertSession(ses);
        }
        
        public List<int> insertSeatSchedule(int sessionId, List<Seat> sessionSeats)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.insertSeatSchedule(sessionId, sessionSeats);
        }
        
        public int updateSession(int MovieId, String Date, String EnterTime, String ExitTime, Double Price, int SessionId)
        {
            ISession _dbSession = new DbSession();
            Movie mov = new Movie();
            Session ses = new Session();

            mov.MovieId = MovieId;
            ses.Movie = mov;
            ses.Date = Date;
            ses.EnterTime = EnterTime;
            ses.ExitTime = ExitTime;
            ses.Price = Price;
            ses.SessionId = SessionId;

            return _dbSession.updateSession(ses);
        }
        
        public int updateSeatSchedule(int sessionId, int seatId, String status)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.updateSeatSchedule(sessionId, seatId, status);
        }
        
        public List<Session> getMovieSessions(int movieId)
        {
            ISession _dbSession = new DbSession();

            List<Session> returnList = new List<Session>();            
            returnList = _dbSession.getMovieSessions(movieId);
            
            return returnList;
        }

        public int deleteSessionById(int sessionId)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.deleteSession(sessionId);
            
          }
    }
}
