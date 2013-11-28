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
        Reservation getReservationById(int reservationId);
        List<Reservation> getAllReservations();
        List<Seat> getSeatsFromReservation(int reservationId);
        int updateReservation(Reservation reservation);
        int updateReservedSeat(int reservationId, int seatId, String status);
        int updateSeatsFromReservation(int reservationId, String status);
        int insertReservaion(Reservation reservation);

    }
}
