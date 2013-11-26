using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.DBLayer
{
    interface ISeat
    {
        List<int> insertSeatMatrix(int rows, int columns, int roomNumber, int seatId);
        int insertSeat(Seat seat);
        List<Seat> getSeats();
        Seat getSeatById(int id);
        int updateSeat(Seat seat);
    }
}
