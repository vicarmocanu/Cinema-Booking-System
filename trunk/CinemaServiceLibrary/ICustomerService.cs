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

        [OperationContract]
        int deleteCustomerByName(String fName, String lName);

        [OperationContract]
        int deleteCustomerByUserName(string userName);

        [OperationContract]
        Customer getCustomerByName(String fName, String lName);

        [OperationContract]
        Customer getCustomerByUsername(String username);

        [OperationContract]
        List<Customer> getCustomers();
    }

    [DataContract]
    public class Customer
    {
        private String fName;
        private String lName;
        private String city;
        private String address;
        private String email;
        private String phoneNo;
        private String username;
        private String password;

        [DataMemberAttribute]
        public String CustomerFirstName
        {
            get { return fName; }
            set { fName = value; }
        }

        [DataMemberAttribute]
        public String CustomerLastName
        {
            get { return lName; }
            set { lName = value; }
        }

        [DataMemberAttribute]
        public String CustomerCity
        {
            get { return city; }
            set { city = value; }
        }

        [DataMemberAttribute]
        public String CustomerAddress
        {
            get { return address; }
            set { address = value; }
        }

        [DataMemberAttribute]
        public String CustomerEmail
        {
            get { return email; }
            set { email = value; }
        }

        [DataMemberAttribute]
        public String CustomerPhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        [DataMemberAttribute]
        public String CustomerUsername
        {
            get { return username; }
            set { username = value; }
        }

        [DataMemberAttribute]
        public String CustomerPassword
        {
            get { return password; }
            set { password = value; }
        }
    }
}
