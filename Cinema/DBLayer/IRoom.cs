using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.DBLayer
{
    interface IRoom
    {
        static Room createRoom(IDataReader dbReader);
        int insertRoom(Room room);
        List<Room> getRooms();
        Room getRoomByNumber(int number);
        int updateRoom(Room room);
    }
}
