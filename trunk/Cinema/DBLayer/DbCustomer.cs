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
            customer.CustomerFirstName = dbReader["fName"].ToString();
            customer.CustomerLastName = dbReader["lName"].ToString();
            customer.CustomerPassword = dbReader["password"].ToString();
            customer.CustomerPhoneNo = dbReader["phoneNo"].ToString();
            customer.CustomerUsername = dbReader["userName"].ToString();
        
            return customer;
        }

        //insert a customer
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

            while (dbReader.Read())
            {
                Customer customer = new Customer();
                customer = createCustomer(dbReader);
                returnList.Add(customer);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }
                
        //get a customer - fName, lName
        public Customer getCustomerByName(String fName, String lName)
        {
            string sqlQuery = "SELECT * FROM Customer WHERE " +
                "fName= '" + fName + "' AND lName= '" + lName + "'";
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

        //get a customer - username
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

        //update a customer - fName, lName
        public int updateCustomer(Customer customer)
        {
            int result = -1;

            string sqlQuery = "UPDATE Customer SET " +
                "userName='" + customer.CustomerUsername + "', " +
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
            catch (SqlException)
            { }

            return result;             
        }

        //delete a customer - fname, lname
        public int deleteCustomerByName(String fName, String lName)
        {
            int result = -1;
            string sqlQuery = "DELETE FROM Customer WHERE fName= '" + fName +
                "' AND lName= '" + lName + "'";
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

        //delete a customer - username
        public int deleteCustomerByUsername(String userName)
        {
            int result = -1;
            string sqlQuery = "DELETE FROM Customer WHERE userName= '" + userName + "'";
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
    }
}