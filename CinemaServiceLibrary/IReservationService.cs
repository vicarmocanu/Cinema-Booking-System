using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    [ServiceContract]
    public interface IReservationService
    {
        [OperationContract]
        int insertReservation(String firstName, String lastName, int sessionId, int numberOfSeats, int price);
        [OperationContract]
        int updateReservation(String firstName, String lastName, int sessionId, int numberOfSeats, int price);
    }
}
