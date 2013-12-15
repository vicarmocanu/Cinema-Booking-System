using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    [ServiceContract]
    public interface IRoomService
    {
        [OperationContract]
        int insertRoom(int roomNumber, int numberOfSeats);

        [OperationContract]
        int updateRoom(int roomNumber, int numberOfSeats);

        [OperationContract]
        int deleteRoomByNumber(int number);

        [OperationContract]
        Room getRoomByNumber(int number);

        [OperationContract]
        List<Room> getRooms();
    }

    [DataContract]
    public class Room
    {
        private int roomNumber;
        private int numberOfSeats;

        [DataMemberAttribute]
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        [DataMemberAttribute]
        public int NumberOfSeats
        {
            get { return numberOfSeats; }
            set { numberOfSeats = value; }
        }

    }
}
