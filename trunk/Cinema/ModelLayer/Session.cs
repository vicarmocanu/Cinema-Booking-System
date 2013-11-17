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

        private object[][] seats;
        public object[][] Seats
        {
            get { return seats; }
            set { seats = value; }
        }

      
        
        public void seatFillUp()
        {
            seats = new object[6][];

            
        }



        


        
      



        public Session() { }

        

        


    }
}
