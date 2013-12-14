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
        private System.Object lockThis = new System.Object();
        private static EmployeeCtr employeeCtr = EmployeeCtr.getInstance();

        public int insertEmployee(string fName, string lName, string username, string password)
        {
            lock (lockThis)
            {
                return employeeCtr.insertEmployee(fName, lName, username, password);
            }
        }

        public int updateEmployee(String fName, String lName, String username, String password)
        {
            lock (lockThis)
            {
                return employeeCtr.updateEmployee(fName, lName, username, password);
            }
        }

        public int deleteEmployeeByUserName(String username)
        {
            lock (lockThis)
            {
                return employeeCtr.deleteEmployeeByUserName(username);
            }
        }

        public Employee getEmployeeByUserName(String username)
        {
            lock (lockThis)
            {
                Employee serviceEmployee = new Employee();

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

                return serviceEmployee;
            }
        }

        public List<Employee> getEmployees()
        {
            lock (lockThis)
            {
                List<Employee> employeeList = new List<Employee>();

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

                return employeeList;
            }
        }
    }
}
