using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace Cinema.ModelLayer
{
    public class Reservation
    {
        private int reservationId;
        private Customer customer;
        private Session session;
        private int noOfSeats;
        private List<Seat> reservedSeats;
        private double price;
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
       
        public Customer Customer
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
        
        public Session Session
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
        
        public List<Seat> ReservedSeats
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
  
        public double Price
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
            String currentDateString = currentDate.ToString("yyyy-MM-dd");

            return currentDateString;
        }

        
    }
}