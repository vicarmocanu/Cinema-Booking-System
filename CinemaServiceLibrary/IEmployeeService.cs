using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        int insertEmployee(String fName, String lName, String username, String password);

        [OperationContract]
        int updateEmployee(String fName, String lName, String username, String password);
    }
}
