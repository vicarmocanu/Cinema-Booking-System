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


        public int insertSeat( int seatNumber, int rowNumber,int roomNumber, int numberOfSeats)
        {
            ISeat _dbSeat = new DbSeat();
            Seat seat = new Seat();
            Room rom = new Room();

            
            seat.SeatNumber = seatNumber;
            seat.RowNumber = rowNumber;
            rom.RoomNumber = roomNumber;
            seat.Room = rom;

            

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

        public int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber)
        {
            ISeat _dbSeat = new DbSeat();
            Seat seat = new Seat();
            Room rom = new Room();

            seat.SeatId = seatID;
            seat.SeatNumber = seatNumber;
            seat.RowNumber = rowNumber;
            rom.RoomNumber = roomNumber;
            seat.Room = rom;
            

            return _dbSeat.updateSeat(seat);
           
        }

        public List<Seat> getRoomSeats(int roomNumber)
        {
            List<Seat> returnList = new List<Seat>();
            ISeat _dbSeat = new DbSeat();
            returnList = _dbSeat.getRoomSeats(roomNumber);
            return returnList;

        }

        public List<int> insertSeatMatrix(int rows, int columns, int roomNumber)
        { 
            List<int> returnList = new List<int>();
            ISeat _dbSeat = new DbSeat();
            returnList = _dbSeat.insertSeatMatrix(rows,columns,roomNumber);
            return returnList;

        }


    }
}
