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
        private System.Object obj1 = new System.Object();
        private System.Object obj2 = new System.Object();
        private System.Object obj3 = new System.Object();
        private System.Object obj4 = new System.Object();
        private System.Object obj5 = new System.Object();
        private System.Object obj6 = new System.Object();
        private System.Object obj7 = new System.Object();

        private static CustomerCtr customerCtr = CustomerCtr.getInstance();

        //1
        public int insertCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password)
        {
            int result = -1;

            if(System.Threading.Monitor.TryEnter(obj1, 45000))
            {
                try
                {
                    result = customerCtr.insertCustomer(fName, lName, city, address, email, phoneNo, username, password);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj1);
                }
            }

            return result;
        }

        //2
        public int updateCustomer(string fName, string lName, string city, string address, string email, string phoneNo, string username, string password)
        {
            int result = -1;

            if(System.Threading.Monitor.TryEnter(obj2, 45000))
            {
                try
                {
                    result = customerCtr.updateCustomer(fName, lName, city, address, email, phoneNo, username, password);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj2);
                }
            }

            return result;
        }

        //3
        public int deleteCustomerByName(String fName, String lName)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj3, 45000))
            {
                try
                {
                    result = customerCtr.deleteCustomerByName(fName, lName);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj3);
                }
            }

            return result;
        }

        //4
        public int deleteCustomerByUserName(string userName)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj4, 45000))
            {
                try
                {
                    result = customerCtr.deleteCustomerByUserName(userName);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj4);
                }
            }

            return result;
        }

        //5
        public Customer getCustomerByName(String fName, String lName)
        {
            Customer serviceCustomer = new Customer();

            if (System.Threading.Monitor.TryEnter(obj5, 45000))
            {
                try
                {
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
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj5);
                }
            }

            return serviceCustomer;
        }

        //6
        public Customer getCustomerByUsername(String username)
        {
            Customer serviceCustomer = new Customer();

            if (System.Threading.Monitor.TryEnter(obj6, 45000))
            {
                try
                {
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
                    catch (NullReferenceException) { }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj6);
                }
            }

            return serviceCustomer;
        }

        //7
        public List<Customer> getCustomers()
        {
            List<Customer> customerList = new List<Customer>();

            if (System.Threading.Monitor.TryEnter(obj7, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Customer> returnList = customerCtr.getCustomers();
                    if (returnList.Count != 0)
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
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj7);
                }
            }

            return customerList;
        }
    }
}
