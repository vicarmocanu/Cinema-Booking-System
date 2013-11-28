using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.DBLayer
{
    interface IReservation
    {
       int insertReservaion(Reservation reservation);
       List<int> insertReservedSeats(int reservationId, List<Seat> reservedSeats);
       int insertReservedSeat(int reservationId, Seat seat);
       Reservation getReservationById(int reservationId);
       List<Reservation> getCustomerReservations(String custFName, String custLName);
       List<Reservation> getAllReservations();
       List<Seat> getSeatsFromReservation(int reservationId);
       int updateReservation(Reservation reservation);
       int updateReservedSeat(int reservationId, int seatId, String status);
       int updateSeatsFromReservation(int reservationId, String status);

    }
}
