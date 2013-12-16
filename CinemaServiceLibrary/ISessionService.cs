using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    
    [ServiceContract]
    public interface ISessionService
    {
        [OperationContract]
        int insertSession(int movieId, String EnterTime, String ExitTime, String Date, Double Price);

        [OperationContract]
        int updateSession(int MovieId, String Date, String EnterTime, String ExitTime, Double Price, int SessionId);

        [OperationContract]
        List<int> insertSeatSchedule(int sessionId, int roomNumber);

        [OperationContract]
        int updateSeatSchedule(int sessionId, int seatId, String status);

        [OperationContract]
        int deleteSession(int sessionId);

        [OperationContract]
        int deleteSeatsFromSession(int sessionId);

        [OperationContract]
        Session getSession(int sessionId);

        [OperationContract]
        List<Session> getSessions();

        [OperationContract]
        List<Session> getMovieSessions(int movieId);

        [OperationContract]
        List<Seat> getSessionSeats(int sessionId);
       
    }

    [DataContract]
    public class Session
    {
        private int sessionId;
        private Movie movie;
        private Room room;
        private String date;
        private String enterTime;
        private String exitTime;
        private Seat[][] seats;
        private double price;
        
        [DataMemberAttribute]
        public int SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }
        
        [DataMemberAttribute]
        internal Movie Movie
        {
            get { return movie; }
            set { movie = value; }
        }
        
        [DataMemberAttribute]
        internal Room Room
        {
            get { return room; }
            set { room = value; }
        }
        
        [DataMemberAttribute]
        public String Date
        {
            get { return date; }
            set { date = value; }
        }
        
        [DataMemberAttribute]
        public String EnterTime
        {
            get { return enterTime; }
            set { enterTime = value; }
        }
        
        [DataMemberAttribute]
        public String ExitTime
        {
            get { return exitTime; }
            set { exitTime = value; }
        }
        
        [DataMemberAttribute]
        public Seat[][] Seats
        {
            get { return seats; }
            set { seats = value; }
        }

        [DataMemberAttribute]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
