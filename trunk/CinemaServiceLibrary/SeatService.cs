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
        private System.Object lockThis = new System.Object();
        private static SeatCtr seatCtr = SeatCtr.getInstance();

        public int insertSeat(int seatNumber, int rowNumber, int roomNumber)           
        {
            lock (lockThis)
            {
                return seatCtr.insertSeat(seatNumber, rowNumber, roomNumber);
            }
        }

        public int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber)
        {
            lock (lockThis)
            {
                return seatCtr.updateSeat(seatID, seatNumber, rowNumber, roomNumber);
            }
        }

        public int deleteSeat(int id)
        {
            lock (lockThis)
            {
                return seatCtr.deleteSeatById(id);
            }
        }

        public int deleteRoomSeats(int roomNumber)
        {
            lock (lockThis)
            {
                return seatCtr.deleteRoomSeats(roomNumber);
            }
        }

        public List<int> insertSeatMatrix(int rows, int columns, int roomNumber)
        {
            lock (lockThis)
            {
                return seatCtr.insertSeatMatrix(rows, columns, roomNumber);
            }
        }

        public int deleteSeatById(int id)
        {
            lock (lockThis)
            {
                return seatCtr.deleteSeatById(id);
            }
        }

        public Seat getSeat(int id)
        {
            lock (lockThis)
            {
                Seat serviceSeat = new Seat();
                Cinema.ModelLayer.Seat hostSeat = new Cinema.ModelLayer.Seat();
                hostSeat = seatCtr.getSeatById(id);

                try
                {
                    Room serviceRoom = new Room();
                    serviceRoom.RoomNumber = hostSeat.Room.RoomNumber;

                    serviceSeat.SeatId = hostSeat.SeatId;
                    serviceSeat.SeatNumber = hostSeat.SeatNumber;
                    serviceSeat.RowNumber = hostSeat.RowNumber;
                    serviceSeat.Status = hostSeat.Status;
                    serviceSeat.Room = serviceRoom;
                }
                catch (NullReferenceException) { }

                return serviceSeat;
            }
        }

        public List<Seat> getSeats()
        {
            lock (lockThis)
            {
                List<Seat> seatList = new List<Seat>();

                List<Cinema.ModelLayer.Seat> returnList = seatCtr.getSeats();
                if (returnList.Count != 0)
                {
                    foreach (Cinema.ModelLayer.Seat hostSeat in returnList)
                    {
                        Seat serviceSeat = new Seat();
                        Room serviceRoom = new Room();

                        serviceRoom.RoomNumber = hostSeat.Room.RoomNumber;

                        serviceSeat.SeatId = hostSeat.SeatId;
                        serviceSeat.SeatNumber = hostSeat.SeatNumber;
                        serviceSeat.RowNumber = hostSeat.RowNumber;
                        serviceSeat.Status = hostSeat.Status;
                        serviceSeat.Room = serviceRoom;

                        seatList.Add(serviceSeat);
                    }
                }

                return seatList;
            }
        }

        public List<Seat> getRoomSeats(int roomNumber)
        {
            lock (lockThis)
            {
                List<Seat> seatList = new List<Seat>();

                List<Cinema.ModelLayer.Seat> returnList = seatCtr.getRoomSeats(roomNumber);
                if (returnList.Count != 0)
                {
                    foreach (Cinema.ModelLayer.Seat hostSeat in returnList)
                    {
                        Seat serviceSeat = new Seat();
                        Room serviceRoom = new Room();

                        serviceRoom.RoomNumber = hostSeat.Room.RoomNumber;

                        serviceSeat.SeatId = hostSeat.SeatId;
                        serviceSeat.SeatNumber = hostSeat.SeatNumber;
                        serviceSeat.RowNumber = hostSeat.RowNumber;
                        serviceSeat.Status = hostSeat.Status;
                        serviceSeat.Room = serviceRoom;

                        seatList.Add(serviceSeat);
                    }
                }

                return seatList;
            }
        }
    }
}
