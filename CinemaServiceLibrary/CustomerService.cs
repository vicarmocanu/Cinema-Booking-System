using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;

namespace CinemaServiceLibrary
{
    public class CustomerService : ICustomerService
    {
        private static CustomerCtr customerCtr = new CustomerCtr();

        public int insertCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password)
        {
            return customerCtr.insertCustomer(fName, lName, city, address, email, phoneNo, username, password);
        }

        public int updateCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password)
        {
            return customerCtr.updateCustomer(fName, lName, city, address, email, phoneNo, username, password);
        }
    }
}
