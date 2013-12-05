using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    
    [ServiceContract]
    public interface ISessionService
    {
        [OperationContract]
        int insertSession(int movieId, String EnterTime, String ExitTime, String Date, Double Price);

        [OperationContract]
        int updateSession(int MovieId, String Date, String EnterTime, String ExitTime, Double Price, int SessionId);
       
    }
}
