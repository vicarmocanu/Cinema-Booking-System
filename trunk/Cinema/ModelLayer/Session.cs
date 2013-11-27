using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace Cinema.ModelLayer
{
    class Session
    {

       

        private int sessionId;

        public int SessionId
        {

            get 
            { 
                return sessionId;
            }
            set
            { 
                sessionId = value;
            }
        }

        private Movie movie;

        internal Movie Movie
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

        private Room room;

        internal Room Room
        {
            get
            {
                return room;
            }
            set
            { 
                room = value;
            }
        }

        private String date;

        public String Date
        {
            get
            {
                return date; 
            }
            set 
            { 
                date = value;
            }
        }

        private String enterTime;

        public String EnterTime
        {
            get {
                return enterTime;
            }
            set 
            { 
                enterTime = value;
            }
        }

        private String exitTime;

        public String ExitTime
        {
            get
            { 
                return exitTime;
            }
            set 
            { 
                exitTime = value;
            }
        }

        private Seat[][] seats;

        public Seat[][] Seats
        {
            get
            { 
                return seats;
            }
            set
            { 
                seats = value;
            }
        }

        public Session() { }           

        public DateTime convertTime(String time)
        {
            DateTime HH_mm_ss = new DateTime();

            try
            {
                HH_mm_ss = DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch (Exception) { }

            return HH_mm_ss;
        }

        public DateTime convertDate(String date)
        {
            DateTime YYYY_MM_DD = new DateTime();
            try
            {
                YYYY_MM_DD = DateTime.ParseExact(date, "YYYY-MM-DD", CultureInfo.InvariantCulture);
            }
            catch (Exception) { }

            return YYYY_MM_DD;
        }

        public String suitableTime(String time)
        {
            String suitableTime = "default";
            suitableTime = time.Substring(0, 8);

            return suitableTime;
        }

    }
}
