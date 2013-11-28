using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DBLayer;
using Cinema.ModelLayer;

namespace Cinema.ControlLayer
{
    class ReservationCtr
    {
        public Reservation getReservationById(int reservationId)
        {
            IReservation _dbReservation = new DbReservation();
            return _dbReservation.getReservationById(reservationId);

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
            List<Seat> returnList = new List<Seat>();
            IReservation _dbReservation = new DbReservation();
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
            Reservation rzv = new Reservation();
            Seat seat = new Seat();

            rzv.Status = status;

            return _dbRezervation.updateReservedSeat(reservationId, seatId, status);

            
        }
        public int updateSeatsFromReservation(int reservationId, String status)
        {
            IReservation _dbRezervation = new DbReservation();
            Reservation rzv = new Reservation();

            rzv.Status = status;

            return _dbRezervation.updateSeatsFromReservation(reservationId, status);
        }
        int insertReservaion(String firstName, String lastName, int sessionId, int numberOfSeats, int price  )
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

            return _dbReservation.insertReservaion(rzv);
        }
    }
}
