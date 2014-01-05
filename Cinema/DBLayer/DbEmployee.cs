using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.DBLayer
{
    class DbEmployee: IEmployee
    {
        private static SqlCommand dbCmd = null;

        //build an employee object based on the db reader
        private static Employee createEmployee(IDataReader dbReader)
        {
            Employee employee = new Employee();

            employee.FName = dbReader["fName"].ToString();
            employee.LName = dbReader["lName"].ToString();
            employee.Username = dbReader["userName"].ToString();
            employee.Password = dbReader["password"].ToString();

            return employee;
        }

        //insert an employee
        public int insertEmployee(Employee employee)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO Employee(fName, lName, userName, password) VALUES('" +
                employee.FName + "','" + 
                employee.LName + "','" + 
                employee.Username + "','" + 
                employee.Password + "');";
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

        //get all employees
        public List<Employee> getEmployees()
        {
            List<Employee> returnList = new List<Employee>();

            string sqlQuery = "SELECT * FROM Employee";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            while (dbReader.Read())
            {
                Employee employee = new Employee();
                employee = createEmployee(dbReader);
                returnList.Add(employee);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //get an employee - username
        public Employee getEmployeeByUsername(String username)
        {
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Employee WHERE userName= @userName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@userName";
            param.Value = username;
            dbCmd.Parameters.Add(param);
                      
            
            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Employee employee = new Employee();

            if (dbReader.Read())
            {
                employee = createEmployee(dbReader);
            }
            else
            {
                employee = null;
            }

            AccessDbSQLClient.Close();

            return employee;
        }

        //update an employee - username
        public int updateEmployee(Employee employee)
        {
            int result = -1;

            string sqlQuery = "UPDATE Employee SET " +
                "fName='" + employee.FName + "', " +
                "lName='" + employee.LName + "', " +
                "password='" + employee.Password + "' " +
                "WHERE userName='" + employee.Username + "'";
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

        //delete an employee - username
        public int deleteEmployeeByUsername(String username)
        {
            int result = -1;
            string sqlQuery = "DELETE FROM Employee WHERE userName= '" + username + "'";
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
