using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;
using System.Data;
using System.Data.SqlClient;
using Cinema.DBLayer;


namespace Cinema.ControlLayer
{
    class EmployeeCtr
    {
        private static EmployeeCtr instance = null;

        public static EmployeeCtr getInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeCtr();
            }
            return instance;
        }

        public EmployeeCtr(){}

        public int insertEmployee(String fName, String lName, String username, String password)
        {
            IEmployee DbEmployee = new DbEmployee();
            Employee emp = new Employee();
            emp.FName = fName;
            emp.LName = lName;
            emp.Username = username;
            emp.Password = password;
            return DbEmployee.insertEmployee(emp);     
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> returnList = new List<Employee>();
            DbEmployee dbEmployee = new DbEmployee();
            returnList = dbEmployee.getEmployees();
            return returnList;
        }

        public Employee getEmployeeByUserName(String username)
        {
            IEmployee _dbEmployee = new DbEmployee();
            return _dbEmployee.getEmployeeByUsername(username);
        }

        public int updateEmployee(String fName, String lName, String username, String password)
        {
            IEmployee _dbEmployee = new DbEmployee();
            Employee emp = new Employee();
            emp.FName = fName;
            emp.LName = lName;
            emp.Username = username;
            emp.Password = password;
            return _dbEmployee.updateEmployee(emp);
        }   
    }
}
