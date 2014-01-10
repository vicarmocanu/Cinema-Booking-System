using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;

namespace CinemaServiceLibrary
{
    public class EmployeeService : IEmployeeService
    {
        private static readonly System.Object obj1 = new System.Object();
        private static readonly System.Object obj2 = new System.Object();
        private static readonly System.Object obj3 = new System.Object();
        private static readonly System.Object obj4 = new System.Object();
        private static readonly System.Object obj5 = new System.Object();

        private static EmployeeCtr employeeCtr = EmployeeCtr.getInstance();

        //1
        public int insertEmployee(string fName, string lName, string username, string password)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj1, 45000))
            {
                try
                {
                    result = employeeCtr.insertEmployee(fName, lName, username, password);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj1);
                }
            }

            return result;
        }

        //2
        public int updateEmployee(String fName, String lName, String username, String password)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj2, 45000))
            {
                try
                {
                    result = employeeCtr.updateEmployee(fName, lName, username, password);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj2);
                }
            }

            return result;
        }

        //3
        public int deleteEmployeeByUserName(String username)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj3, 45000))
            {
                try
                {
                    result = employeeCtr.deleteEmployeeByUserName(username);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj3);
                }
            }

            return result;
        }

        //4
        public Employee getEmployeeByUserName(String username)
        {
            Employee serviceEmployee = new Employee();

            if (System.Threading.Monitor.TryEnter(obj4, 45000))
            {
                try
                {
                    Cinema.ModelLayer.Employee hostEmployee = new Cinema.ModelLayer.Employee();
                    hostEmployee = employeeCtr.getEmployeeByUserName(username);
                    try
                    {
                        serviceEmployee.FName = hostEmployee.FName;
                        serviceEmployee.LName = hostEmployee.LName;
                        serviceEmployee.Username = hostEmployee.Username;
                        serviceEmployee.Password = hostEmployee.Password;
                    }
                    catch (NullReferenceException) { }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj4);
                }
            }

            return serviceEmployee;
        }

        //5
        public List<Employee> getEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            if (System.Threading.Monitor.TryEnter(obj5, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Employee> returnList = employeeCtr.getEmployees();
                    if (returnList.Count != 0)
                    {
                        foreach (Cinema.ModelLayer.Employee hostEmployee in returnList)
                        {
                            Employee serviceEmployee = new Employee();

                            serviceEmployee.FName = hostEmployee.FName;
                            serviceEmployee.LName = hostEmployee.LName;
                            serviceEmployee.Username = hostEmployee.Username;
                            serviceEmployee.Password = hostEmployee.Password;

                            employeeList.Add(serviceEmployee);
                        }
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj5);
                }
            }

            return employeeList;
        }
    }
}
