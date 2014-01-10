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
        private static readonly System.Object obj1 = new System.Object();
        private static readonly System.Object obj2 = new System.Object();
        private static readonly System.Object obj3 = new System.Object();
        private static readonly System.Object obj4 = new System.Object();
        private static readonly System.Object obj5 = new System.Object();

        private static RoomCtr roomCtr = RoomCtr.getInstance();

        //1
        public int insertRoom(int roomNumber, int numberOfSeats)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj1, 45000))
            {
                try
                {
                    result = roomCtr.insertRoom(roomNumber, numberOfSeats);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj1);
                }
            }

            return result;
        }

        //2
        public int updateRoom(int roomNumber, int numberOfSeats)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj2, 45000))
            {
                try
                {
                    result = roomCtr.updateRoom(roomNumber, numberOfSeats);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj2);
                }
            }

            return result;
        }

        //3
        public int deleteRoomByNumber(int number)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj3, 45000))
            {
                try
                {
                    result = roomCtr.deleteRoomByNumber(number);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj3);
                }
            }

            return result;
        }

        //4
        public Room getRoomByNumber(int number)
        {
            Room serviceRoom = new Room();

            if (System.Threading.Monitor.TryEnter(obj4, 45000))
            {
                try
                {
                    Cinema.ModelLayer.Room hostRoom = new Cinema.ModelLayer.Room();
                    hostRoom = roomCtr.getRoomByNumber(number);
                    try
                    {
                        serviceRoom.RoomNumber = hostRoom.RoomNumber;
                        serviceRoom.NumberOfSeats = hostRoom.NumberOfSeats;
                    }
                    catch (NullReferenceException) { }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj4);
                }
            }

            return serviceRoom;
        }

        //5
        public List<Room> getRooms()
        {
            List<Room> roomList = new List<Room>();

            if (System.Threading.Monitor.TryEnter(obj5, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Room> returnList = roomCtr.getRooms();
                    if (returnList.Count != 0)
                    {
                        foreach (Cinema.ModelLayer.Room hostRoom in returnList)
                        {
                            Room serviceRoom = new Room();

                            serviceRoom.RoomNumber = hostRoom.RoomNumber;
                            serviceRoom.NumberOfSeats = hostRoom.NumberOfSeats;

                            roomList.Add(serviceRoom);
                        }
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj5);
                }
            }

            return roomList;
        }
    }
}
