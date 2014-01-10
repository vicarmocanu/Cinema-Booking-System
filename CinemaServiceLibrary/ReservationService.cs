using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;
using System.Threading;

namespace CinemaServiceLibrary
{   
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Single)]
    public class ReservationService : IReservationService
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
        private static readonly System.Object obj10 = new System.Object();
        private static readonly System.Object obj11 = new System.Object();
        private static readonly System.Object obj12 = new System.Object();
        private static readonly System.Object obj13 = new System.Object();
        private static readonly System.Object obj14 = new System.Object();

        private static ReservationCtr reservationCtr = ReservationCtr.getInstance();
        private static AlgorithmCtr algortithmCtr = AlgorithmCtr.getInstance();
        private static SessionCtr sessionCtr = SessionCtr.getInstance();

        //1
        public int insertReservation(String firstName, String lastName, int sessionId, int numberOfSeats, double price, String status)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj1, 45000))
            {
                try
                {
                    result = reservationCtr.insertReservation(firstName, lastName, sessionId, numberOfSeats, price, status);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj1);
                }
            }

            return result;
        }

        //2
        public int updateReservation(string firstName, string lastName, int sessionId, int numberOfSeats, double price, string status, int reservationId, String data)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj2, 45000))
            {
                try
                {
                    result = reservationCtr.updateReservation(firstName, lastName, sessionId, numberOfSeats, price, status, reservationId, data);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj2);
                }
            }

            return result;
        }

        //3
        public int insertReservedSeat(int reservationId, int seatId)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj3, 45000))
            {
                try
                {
                    result = reservationCtr.insertReservedSeat(reservationId, seatId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj3);
                }
            }

            return result;
        }

        //4
        public int updateReservedSeat(int reservationId, int seatId, String status)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj4, 45000))
            {
                try
                {
                    result = reservationCtr.updateReservedSeat(reservationId, seatId, status);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj4);
                }
            }

            return result;
        }

        //5
        public int updateSeatsFromReservation(int reservationId, String status)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj5, 45000))
            {
                try
                {
                    result = reservationCtr.updateSeatsFromReservation(reservationId, status);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj5);
                }
            }

            return result;
        }

        //6
        public Reservation getReservation(int reservationId)
        {
            Reservation serviceReservation = new Reservation();

            if (System.Threading.Monitor.TryEnter(obj6, 45000))
            {
                try
                {
                    Customer serviceCustomer = new Customer();
                    Session serviceSession = new Session();

                    Cinema.ModelLayer.Reservation hostReservation = reservationCtr.getReservationById(reservationId);
                    try
                    {
                        serviceCustomer.CustomerFirstName = hostReservation.Customer.CustomerFirstName;
                        serviceCustomer.CustomerLastName = hostReservation.Customer.CustomerLastName;
                        serviceSession.SessionId = hostReservation.Session.SessionId;

                        serviceReservation.Customer = serviceCustomer;
                        serviceReservation.Date = hostReservation.Date;
                        serviceReservation.NoOfSeats = hostReservation.NoOfSeats;
                        serviceReservation.Price = hostReservation.Price;
                        serviceReservation.ReservationId = hostReservation.ReservationId;
                        serviceReservation.Session = serviceSession;
                        serviceReservation.Status = hostReservation.Status;
                    }
                    catch (NullReferenceException) { }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj6);
                }
            }

            return serviceReservation;
        }

        //7
        public List<Reservation> getReservations()
        {
            List<Reservation> reservationList = new List<Reservation>();

            if (System.Threading.Monitor.TryEnter(obj7, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Reservation> returnList = reservationCtr.getAllReservations();
                    if (returnList.Count != 0)
                    {
                        foreach (Cinema.ModelLayer.Reservation hostReservation in returnList)
                        {
                            Reservation serviceReservation = new Reservation();
                            Customer serviceCustomer = new Customer();
                            Session serviceSession = new Session();

                            serviceCustomer.CustomerFirstName = hostReservation.Customer.CustomerFirstName;
                            serviceCustomer.CustomerLastName = hostReservation.Customer.CustomerLastName;
                            serviceSession.SessionId = hostReservation.Session.SessionId;

                            serviceReservation.Customer = serviceCustomer;
                            serviceReservation.Date = hostReservation.Date;
                            serviceReservation.NoOfSeats = hostReservation.NoOfSeats;
                            serviceReservation.Price = hostReservation.Price;
                            serviceReservation.ReservationId = hostReservation.ReservationId;
                            serviceReservation.Session = serviceSession;
                            serviceReservation.Status = hostReservation.Status;

                            reservationList.Add(serviceReservation);
                        }
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj7);
                }
            }

            return reservationList;
        }
        
        //8
        public List<Reservation> getCustomerReservations(String custFName, String custLName)
        {
            List<Reservation> reservationList = new List<Reservation>();

            if (System.Threading.Monitor.TryEnter(obj8, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Reservation> returnList = reservationCtr.getCustomerReservations(custFName, custLName);
                    if (returnList.Count != 0)
                    {
                        foreach (Cinema.ModelLayer.Reservation hostReservation in returnList)
                        {
                            Reservation serviceReservation = new Reservation();
                            Customer serviceCustomer = new Customer();
                            Session serviceSession = new Session();

                            serviceCustomer.CustomerFirstName = hostReservation.Customer.CustomerFirstName;
                            serviceCustomer.CustomerLastName = hostReservation.Customer.CustomerLastName;
                            serviceSession.SessionId = hostReservation.Session.SessionId;

                            serviceReservation.Customer = serviceCustomer;
                            serviceReservation.Date = hostReservation.Date;
                            serviceReservation.NoOfSeats = hostReservation.NoOfSeats;
                            serviceReservation.Price = hostReservation.Price;
                            serviceReservation.ReservationId = hostReservation.ReservationId;
                            serviceReservation.Session = serviceSession;
                            serviceReservation.Status = hostReservation.Status;

                            reservationList.Add(serviceReservation);
                        }
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj8);
                }
            }

            return reservationList;
        }

        //9
        public List<Seat> getSeatsFromReservation(int reservationId)
        {
            List<Seat> seatList = new List<Seat>();

            if (System.Threading.Monitor.TryEnter(obj9, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Seat> returnList = reservationCtr.getSeatsFromReservation(reservationId);
                    if (returnList.Count != 0)
                    {
                        foreach (Cinema.ModelLayer.Seat hostSeat in returnList)
                        {
                            Seat serviceSeat = new Seat();
                            Room serviceRoom = new Room();

                            serviceSeat.RowNumber = hostSeat.RowNumber;
                            serviceSeat.SeatId = hostSeat.SeatId;
                            serviceSeat.SeatNumber = hostSeat.SeatNumber;
                            serviceSeat.Status = hostSeat.Status;
                            serviceRoom.RoomNumber = hostSeat.Room.RoomNumber;
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

        //10
        public List<int> insertReservedSeats(int reservationId, int sessionId, int noOfWantedSeats)
        {
            List<int> results = new List<int>();

            if (System.Threading.Monitor.TryEnter(obj10, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Seat> returnList = new List<Cinema.ModelLayer.Seat>();
                    returnList = algortithmCtr.getAdjancentSeats(sessionCtr.getSeatsForJaggedArray(sessionId), noOfWantedSeats);

                    if (returnList.Count == 0)
                    {
                        results.Add(-2);
                    }
                    else
                    {
                        results = reservationCtr.insertReservedSeats(reservationId, returnList);
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj10);
                }
            }

            return results;
        }

        //11
        public int deleteReservation(int reservationId)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj11, 45000))
            {
                try
                {
                    result = reservationCtr.deleteReservation(reservationId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj11);
                }
            }

            return result;
        }

        //14
        public int deleteReservedSeat(int reservationId, int seatId)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj14, 45000))
            {
                try
                {
                    result = reservationCtr.deleteReservedSeat(reservationId, seatId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj14);
                }
            }

            return result;
        }

        //12
        public int deleteSeatsFromReservation(int reservationId)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj12, 45000))
            {
                try
                {
                    result = reservationCtr.deleteSeatsFromReservation(reservationId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj12);
                }
            }

            return result;
        }

        //13
        public List<int> trustedInsertReservedSeats(String firstName, String lastName, int sessionId, int numberOfSeats, double price, String status)
        {
            /*
            lock (obj13)
            {
                List<int> results = new List<int>();
                int result = -1;
                result = reservationCtr.insertReservation(firstName, lastName, sessionId, numberOfSeats, price, status);
                List<Cinema.ModelLayer.Seat> returnList = new List<Cinema.ModelLayer.Seat>();

                returnList = algortithmCtr.getAdjancentSeats(sessionCtr.getSeatsForJaggedArray(sessionId), numberOfSeats);

                if (returnList.Count == 0)
                {
                    results.Add(-1);
                }
                else
                {
                    foreach (Cinema.ModelLayer.Seat hostSeat in returnList)
                    {
                        sessionCtr.updateSeatSchedule(sessionId, hostSeat.SeatId, "O");
                        results.Add(hostSeat.SeatNumber);
                    }
                    reservationCtr.trustedInsertReservedSeats(returnList);
                    
                }
             
                return results;
            }
            */

            
            List<int> results = new List<int>();

            if (System.Threading.Monitor.TryEnter(obj13, 25000))
            {
                try
                {
                    int result = -1;
                    result = reservationCtr.insertReservation(firstName, lastName, sessionId, numberOfSeats, price, status);

                    List<Cinema.ModelLayer.Seat> returnList = new List<Cinema.ModelLayer.Seat>();
                    returnList = algortithmCtr.getAdjancentSeats(sessionCtr.getSeatsForJaggedArray(sessionId), numberOfSeats);

                    if (returnList.Count == 0)
                    {
                        results.Add(-1);
                    }
                    else
                    {
                        foreach (Cinema.ModelLayer.Seat hostSeat in returnList)
                        {
                            sessionCtr.updateSeatSchedule(sessionId, hostSeat.SeatId, "O");
                            
                            results.Add(hostSeat.SeatNumber);
                        }
                        reservationCtr.trustedInsertReservedSeats(returnList);                        
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj13);
                }
            }

            return results;            
        }
    }
}
