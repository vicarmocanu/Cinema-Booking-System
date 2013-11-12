using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ModelLayer
{
    class Reservation
    {
        private int reservationId;
        public int ReservationId
        {
            get { return reservationId; }
            set { reservationId = value; }
        }

        private List<Customer> customer;
        public List<Customer> Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private List<Session> session;
        public List<Session> Session
        {
            get { return session; }
            set { session = value; }
        }

        private int noOfSeats;
        public int NoOfSeats
        {
            get { return noOfSeats; }
            set { noOfSeats = value; }
        }

        private List<Seat> reservedSeats;
        public List<Seat> ReservationSeats
        {
            get { return reservedSeats; }
            set { reservedSeats = value; }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private String status;
        public String Status
        {
            get { return status; }
            set { status = value; }
        }

        public Reservation(int reservationId, List<Customer> customer, 
            List<Session> session, int noOfSeats, List<Seat> reservedSeats, 
            int price, DateTime date, String status)
        {
            reservationId = reservationId;
            customer = customer;
            session = session;
            noOfSeats = noOfSeats;
            reservedSeats = reservedSeats;
            price = price;
            date = date;
            status = status;
        }

        public Reservation()
        {
 
        }
    }
}