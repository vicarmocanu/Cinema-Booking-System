using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ModelLayer
{
    public class Room
    {
        private int roomNumber;
        private int numberOfSeats;

        //constructor
        public Room() { }

        //getters and setters

        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }
            set
            {
                roomNumber = value;
            }
        }

        public int NumberOfSeats
        {
            get
            {
                return numberOfSeats;
            }
            set
            {
                numberOfSeats = value;
            }
        }
    }
}
