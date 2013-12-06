using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;

namespace CinemaServiceLibrary
{    
    public class SessionService : ISessionService
    {
        private static SessionCtr sessionCtr = SessionCtr.getInstance();

        public int insertSession(int movieId, string EnterTime, string ExitTime, string Date, double Price)
        {
            return sessionCtr.insertSession(movieId, EnterTime, ExitTime, Date, Price);
        }

        public int updateSession(int MovieId, string Date, string EnterTime, string ExitTime, double Price, int SessionId)
        {
            return sessionCtr.updateSession(MovieId, Date, ExitTime, ExitTime, Price, SessionId);
        }       
    }
}
