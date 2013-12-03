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
        private static EmployeeCtr employeeCtr = new EmployeeCtr();

        public int insertEmployee(string fName, string lName, string username, string password)
        {
            return employeeCtr.insertEmployee(fName, lName, username, password);
        }
    }
}
