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
        private static SeatCtr seatCtr = SeatCtr.getInstance();

        public int insertSeat(int seatNumber, int rowNumber, int roomNumber)           
        {
            return seatCtr.insertSeat( seatNumber, rowNumber, roomNumber);
        }

        public int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber)
        {
            return seatCtr.updateSeat(seatID, seatNumber, rowNumber, roomNumber);
        }

        public int deleteSeat(int id)
        {
            return seatCtr.deleteSeatById(id);
        }

        public int deleteRoomSeats(int roomNumber)
        {
            return seatCtr.deleteRoomSeats(roomNumber);
        }

        public List<int> insertSeatMatrix(int rows, int columns, int roomNumber)
        {
            return seatCtr.insertSeatMatrix(rows, columns, roomNumber);
        }

        public int deleteSeatById(int id)
        {
            return seatCtr.deleteSeatById(id);
        }

        public int deleteRoomSeats(int roomNumber)
        {
            return seatCtr.deleteRoomSeats(roomNumber);
        }

        public Seat getSeat(int id)
        {
            Seat serviceSeat = new Seat();
            Cinema.ModelLayer.Seat hostSeat = new Cinema.ModelLayer.Seat();           
            hostSeat = seatCtr.getSeatById(id);

            Cinema.ModelLayer.Room hostRoom = new Cinema.ModelLayer.Room();
            Room serviceRoom = new Room();
            serviceRoom.RoomNumber = hostSeat.Room.RoomNumber;
            serviceRoom.NumberOfSeats = hostSeat.Room.NumberOfSeats;

            serviceSeat.SeatId = hostSeat.SeatId;
            serviceSeat.SeatNumber = hostSeat.SeatNumber;
            serviceSeat.RowNumber = hostSeat.RowNumber;
            serviceSeat.Status = hostSeat.Status;
            serviceSeat.Room = serviceRoom;

            return serviceSeat;
        }

        public List<Seat> getSeats()
        {
            List<Cinema.ModelLayer.Seat> returnList = seatCtr.getSeats();
            List<Seat> seatList = new List<Seat>();
            foreach (Cinema.ModelLayer.Seat hostSeat in returnList)
            {
                Seat serviceSeat = new Seat();
                Room serviceRoom = new Room();

                serviceRoom.RoomNumber = hostSeat.Room.RoomNumber;
                serviceRoom.NumberOfSeats = hostSeat.Room.NumberOfSeats;

                serviceSeat.SeatId = hostSeat.SeatId;
                serviceSeat.SeatNumber = hostSeat.SeatNumber;
                serviceSeat.RowNumber = hostSeat.RowNumber;
                serviceSeat.Status = hostSeat.Status;
                serviceSeat.Room = serviceRoom;

                seatList.Add(serviceSeat);
            }

            return seatList;
        }

        public List<Seat> getRoomSeats(int roomNumber)
        {
            List<Cinema.ModelLayer.Seat> returnList = seatCtr.getRoomSeats(roomNumber);
            List<Seat> seatList = new List<Seat>();
            foreach (Cinema.ModelLayer.Seat hostSeat in returnList)
            {
                Seat serviceSeat = new Seat();
                Room serviceRoom = new Room();

                serviceRoom.RoomNumber = hostSeat.Room.RoomNumber;
                serviceRoom.NumberOfSeats = hostSeat.Room.NumberOfSeats;

                serviceSeat.SeatId = hostSeat.SeatId;
                serviceSeat.SeatNumber = hostSeat.SeatNumber;
                serviceSeat.RowNumber = hostSeat.RowNumber;
                serviceSeat.Status = hostSeat.Status;
                serviceSeat.Room = serviceRoom;

                seatList.Add(serviceSeat);
            }

            return seatList;
        }
    }
}
