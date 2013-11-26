using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;
using Cinema.DBLayer;

namespace Cinema.ControlLayer
{
    class SeassionCtr
    {
         private static SeassionCtr instance = null;

        public static SeassionCtr getInstance()
        {
            if (instance == null)
            {
                instance = new SeassionCtr();
            }
            return instance;
        }

        public SeassionCtr()
        { 
        
        }

        public int insertSession()
        {
          
        }

        public List<int> insertSeatSchedule(Session session, List<Seat> sessionSeats)
        { 
        
        }

        public int getRowCount(int sessionId)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.getRowCount(sessionId);
        }

        public int getColumnCount(int sessionId, int rowNumber)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.getColumnCount(sessionId, rowNumber);
        }

        public Seat[][] getSeatsForJaggedArray(int sessionId)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.getSeatsForJaggedArray(sessionId);
        }

        public List<Seat> getScheduledSeatsFromRow(int sessionId, int rowNumber)
        {
            List<Seat> returnList = new List<Seat>();
            ISession _dbSession = new DbSession();
            returnList = _dbSession.getScheduledSeatsFromRow(sessionId,rowNumber);
            return returnList;
        }

        public List<Session> getSessions()
        { 
        
        }

        public Session getSession(int sessionId)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.getSession(sessionId);
        }

        public int updateSession(Session session)
        { 
        
        }

        public int updateSeatSchedule(int sessionId, int seatId, String status)
        { 
        
        }


    }
}
