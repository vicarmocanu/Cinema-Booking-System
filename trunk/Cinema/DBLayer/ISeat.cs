using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;
using Cinema.DBLayer;

namespace Cinema.DBLayer
{
    interface ISeat
    {
        List<int> insertSeatMatrix(int rows, int columns, int roomNumber);
        int insertSeat(Seat seat);
        List<Seat> getSeats();
        Seat getSeatById(int id);
        int updateSeat(Seat seat);
        List<Seat> getRoomSeats(int roomNumber);
        int deleteSeat(int id);
        int deleteRoomSeats(int roomNumber);
    }
}
