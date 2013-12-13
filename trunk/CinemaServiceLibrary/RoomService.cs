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
        private System.Object lockThis = new System.Object();
        private static RoomCtr roomCtr = RoomCtr.getInstance();

        public int insertRoom(int roomNumber, int numberOfSeats)
        {
            lock (lockThis)
            {
                return roomCtr.insertRoom(roomNumber, numberOfSeats);
            }
        }

        public int updateRoom(int roomNumber, int numberOfSeats)
        {
            lock (lockThis)
            {
                return roomCtr.updateRoom(roomNumber, numberOfSeats);
            }
        }

        public int deleteRoomByNumber(int number)
        {
            lock (lockThis)
            {
                return roomCtr.deleteRoomByNumber(number);
            }
        }

        public Room getRoomByNumber(int number)
        {
            lock (lockThis)
            {
                Room serviceRoom = new Room();
                Cinema.ModelLayer.Room hostRoom = new Cinema.ModelLayer.Room();
                hostRoom = roomCtr.getRoomByNumber(number);

                serviceRoom.RoomNumber = hostRoom.RoomNumber;
                serviceRoom.NumberOfSeats = hostRoom.NumberOfSeats;

                return serviceRoom;
            }
        }

        public List<Room> getRooms()
        {
            lock (lockThis)
            {
                List<Cinema.ModelLayer.Room> returnList = roomCtr.getRooms();
                List<Room> roomList = new List<Room>();
                foreach (Cinema.ModelLayer.Room hostRoom in returnList)
                {
                    Room serviceRoom = new Room();

                    serviceRoom.RoomNumber = hostRoom.RoomNumber;
                    serviceRoom.NumberOfSeats = hostRoom.NumberOfSeats;

                    roomList.Add(serviceRoom);
                }
                return roomList;
            }
        }
    }
}
