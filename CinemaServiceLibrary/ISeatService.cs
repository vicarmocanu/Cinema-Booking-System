﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    [ServiceContract]
    public interface ISeatService
    {
        [OperationContract]
        int insertSeat(int seatNumber, int rowNumber, int roomNumber);

        [OperationContract]
        int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber);

        [OperationContract]
        int deleteSeat(int id);

        [OperationContract]
        int deleteRoomSeats(int roomNumber);

        [OperationContract]
        List<int> insertSeatMatrix(int rows, int columns, int roomNumber);

        [OperationContract]
        int deleteSeatById(int id);

        [OperationContract]
        Seat getSeat(int id);

        [OperationContract]
        List<Seat> getSeats();

        [OperationContract]
        List<Seat> getRoomSeats(int roomNumber);


    }
    
    [DataContract]
    public class Seat
    {
        private int seatId;
        private int seatNumber;
        private int rowNumber;
        private Room room;
        private String status;

        [DataMemberAttribute]
        public int SeatId
        {
            get { return seatId; }
            set { seatId = value; }
        }

        [DataMemberAttribute]
        public int SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; }
        }

        [DataMemberAttribute]
        public int RowNumber
        {
            get { return rowNumber; }
            set { rowNumber = value; }
        }

        [DataMemberAttribute]
        public Room Room
        {
            get { return room; }
            set { room = value; }
        }
        
        [DataMemberAttribute]
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
