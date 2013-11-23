using Cinema.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DBLayer
{
    interface ICustomer
    {
        //create a customer
        public int insertCustomer(Customer customer);

        //get all customers
        public List<Customer> getCustomers();

        //get a customer by his first and last name
        public Customer getCustomerByName(String fName, String lName);

        //get a customer by his username
        public Customer getCustomerByUsername(String username);

        //update a customer based on his first and last name
        public int updateCustomer(Customer customer);
    }
}
