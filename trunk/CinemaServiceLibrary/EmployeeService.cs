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
        private static EmployeeCtr employeeCtr = EmployeeCtr.getInstance();

        public int insertEmployee(string fName, string lName, string username, string password)
        {
            return employeeCtr.insertEmployee(fName, lName, username, password);
        }

        public int updateEmployee(String fName, String lName, String username, String password)
        {
            return employeeCtr.updateEmployee(fName, lName, username, password);
        }

        public int deleteEmployeeByUserName(String username)
        {
            return employeeCtr.deleteEmployeeByUserName(username);
        }

        public Employee getEmployeeByUserName(String username)
        {
            Employee serviceEmployee = new Employee();
            Cinema.ModelLayer.Employee hostEmployee = new Cinema.ModelLayer.Employee();
            hostEmployee = employeeCtr.getEmployeeByUserName(username);

            serviceEmployee.FName = hostEmployee.FName;
            serviceEmployee.LName = hostEmployee.LName;
            serviceEmployee.Username = hostEmployee.Username;
            serviceEmployee.Password = hostEmployee.Password;

            return serviceEmployee;
        }

        public List<Employee> getEmployees()
        {
            List<Cinema.ModelLayer.Employee> returnList = employeeCtr.getEmployees();
            List<Employee> employeeList = new List<Employee>();
            foreach (Cinema.ModelLayer.Employee hostEmployee in returnList)
            {
                Employee serviceEmployee = new Employee();

                serviceEmployee.FName = hostEmployee.FName;
                serviceEmployee.LName = hostEmployee.LName;
                serviceEmployee.Username = hostEmployee.Username;
                serviceEmployee.Password = hostEmployee.Password;

                employeeList.Add(serviceEmployee);
            }
            return employeeList;
        }
    }
}
