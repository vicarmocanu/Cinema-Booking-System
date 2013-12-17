using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    [ServiceContract]
    public interface IReservationService
    {
        [OperationContract]
        int insertReservation(String firstName, String lastName, int sessionId, int numberOfSeats, double price, String status);

        [OperationContract]
        int updateReservation(String firstName, String lastName, int sessionId, int numberOfSeats, int price, String status, int reservationId);

        [OperationContract]
        int insertReservedSeat(int reservationId, int seatId);

        [OperationContract]
        int updateReservedSeat(int reservationId, int seatId, String status);

        [OperationContract]
        int updateSeatsFromReservation(int reservationId, String status);

        [OperationContract]
        Reservation getReservation(int reservationId);

        [OperationContract]
        List<Reservation> getReservations();

        [OperationContract]
        List<Reservation> getCustomerReservations(String custFName, String custLName);

        [OperationContract]
        List<Seat> getSeatsFromReservation(int reservationId);

        [OperationContract]
        List<int> insertReservedSeats(int reservationId, int sessionId, int noOfWantedSeats);

        [OperationContract]
        int deleteReservation(int reservationId);

        [OperationContract]
        int deleteReservedSeat(int reservationId, int seatId);

        [OperationContract]
        int deleteSeatsFromReservation(int reservationId);

        [OperationContract]
        List<int> trustedInsertReservedSeats(String firstName, String lastName, int sessionId, int numberOfSeats, double price, String status);
    }

    [DataContract]
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

        [DataMemberAttribute]
        public int ReservationId
        {
            get { return reservationId; }
            set { reservationId = value; }
        }

        [DataMemberAttribute]
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        [DataMemberAttribute]
        public Session Session
        {
            get { return session; }
            set { session = value; }
        }

        [DataMemberAttribute]
        public int NoOfSeats
        {
            get { return noOfSeats; }
            set { noOfSeats = value; }
        }

        [DataMemberAttribute]
        public List<Seat> ReservedSeats
        {
            get { return reservedSeats; }
            set { reservedSeats = value; }
        }

        [DataMemberAttribute]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMemberAttribute]
        public String Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMemberAttribute]
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
