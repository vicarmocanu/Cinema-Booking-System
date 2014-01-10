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
        private static readonly System.Object obj1 = new System.Object();
        private static readonly System.Object obj2 = new System.Object();
        private static readonly System.Object obj3 = new System.Object();
        private static readonly System.Object obj4 = new System.Object();
        private static readonly System.Object obj5 = new System.Object();
        private static readonly System.Object obj6 = new System.Object();
        private static readonly System.Object obj7 = new System.Object();
        private static readonly System.Object obj8 = new System.Object();
        private static readonly System.Object obj9 = new System.Object();

        private static SeatCtr seatCtr = SeatCtr.getInstance();
        private static SessionCtr sessionCtr = SessionCtr.getInstance();
        
        //1
        public int insertSeat(int seatNumber, int rowNumber, int roomNumber)           
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj1, 45000))
            {
                try
                {
                    result = seatCtr.insertSeat(seatNumber, rowNumber, roomNumber);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj1);
                }
            }

            return result;
        }

        //2
        public int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj2, 45000))
            {
                try
                {
                    result = seatCtr.updateSeat(seatID, seatNumber, rowNumber, roomNumber);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj2);
                }
            }

            return result;
        }

        //3
        public int deleteSeat(int id)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj3, 45000))
            {
                try
                {
                    result = seatCtr.deleteSeatById(id);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj3);
                }
            }

            return result;
        }

        //4
        public int deleteRoomSeats(int roomNumber)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj4, 45000))
            {
                try
                {
                    result = seatCtr.deleteRoomSeats(roomNumber);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj4);
                }
            }

            return result;
        }

        //5
        public List<int> insertSeatMatrix(int rows, int columns, int roomNumber)
        {
            List<int> results = new List<int>();

            if (System.Threading.Monitor.TryEnter(obj5, 45000))
            {
                try
                {
                    results = seatCtr.insertSeatMatrix(rows, columns, roomNumber);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj5);
                }
            }

            return results;
        }

        //6
        public int deleteSeatById(int id)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj6, 45000))
            {
                try
                {
                    result = seatCtr.deleteSeatById(id);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj6);
                }
            }

            return result;
        }

        //7
        public Seat getSeat(int id)
        {
            Seat serviceSeat = new Seat();

            if (System.Threading.Monitor.TryEnter(obj7, 45000))
            {
                try
                {
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
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj7);
                }
            }

            return serviceSeat;
        }

        //8
        public List<Seat> getSeats()
        {
            List<Seat> seatList = new List<Seat>();

            if (System.Threading.Monitor.TryEnter(obj8, 45000))
            {
                try
                {
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
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj8);
                }
            }

            return seatList;
        }

        //9
        public List<Seat> getRoomSeats(int roomNumber)
        {
            List<Seat> seatList = new List<Seat>();

            if (System.Threading.Monitor.TryEnter(obj9, 45000))
            {
                try
                {
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
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj9);
                }
            }

            return seatList;
        }
    }       
}