using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;

namespace CinemaServiceLibrary
{
    public class RoomService : IRoomService
    {
        private static RoomCtr roomCtr = new RoomCtr();

        public int insertRoom(int roomNumber, int numberOfSeats)
        {
            return roomCtr.insertRoom(roomNumber, numberOfSeats);
        }

        public int updateRoom(int roomNumber, int numberOfSeats)
        {
            return roomCtr.updateRoom(roomNumber, numberOfSeats);
        }
    }
}
