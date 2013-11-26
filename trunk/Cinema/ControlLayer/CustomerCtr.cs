using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DBLayer;
using Cinema.ModelLayer;

namespace Cinema.ControlLayer
{
    class CustomerCtr
    {
        
        private static CustomerCtr instance = null;

        public static CustomerCtr getInstance()
        {
            if (instance == null)
            {
                instance = new CustomerCtr();
            }
            return instance;
        }

        public CustomerCtr()
        { 
        
        }

        public int insertCustomer(String fName, String lName, String city, String address, String email, String phoneNo, String username, String password)
        {
            ICustomer _dbCustomer = new DbCustomer();
            Customer cust = new Customer();
            cust.CustomerFirstName = fName;
            cust.CustomerLastName = lName;
            cust.CustomerCity = city;
            cust.CustomerAddress = address;
            cust.CustomerEmail = email;
            cust.CustomerPhoneNo = phoneNo;
            cust.CustomerUsername = username;
            cust.CustomerPassword = password;

            return _dbCustomer.insertCustomer(cust);
        }
        public List<Customer> getCustomers()
        {
            List<Customer> returnList = new List<Customer>();
            DbCustomer _dbCustomer = new DbCustomer();
            returnList = _dbCustomer.getCustomers();
            return returnList;

        }
        public Customer getCustomerByName(String fName, String lName)
        {
            ICustomer _dbCustomer = new DbCustomer();
            return _dbCustomer.getCustomerByName(fName, lName);
        }
        public Customer getCustomerByUsername(String username)
        {
            ICustomer _dbCustomer = new DbCustomer();
            return _dbCustomer.getCustomerByUsername(username);
        }
        public int updateCustomer(String fName, String lName, String city, String address, String email, String phoneNo, String username, String password)
        {
            ICustomer _dbCustomer = new DbCustomer();
            Customer cust = new Customer();
            cust.CustomerFirstName = fName;
            cust.CustomerLastName = lName;
            cust.CustomerCity = city;
            cust.CustomerAddress = address;
            cust.CustomerEmail = email;
            cust.CustomerPhoneNo = phoneNo;
            cust.CustomerUsername = username;
            cust.CustomerPassword = password;

            return _dbCustomer.updateCustomer(cust);     
        }
    }
}
