using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.DBLayer
{
    interface ICustomer
    {       
       int insertCustomer(Customer customer);
       List<Customer> getCustomers();
       Customer getCustomerByName(String fName, String lName);
       Customer getCustomerByUsername(String username);
       int updateCustomer(Customer customer);
    }
}
