using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DBLayer;
using Cinema.ModelLayer;

namespace Cinema.ControlLayer
{
    public class ReservationCtr
    {
        private static ReservationCtr instance = null;

        public static ReservationCtr getInstance()
        {
            if (instance == null)
            {
                instance = new ReservationCtr();
            }
            return instance;
        }

        public ReservationCtr() {}

        public int insertReservation(String firstName, String lastName, int sessionId, int numberOfSeats, double price, String status)
        { 
            IReservation _dbReservation = new DbReservation();
            Reservation reservation = new Reservation();
            Customer customer = new Customer();
            Session session = new Session();

            customer.CustomerFirstName = firstName;
            customer.CustomerLastName = lastName;

            session.SessionId = sessionId;

            reservation.Customer = customer;
            reservation.NoOfSeats = numberOfSeats;
            reservation.Price = price;
            reservation.Status = status;

            return _dbReservation.insertReservaion(reservation);
        }

        public List<int> insertReservedSeats(int reservationId, List<Seat> reservedSeats)
        {
            IReservation _dbReservation = new DbReservation();
            return _dbReservation.insertReservedSeats(reservationId, reservedSeats);
        }

        public int insertReservedSeat(int reservationId, int seatId)
        {
            IReservation _dbReservation = new DbReservation();

            Seat sit = new Seat();
            sit.SeatId = seatId;

            return _dbReservation.insertReservedSeat(reservationId, sit);
        }

        public Reservation getReservationById(int reservationId)
        {
            IReservation _dbReservation = new DbReservation();
            return _dbReservation.getReservationById(reservationId);
        }

        public List<Reservation> getCustomerReservations(String custFName, String custLName)
        {
            IReservation _dbReservation = new DbReservation();

            List<Reservation> returnList = new List<Reservation>();
            returnList = _dbReservation.getCustomerReservations(custFName, custLName);

            return returnList;
        }

        public List<Reservation> getAllReservations()
        {
            IReservation _dbReservation = new DbReservation();
            
            List<Reservation> returnList = new List<Reservation>();
            returnList = _dbReservation.getAllReservations();
            
            return returnList;
        }

        public List<Seat> getSeatsFromReservation(int reservationId)
        {
            IReservation _dbReservation = new DbReservation();

            List<Seat> returnList = new List<Seat>();           
            returnList = _dbReservation.getSeatsFromReservation(reservationId);
            
            return returnList;
        }

        public int updateReservation(String firstName, String lastName, int sessionId, int numberOfSeats, int price, String status, int reservationId)
        {
            IReservation _dbReservation = new DbReservation();
            Reservation rzv = new Reservation();
            Customer cust = new Customer();
            Session ses = new Session();

            cust.CustomerFirstName = firstName;
            rzv.Customer = cust;
            cust.CustomerLastName = lastName;
            rzv.Customer = cust;
            ses.SessionId = sessionId;
            rzv.Session = ses;
            rzv.NoOfSeats = numberOfSeats;
            rzv.Price = price;
            rzv.Status = status;
            rzv.ReservationId = reservationId;

            return _dbReservation.updateReservation(rzv);
        }

        public int updateReservedSeat(int reservationId, int seatId, String status)
        {
            IReservation _dbRezervation = new DbReservation();
            return _dbRezervation.updateReservedSeat(reservationId, seatId, status);
        }

        public int updateSeatsFromReservation(int reservationId, String status)
        {
            IReservation _dbRezervation = new DbReservation();
            return _dbRezervation.updateSeatsFromReservation(reservationId, status);
        }
    }
}
