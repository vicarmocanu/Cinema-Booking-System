using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    [ServiceContract]
    public interface IRoomService
    {
        [OperationContract]
        int insertRoom(int roomNumber, int numberOfSeats);
    }
}
