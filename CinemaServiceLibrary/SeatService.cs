using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;

namespace CinemaServiceLibrary
{
    
    public class SeatService : ISeatService
    {
        private static SeatCtr seatCtr = new SeatCtr();

        public int insertSeat(int seatNumber, int rowNumber, int roomNumber)           
        {
            return seatCtr.insertSeat( seatNumber, rowNumber, roomNumber);
        }

        public int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber)
        {
            return seatCtr.updateSeat(seatID, seatNumber, rowNumber, roomNumber);
        }

    }
}
