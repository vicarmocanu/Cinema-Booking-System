using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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

        private Customer customer;
        internal Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private Session session;
        internal Session Session
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

        private LinkedList<Seat> reservedSeats;
        internal LinkedList<Seat> ReservedSeats
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

        private String date;
        public String Date
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

        public Reservation(int reservationId, Customer customer, Session session, int noOfSeats, LinkedList<Seat> reservedSeats, int price, String date, String status)
        {
            this.reservationId = reservationId;
            this.customer = customer;
            this.session = session;
            this.noOfSeats = noOfSeats;
            this.reservedSeats = reservedSeats;
            this.price = price;
            this.date = date;
            this.status = status;
        }       

        public Reservation()
        {
 
        }
    }
}