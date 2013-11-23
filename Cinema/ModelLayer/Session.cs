using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Cinema.ModelLayer
{
    class Session
    {
        private int sessionId;
        public int SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }

        private Movie movie;
        internal Movie Movie
        {
            get { return movie; }
            set { movie = value; }
        }

        private Room room;
        internal Room Room
        {
            get { return room; }
            set { room = value; }
        }

        private String enterTime;
        public String EnterTime
        {
            get { return enterTime; }
            set { enterTime = value; }
        }

        private String exitTime;
        public String ExitTime
        {
            get { return exitTime; }
            set { exitTime = value; }
        }

        private Seat[][] seats;
        public Seat[][] Seats
        {
            get { return seats; }
            set { seats = value; }
        }

        public Session(int sessionId, Movie movie, Room room, String enterTime, String exitTime, Seat[][] seats)
        {
            this.sessionId = sessionId;
            this.movie = movie;
            this.room = room;
            this.enterTime = enterTime;
            this.exitTime = exitTime;
            this.seats = seats;
        }

        public Session() { }
    }
}
