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
            
            dbCmd = new SqlCommand();
            string sqlQuery = "INSERT INTO Customer VALUES " +
                "(@fName, @lName, @userName, @password, @city, @address, @email, @phoneNo)";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter fName = new SqlParameter("@fName", SqlDbType.NVarChar, 50);
            fName.Value = customer.CustomerFirstName;
            dbCmd.Parameters.Add(fName);

            SqlParameter lName = new SqlParameter("@lName", SqlDbType.NVarChar, 50);
            lName.Value = customer.CustomerLastName;
            dbCmd.Parameters.Add(lName);

            SqlParameter userName = new SqlParameter("@userName", SqlDbType.NVarChar, 50);
            userName.Value = customer.CustomerUsername;
            dbCmd.Parameters.Add(userName);

            SqlParameter password = new SqlParameter("@password", SqlDbType.NVarChar, 50);
            password.Value = customer.CustomerPassword;
            dbCmd.Parameters.Add(password);

            SqlParameter city = new SqlParameter("@city", SqlDbType.NVarChar, 50);
            city.Value = customer.CustomerCity;
            dbCmd.Parameters.Add(city);

            SqlParameter address = new SqlParameter("@address", SqlDbType.NVarChar, 50);
            address.Value = customer.CustomerAddress;
            dbCmd.Parameters.Add(address);

            SqlParameter email = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            email.Value = customer.CustomerEmail;
            dbCmd.Parameters.Add(email);

            SqlParameter phoneNo = new SqlParameter("@phoneNo", SqlDbType.NVarChar, 50);
            phoneNo.Value = customer.CustomerPhoneNo;
            dbCmd.Parameters.Add(phoneNo);
            
            try
            {
                result = dbCmd.ExecuteNonQuery();
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

            dbCmd = new SqlCommand();
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
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Customer WHERE " +
                "fName= @fName AND lName= @lName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramFName = new SqlParameter("@fName", SqlDbType.NVarChar, 50);
            paramFName.Value = fName;
            dbCmd.Parameters.Add(paramFName);

            SqlParameter paramLName = new SqlParameter("@lName", SqlDbType.NVarChar, 50);
            paramLName.Value = lName;
            dbCmd.Parameters.Add(paramLName);

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
        public Customer getCustomerByUsername(String userName)
        {
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Customer WHERE userName= @userName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramUserName = new SqlParameter("@userName", SqlDbType.NVarChar, 50);
            paramUserName.Value = userName;
            dbCmd.Parameters.Add(paramUserName);

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

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE Customer SET " +
                "userName= @userName, city= @city, address= @address, " +
                "email= @email, phoneNo= @phoneNo, password= @password WHERE " +
                "fName= @fName AND lName= @lName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter fName = new SqlParameter("@fName", SqlDbType.NVarChar, 50);
            fName.Value = customer.CustomerFirstName;
            dbCmd.Parameters.Add(fName);

            SqlParameter lName = new SqlParameter("@lName", SqlDbType.NVarChar, 50);
            lName.Value = customer.CustomerLastName;
            dbCmd.Parameters.Add(lName);

            SqlParameter userName = new SqlParameter("@userName", SqlDbType.NVarChar, 50);
            userName.Value = customer.CustomerUsername;
            dbCmd.Parameters.Add(userName);

            SqlParameter password = new SqlParameter("@password", SqlDbType.NVarChar, 50);
            password.Value = customer.CustomerPassword;
            dbCmd.Parameters.Add(password);

            SqlParameter city = new SqlParameter("@city", SqlDbType.NVarChar, 50);
            city.Value = customer.CustomerCity;
            dbCmd.Parameters.Add(city);

            SqlParameter address = new SqlParameter("@address", SqlDbType.NVarChar, 50);
            address.Value = customer.CustomerAddress;
            dbCmd.Parameters.Add(address);

            SqlParameter email = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            email.Value = customer.CustomerEmail;
            dbCmd.Parameters.Add(email);

            SqlParameter phoneNo = new SqlParameter("@phoneNo", SqlDbType.NVarChar, 50);
            phoneNo.Value = customer.CustomerPhoneNo;
            dbCmd.Parameters.Add(phoneNo);

            try
            {
                result = dbCmd.ExecuteNonQuery();
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

            dbCmd = new SqlCommand();
            string sqlQuery = "DELETE FROM Customer WHERE " +
                "fName= @fName AND lName= @lName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramFName = new SqlParameter("@fName", SqlDbType.NVarChar, 50);
            paramFName.Value = fName;
            dbCmd.Parameters.Add(paramFName);

            SqlParameter paramLName = new SqlParameter("@lName", SqlDbType.NVarChar, 50);
            paramLName.Value = lName;
            dbCmd.Parameters.Add(paramLName);
            
            try
            {
                result = dbCmd.ExecuteNonQuery();
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

            dbCmd = new SqlCommand();
            string sqlQuery = "DELETE FROM Customer WHERE " +
                "userName= @userName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramUserName = new SqlParameter("@userName", SqlDbType.NVarChar, 50);
            paramUserName.Value = userName;
            dbCmd.Parameters.Add(paramUserName);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }
    }
}