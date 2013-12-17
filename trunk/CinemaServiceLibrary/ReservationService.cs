using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;

namespace CinemaServiceLibrary
{   
    public class ReservationService : IReservationService
    {
        private System.Object lockThis = new System.Object();
        private static ReservationCtr reservationCtr = ReservationCtr.getInstance();
        private static AlgorithmCtr algortithmCtr = AlgorithmCtr.getInstance();
        private static SessionCtr sessionCtr = SessionCtr.getInstance();

        public int insertReservation(String firstName, String lastName, int sessionId, int numberOfSeats, double price, String status)
        {
            lock (lockThis)
            {
                return reservationCtr.insertReservation(firstName, lastName, sessionId, numberOfSeats, price, status);
            }
        }

        public int updateReservation(string firstName, string lastName, int sessionId, int numberOfSeats, int price, string status, int reservationId)
        {
            lock (lockThis)
            {
                return reservationCtr.updateReservation(firstName, lastName, sessionId, numberOfSeats, price, status, reservationId);
            }
        }

        public int insertReservedSeat(int reservationId, int seatId)
        {
            lock (lockThis)
            {
                return reservationCtr.insertReservedSeat(reservationId, seatId);
            }
        }

        public int updateReservedSeat(int reservationId, int seatId, String status)
        {
            lock (lockThis)
            {
                return reservationCtr.updateReservedSeat(reservationId, seatId, status);
            }
        }

        public int updateSeatsFromReservation(int reservationId, String status)
        {
            lock (lockThis)
            {
                return reservationCtr.updateSeatsFromReservation(reservationId, status);
            }
        }

        public Reservation getReservation(int reservationId)
        {
            lock (lockThis)
            {
                Reservation serviceReservation = new Reservation();
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

                return serviceReservation;
            }
        }

        public List<Reservation> getReservations()
        {
            lock (lockThis)
            {
                List<Reservation> reservationList = new List<Reservation>();

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
                return reservationList;
            }
        }

        public List<Reservation> getCustomerReservations(String custFName, String custLName)
        {
            lock (lockThis)
            {
                List<Reservation> reservationList = new List<Reservation>();

                List<Cinema.ModelLayer.Reservation> returnList = reservationCtr.getCustomerReservations(custFName, custLName);
                if(returnList.Count != 0 )
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

                return reservationList;
            }
        }

        public List<Seat> getSeatsFromReservation(int reservationId)
        {
            lock (lockThis)
            {
                List<Seat> seatList = new List<Seat>();

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
                
                return seatList;
            }
        }

        public List<int> insertReservedSeats(int reservationId, int sessionId, int noOfWantedSeats)
        {
            lock (lockThis)
            {
                List<int> results = new List<int>();
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
                return results;
            }
        }

        public int deleteReservation(int reservationId)
        {
            lock (lockThis)
            {
                return reservationCtr.deleteReservation(reservationId);
            }
        }

        public int deleteReservedSeat(int reservationId, int seatId)
        {
            lock (lockThis)
            {
                return reservationCtr.deleteReservedSeat(reservationId, seatId);
            }
        }

        public int deleteSeatsFromReservation(int reservationId)
        {
            lock (lockThis)
            {
                return reservationCtr.deleteSeatsFromReservation(reservationId);
            }
        }

        public List<int> trustedInsertReservedSeats(String firstName, String lastName, int sessionId, int numberOfSeats, double price, String status)
        {
            lock (lockThis)
            {
                List<int> results = new List<int>();
                
                int result = -1;
                result = reservationCtr.insertReservation(firstName, lastName, sessionId, numberOfSeats, price, status) ;
                List<Cinema.ModelLayer.Seat> returnList = new List<Cinema.ModelLayer.Seat>();

                returnList = algortithmCtr.getAdjancentSeats(sessionCtr.getSeatsForJaggedArray(sessionId), numberOfSeats);

                if (returnList.Count == 0)
                {
                    results.Add(-1);
                }
                else
                {
                    reservationCtr.trustedInsertReservedSeats(returnList);
                    foreach (Cinema.ModelLayer.Seat hostSeat in returnList)
                    {
                        sessionCtr.updateSeatSchedule(sessionId, hostSeat.SeatId, "O");
                        results.Add(hostSeat.SeatNumber);
                    }

                }

                return results;
            }
        }
    }
}
