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
        //int getRowCount(int sessionId);
        //int getColumnCount(int sessionId, int rowNumber);
        Seat[][] getSeatsForJaggedArray(int sessionId);
        //List<Seat> getScheduledSeatsFromRow(int sessionId, int rowNumber);
        List<Session> getSessions();
        Session getSessionById(int sessionId);
        int updateSession(Session session);
        int updateSeatSchedule(int sessionId, int seatId, String status);
    }
}
