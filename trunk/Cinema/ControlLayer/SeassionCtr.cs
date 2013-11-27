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

        public Seat[][] getSeatsForJaggedArray(int sessionId)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.getSeatsForJaggedArray(sessionId);
        }

        public List<Session> getSessions()
        {
            List<Session> returnList = new List<Session>();
            ISession _dbSession = new DbSession();
            returnList = _dbSession.getSessions();
            return returnList;

        }

        public Session getSessionById(int sessionId)
        {
            ISession _dbSession = new DbSession();
            return _dbSession.getSessionById(sessionId);
        }






    }
}
