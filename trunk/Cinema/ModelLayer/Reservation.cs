using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace Cinema.ModelLayer
{
    class Reservation
    {
        private int reservationId;
        private Customer customer;
        private Session session;
        private int noOfSeats;
        private List<Seat> reservedSeats;
        private int price;
        private String date;
        private String status;

        //constructor
        public Reservation() { }

        //getters and setters

        public int ReservationId
        {
            get 
            {
                return reservationId; 
            }
            set
            {
                reservationId = value; 
            }
        }
       
        internal Customer Customer
        {
            get 
            { 
                return customer; 
            }
            set 
            { 
                customer = value; 
            }
        }
        
        internal Session Session
        {
            get
            {
                return session;
            }
            set 
            { 
                session = value;
            }
        }

        public int NoOfSeats
        {
            get
            {
                return noOfSeats;
            }
            set
            {
                noOfSeats = value;
            }
        }
        
        internal List<Seat> ReservedSeats
        {
            get 
            { 
                return reservedSeats;
            }
            set 
            { 
                reservedSeats = value; 
            }
        }
  
        public int Price
        {
            get 
            { 
                return price;
            }
            set 
            {
                price = value;
            }
        }
        
        public String Date
        {
            get
            { 
                return date; 
            }
            set 
            { 
                date = value;
            }
        }
        
        public String Status
        {
            get 
            {
                return status;
            }
            set
            { 
                status = value;
            }
        }

        //own methods

        //get the current date
        public String getCurrentDate()
        {
            DateTime currentDate = DateTime.Now;
            String format = "YYYY-MM-DD";
            String formattedDate = "1900-01-01";

            try
            {
                formattedDate = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture).ToString();
            }
            catch (Exception) {}

            return formattedDate;
        }

        //get a suitable price for multiple chairs
        public int seatsPrice()
        {
            int totalPrice = 0;
            totalPrice = noOfSeats * price; 
            return totalPrice;
        }

        //the actual noOfSeats
        public void setCorrectNoOfSeats()
        {
            this.noOfSeats = reservedSeats.Count();
        }
    }
}