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
        private static ReservationCtr reservationCtr = new ReservationCtr();

        public int insertReservation(String firstName, String lastName, int sessionId, int numberOfSeats, int price)
        {
            return reservationCtr.insertReservation(firstName, lastName, sessionId, numberOfSeats, price);
        }

        public int updateReservation(String firstName, String lastName, int sessionId, int numberOfSeats, int price, String status, int reservationId)
        {
            return reservationCtr.updateReservation(firstName, lastName, sessionId, numberOfSeats, price, status, reservationId);
        }
           
    }
}
