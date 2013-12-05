using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        int insertCustomer(String fName, String lName, String city, String address, String email, String phoneNo, String username, String password);

        [OperationContract]
        int updateCustomer(String fName, String lName, String city, String address, String email, String phoneNo, String username, String password);
    }
}
