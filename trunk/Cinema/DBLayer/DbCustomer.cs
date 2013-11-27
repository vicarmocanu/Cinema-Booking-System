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
    class DbCustomer : ICustomer
    {
        private static SqlCommand dbCmd = null;

        //build a customer object based on the db reader
        private static Customer createCustomer(IDataReader dbReader)
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

        //create a customer
        public int insertCustomer(Customer customer)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Customer VALUES " +
                "('" + customer.CustomerFirstName +
                "','" + customer.CustomerLastName +
                "','" + customer.CustomerUsername +
                "','" + customer.CustomerPassword +
                "','" + customer.CustomerCity + 
                "','" + customer.CustomerAddress + 
                "','" + customer.CustomerEmail +
                "','" + customer.CustomerPhoneNo + "')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }
        
        //get all customers
        public List<Customer> getCustomers()
        {
            List<Customer> returnList = new List<Customer>();

            string sqlQuery = "SELECT * FROM Customer";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Customer customer = new Customer();

            while (dbReader.Read())
            {
                customer = createCustomer(dbReader);
                returnList.Add(customer);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }
                
        //get a customer by his first and last name
        public Customer getCustomerByName(String fName, String lName)
        {
            string sqlQuery = "SELECT * FROM Customer WHERE fName= '" + fName 
                + "' AND lName= '" + lName + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Customer customer = new Customer();

            if(dbReader.Read())
            {
                customer = createCustomer(dbReader);
            }
            else
            {
                customer = null;
            }

            AccessDbSQLClient.Close();

            return customer;
        }

        //get a customer by his username
        public Customer getCustomerByUsername(String username)
        {
            string sqlQuery = "SELECT * FROM Customer WHERE username= '" + username + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Customer customer = new Customer();

            if (dbReader.Read())
            {
                customer = createCustomer(dbReader);
            }
            else
            {
                customer = null;
            }

            AccessDbSQLClient.Close();

            return customer;
        }

        //update a customer based on his first and last name
        public int updateCustomer(Customer customer)
        {
            int result = -1;

            string sqlQuery = "UPDATE Customer SET " +
                "username='" + customer.CustomerUsername + "', " +
                "city='" + customer.CustomerCity + "', " +
                "address='" + customer.CustomerAddress + "', " +
                "email='" + customer.CustomerEmail + "', " +
                "phoneNo='" + customer.CustomerPhoneNo + "', " +
                "password='" + customer.CustomerPassword + "' " +
                "WHERE fName='" + customer.CustomerFirstName + "' AND " +
                "lName='" + customer.CustomerLastName + "'";

            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException sqlEx)
            { }

            return result;             
        }
    }
}