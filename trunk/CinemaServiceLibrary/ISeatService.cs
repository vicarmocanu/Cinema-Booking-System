using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
       [ServiceContract]
    public interface ISeatService
    {
           [OperationContract]
           public int insertSeat(int seatNumber, int rowNumber, int roomNumber);
           [OperationContract]
           public int updateSeat(int seatID, int seatNumber, int rowNumber, int roomNumber);

       
    }
}
