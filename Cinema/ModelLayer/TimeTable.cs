using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.ModelLayer
{
    class TimeTable
    {
        private Movie movie;

        public Movie Movie
        {
            get 
            {
                return movie;
            }
            set
            { 
                movie = value;
            }
        }

        private List<Session> sessionList;

        public List<Session> SessionList
        {
            get
            { 
                return sessionList; 
            }
            set 
            { 
                sessionList = value;
            }
        }

        public TimeTable() 
        { 
        
        }

        public void addSession(Session session)
        {
            sessionList.Add(session);

        }

        public void removeSession(int sessionId)
        {
            foreach (Session session in sessionList)
            {
                if (session.SessionId == sessionId)
                {
                    sessionList.Remove(session);
                    break;
                }
              
            }
  
        }

        public Session getSession(int sessionId)
        {
            Session wantedSession = new Session();

            foreach (Session session in sessionList)
            {
                if (session.SessionId == sessionId)
                {
                    wantedSession = session;
                    break;
                }
            }
            return wantedSession;
        }

        
    }
}
