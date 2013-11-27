using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DBLayer;
using Cinema.ModelLayer;

namespace Cinema.ControlLayer
{
    class RoomCtr
    {
         private static RoomCtr instance = null;

        public static RoomCtr getInstance()
        {
            if (instance == null)
            {
                instance = new RoomCtr();
            }
            return instance;
        }

        public RoomCtr()
        { 
        
        }

        public int insertRoom(int roomNumber, int numberOfSeats)
        {
            IRoom _dbRoom = new DbRoom();
            Room rom = new Room();

            rom.NumberOfSeats = numberOfSeats;
            rom.RoomNumber = roomNumber;

            return _dbRoom.insertRoom(rom);
        }

        public int updateRoom(int roomNumber, int numberOfSeats)
        {
            IRoom _dbRoom = new DbRoom();
            Room rom = new Room();

            rom.RoomNumber = roomNumber;
            rom.NumberOfSeats = numberOfSeats;


            return _dbRoom.updateRoom(rom);
        }

        public List<Room> getRooms()
        {
            List<Room> returnList = new List<Room>();
            IRoom _dbRoom = new DbRoom();
            returnList = _dbRoom.getRooms();
            return returnList;
        }

        public Room getRoomByNumber(int number)
        {
            IRoom _dbRoom = new DbRoom();
            return _dbRoom.getRoomByNumber(number);
           
        }
    }
}
