using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ModelLayer
{
    class Seat
    {
        private int seatId;       
        private int seatNumber;
        private int rowNumber;

        private Room room;

        private String status;

        //constructors
        public Seat(int seatID, int seatNumber, int rowNumber, Room room, String status)
        {
            this.seatNumber = seatNumber;
            this.rowNumber = rowNumber;
            this.room = room;
            this.status = status;
        }

        public Seat() { }

        //getters and setters
        public int SeatId
        {
            get 
            { 
                return seatId;
            }
            set 
            {
                seatId = value;
            }
        }

        public int SeatNumber
        {
            get
            {
                return seatNumber;
            }
            set
            {
                seatNumber = value;
            }
        }

        public int RowNumber
        {
            get
            {
                return rowNumber;
            }
            set
            {
                rowNumber = value;
            }
        }

        public Room Room
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

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
    }
}
