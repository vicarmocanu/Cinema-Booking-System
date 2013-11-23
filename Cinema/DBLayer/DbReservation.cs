using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Cinema.ModelLayer;
using Cinema.DBLayer;
using System.Security.Cryptography;

namespace Cinema.DBLayer
{
    class DbReservation: IReservation
    {
        private static SqlCommand dbCmd = null;

        private static createCustomer(IDataReader dbReader)
        {
            Customer customer = new Customer();

            customer.CustomerAddress = dbReader["address"].ToString();
            customer.CustomerCity = dbReader["city"].ToString();
            customer.CustomerEmail = dbReader["email"].ToString();
            customer.CustomerFirstName = dbReader["fname"].ToString();
            customer.CustomerLastName = dbReader["lname"].ToString();
            customer.CustomerPassword = dbReader["password"].ToString();
            customer.CustomerPhoneNo = dbReader["phoneNo"].ToString();
            customer.CustomerUsername = dbReader["username"].ToString();

            return customer;
        }
    }
}
