using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;
using Cinema.ModelLayer;

namespace CinemaServiceLibrary
{
    public class CustomerService : ICustomerService
    {
        private System.Object lockThis = new System.Object();
        private static CustomerCtr customerCtr = CustomerCtr.getInstance();

        public int insertCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password)
        {
            lock (lockThis)
            {
                return customerCtr.insertCustomer(fName, lName, city, address, email, phoneNo, username, password);
            }
        }

        public int updateCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password)
        {
            lock (lockThis)
            {
                return customerCtr.updateCustomer(fName, lName, city, address, email, phoneNo, username, password);
            }
        }

        public int deleteCustomerByName(String fName, String lName)
        {
            lock (lockThis)
            {
                return customerCtr.deleteCustomerByName(fName, lName);
            }
        }

        public int deleteCustomerByUserName(string userName)
        {
            lock (lockThis)
            {
                return customerCtr.deleteCustomerByUserName(userName);
            }
        }

        public Customer getCustomerByName(String fName, String lName)
        {
            lock (lockThis)
            {
                Customer serviceCustomer = new Customer();

                Cinema.ModelLayer.Customer hostCustomer = new Cinema.ModelLayer.Customer();
                hostCustomer = customerCtr.getCustomerByName(fName, lName);

                try
                {
                    serviceCustomer.CustomerFirstName = hostCustomer.CustomerFirstName;
                    serviceCustomer.CustomerLastName = hostCustomer.CustomerLastName;
                    serviceCustomer.CustomerAddress = hostCustomer.CustomerAddress;
                    serviceCustomer.CustomerCity = hostCustomer.CustomerCity;
                    serviceCustomer.CustomerEmail = hostCustomer.CustomerEmail;
                    serviceCustomer.CustomerPassword = hostCustomer.CustomerPassword;
                    serviceCustomer.CustomerPhoneNo = hostCustomer.CustomerPhoneNo;
                    serviceCustomer.CustomerUsername = hostCustomer.CustomerUsername;
                }
                catch (NullReferenceException) { }

                return serviceCustomer;
            }
        }

        public Customer getCustomerByUsername(String username)
        {
            lock (lockThis)
            {
                Customer serviceCustomer = new Customer();

                Cinema.ModelLayer.Customer hostCustomer = new Cinema.ModelLayer.Customer();
                hostCustomer = customerCtr.getCustomerByUsername(username);
                try
                {
                    serviceCustomer.CustomerFirstName = hostCustomer.CustomerFirstName;
                    serviceCustomer.CustomerLastName = hostCustomer.CustomerLastName;
                    serviceCustomer.CustomerAddress = hostCustomer.CustomerAddress;
                    serviceCustomer.CustomerCity = hostCustomer.CustomerCity;
                    serviceCustomer.CustomerEmail = hostCustomer.CustomerEmail;
                    serviceCustomer.CustomerPassword = hostCustomer.CustomerPassword;
                    serviceCustomer.CustomerPhoneNo = hostCustomer.CustomerPhoneNo;
                    serviceCustomer.CustomerUsername = hostCustomer.CustomerUsername;
                }
                catch (NullReferenceException){}

                return serviceCustomer;
            }
        }

        public List<Customer> getCustomers()
        {
            lock (lockThis)
            {
                List<Customer> customerList = new List<Customer>();

                List<Cinema.ModelLayer.Customer> returnList = customerCtr.getCustomers();
                if(returnList.Count != 0)
                {
                    foreach (Cinema.ModelLayer.Customer hostCustomer in returnList)
                    {
                        Customer serviceCustomer = new Customer();

                        serviceCustomer.CustomerFirstName = hostCustomer.CustomerFirstName;
                        serviceCustomer.CustomerLastName = hostCustomer.CustomerLastName;
                        serviceCustomer.CustomerAddress = hostCustomer.CustomerAddress;
                        serviceCustomer.CustomerCity = hostCustomer.CustomerCity;
                        serviceCustomer.CustomerEmail = hostCustomer.CustomerEmail;
                        serviceCustomer.CustomerPassword = hostCustomer.CustomerPassword;
                        serviceCustomer.CustomerPhoneNo = hostCustomer.CustomerPhoneNo;
                        serviceCustomer.CustomerUsername = hostCustomer.CustomerUsername;

                        customerList.Add(serviceCustomer);
                    }
                }

                return customerList;
            }
        }
    }
}
