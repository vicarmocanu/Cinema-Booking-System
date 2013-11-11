using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ModelLayer
{
    class Seat
    {
        private int seatNumber;
        private int rowNumber;
        private Room room;
        private String status;

        //constructors
        public Seat(int seatNumber, int rowNumber, Room room, String status)
        {
            seatNumber = seatNumber;
            rowNumber = rowNumber;
            room = room;
            status = status;
        }

        public Seat() { }

        //getters and setters
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
