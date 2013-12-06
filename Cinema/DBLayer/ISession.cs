using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;


namespace Cinema.DBLayer
{
    interface ISession
    {
        int insertSession(Session session);
        List<int> insertSeatSchedule(int sessionId, List<Seat> sessionSeats);    
        Seat[][] getSeatsForJaggedArray(int sessionId);
        List<Session> getSessions();
        Session getSessionById(int sessionId);
        int updateSession(Session session);
        int updateSeatSchedule(int sessionId, int seatId, String status);
        List<Session> getMovieSessions(int movieId);
        int deleteSession(int sessionId);
        int deleteSeatsFromSession(int sessionId);
    }
}
