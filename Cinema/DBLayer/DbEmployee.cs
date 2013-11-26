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

        //build a customer object based on the db reader
        private static Employee createEmployee(IDataReader dbReader)
        {
            Employee employee = new Employee();

            employee.FName = dbReader["fName"].ToString();
            employee.LName = dbReader["lName"].ToString();
            employee.Username = dbReader["userName"].ToString();
            employee.Password = dbReader["password"].ToString();
            

            return employee;
        }

        public int insertEmployee(Employee employee)
        {
            int result = -1;
            string sqlQuery = "INSERT INTO Employee VALUES " +
                "('" + employee.FName +
                "','" + employee.LName +
                "','" + employee.Username +
                "','" + employee.Password + "')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException sqlEx)
            { }

            return result;
        }

        public List<Employee> getEmployees()
        {
            List<Employee> returnList = new List<Employee>();

            string sqlQuery = "SELECT * FROM Employee";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Employee employee;

            while (dbReader.Read())
            {
                employee = createEmployee(dbReader);
                returnList.Add(employee);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        public Employee getEmployeeByUsername(String username)
        {
            string sqlQuery = "SELECT * FROM Employee WHERE userName= '" + username + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Employee employee;
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
                
    }
}
