using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;
using Cinema.DBLayer;

namespace Cinema.ControlLayer
{
    class SeatCtr
    {
         private static SeatCtr instance = null;

        public static SeatCtr getInstance()
        {
            if (instance == null)
            {
                instance = new SeatCtr();
            }
            return instance;
        }

        public SeatCtr()
        { 
        
        }

        public int insertSeat(int seatID, int seatNumber, int rowNumber,int roomNumber, int numberOfSeats, String status)
        {
            ISeat _dbSeat = new DbSeat();
            Seat seat = new Seat();
            Room rom = new Room();

            seat.SeatId = seatID;
            seat.SeatNumber = seatNumber;
            seat.RowNumber = rowNumber;
            rom.RoomNumber = rowNumber;
            rom.NumberOfSeats = numberOfSeats;
            seat.Status = status;

            return _dbSeat.insertSeat(seat);


        
        }

        public List<Seat> getSeats()
        {
            List<Seat> returnList = new List<Seat>();
            ISeat _dbSeat = new DbSeat();
            returnList = _dbSeat.getSeats();
            return returnList;
        
        }

        public Seat getSeatById(int id)
        {
            ISeat _dbSeat = new DbSeat();
            return _dbSeat.getSeatById(id);
        
        }

        public int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber, int numberOfSeats, String status)
        {
            ISeat _dbSeat = new DbSeat();
            Seat seat = new Seat();
            Room rom = new Room();

            seat.SeatId = seatID;
            seat.SeatNumber = seatNumber;
            seat.RowNumber = rowNumber;
            rom.RoomNumber = rowNumber;
            rom.NumberOfSeats = numberOfSeats;
            seat.Status = status;

            return _dbSeat.updateSeat(seat);
           
        }
    }
}
