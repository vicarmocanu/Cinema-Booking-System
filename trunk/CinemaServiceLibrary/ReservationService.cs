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
        private static ReservationCtr reservationCtr = ReservationCtr.getInstance();

        public int insertReservation(String firstName, String lastName, int sessionId, int numberOfSeats, double price, String status)
        {
            return reservationCtr.insertReservation(firstName, lastName, sessionId, numberOfSeats, price, status);
        }

        public int updateReservation(string firstName, string lastName, int sessionId, int numberOfSeats, int price, string status, int reservationId)
        {
            return reservationCtr.updateReservation(firstName, lastName, sessionId, numberOfSeats, price, status, reservationId);
        }

        public int insertReservedSeat(int reservationId, int seatId)
        {
            return reservationCtr.insertReservedSeat(reservationId, seatId);
        }

        public int updateReservedSeat(int reservationId, int seatId, String status)
        {
            return reservationCtr.updateReservedSeat(reservationId, seatId, status);
        }

        public int updateSeatsFromReservation(int reservationId, String status)
        {
            return reservationCtr.updateSeatsFromReservation(reservationId, status);
        }

        public Reservation getReservation(int reservationId)
        {
            Reservation serviceReservation = new Reservation();
            Customer serviceCustomer = new Customer();
            Session serviceSession = new Session();
            Movie serviceMovie = new Movie();
            Room serviceRoom = new Room();

            Cinema.ModelLayer.Reservation hostReservation = reservationCtr.getReservationById(reservationId);           

            serviceMovie.MovieId = hostReservation.Session.Movie.MovieId;
            serviceMovie.Name = hostReservation.Session.Movie.Name;

            serviceRoom.RoomNumber = hostReservation.Session.Room.RoomNumber;

            serviceCustomer.CustomerFirstName = hostReservation.Customer.CustomerFirstName;
            serviceCustomer.CustomerLastName = hostReservation.Customer.CustomerLastName;

            serviceSession.Date = hostReservation.Session.Date;
            serviceSession.EnterTime = hostReservation.Session.EnterTime;
            serviceSession.ExitTime = hostReservation.Session.ExitTime;
            serviceSession.Movie = serviceMovie;
            serviceSession.Price = hostReservation.Session.Price;
            serviceSession.Room = serviceRoom;
            serviceSession.SessionId = hostReservation.Session.SessionId;

            serviceReservation.Customer = serviceCustomer;
            serviceReservation.Date = hostReservation.Date;
            serviceReservation.NoOfSeats = hostReservation.NoOfSeats;
            serviceReservation.Price = hostReservation.Price;
            serviceReservation.ReservationId = hostReservation.ReservationId;
            serviceReservation.Session = serviceSession;
            serviceReservation.Status = hostReservation.Status;

            return serviceReservation;
        }

        public List<Reservation> getReservations()
        {
            List<Cinema.ModelLayer.Reservation> returnList = reservationCtr.getAllReservations();
            List<Reservation> reservationList = new List<Reservation>();
            foreach (Cinema.ModelLayer.Reservation hostReservation in returnList)
            {
                Reservation serviceReservation = new Reservation();
                Customer serviceCustomer = new Customer();
                Session serviceSession = new Session();
                Movie serviceMovie = new Movie();
                Room serviceRoom = new Room();

                serviceMovie.MovieId = hostReservation.Session.Movie.MovieId;
                serviceMovie.Name = hostReservation.Session.Movie.Name;

                serviceRoom.RoomNumber = hostReservation.Session.Room.RoomNumber;

                serviceCustomer.CustomerFirstName = hostReservation.Customer.CustomerFirstName;
                serviceCustomer.CustomerLastName = hostReservation.Customer.CustomerLastName;

                serviceSession.Date = hostReservation.Session.Date;
                serviceSession.EnterTime = hostReservation.Session.EnterTime;
                serviceSession.ExitTime = hostReservation.Session.ExitTime;
                serviceSession.Movie = serviceMovie;
                serviceSession.Price = hostReservation.Session.Price;
                serviceSession.Room = serviceRoom;
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
            return reservationList;
        }

        public List<Reservation> getCustomerReservations(String custFName, String custLName)
        {
            List<Cinema.ModelLayer.Reservation> returnList = reservationCtr.getCustomerReservations(custFName, custLName);
            List<Reservation> reservationList = new List<Reservation>();
            foreach (Cinema.ModelLayer.Reservation hostReservation in returnList)
            {
                Reservation serviceReservation = new Reservation();
                Customer serviceCustomer = new Customer();
                Session serviceSession = new Session();
                Movie serviceMovie = new Movie();
                Room serviceRoom = new Room();
                
                serviceMovie.MovieId = hostReservation.Session.Movie.MovieId;
                serviceMovie.Name = hostReservation.Session.Movie.Name;

                serviceRoom.RoomNumber = hostReservation.Session.Room.RoomNumber;

                serviceCustomer.CustomerFirstName = hostReservation.Customer.CustomerFirstName;
                serviceCustomer.CustomerLastName = hostReservation.Customer.CustomerLastName;

                serviceSession.Date = hostReservation.Session.Date;
                serviceSession.EnterTime = hostReservation.Session.EnterTime;
                serviceSession.ExitTime = hostReservation.Session.ExitTime;
                serviceSession.Movie = serviceMovie;
                serviceSession.Price = hostReservation.Session.Price;
                serviceSession.Room = serviceRoom;
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
            return reservationList;
        }

        public List<Seat> getSeatsFromReservation(int reservationId)
        {
            List<Cinema.ModelLayer.Seat> returnList = reservationCtr.getSeatsFromReservation(reservationId);
            List<Seat> seatList = new List<Seat>();
            foreach(Cinema.ModelLayer.Seat hostSeat in returnList)
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
            return seatList;
        }
    }
}
