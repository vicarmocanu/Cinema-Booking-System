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
        private static SqlParameter paramFName = new SqlParameter("@fName", SqlDbType.NVarChar, 50);
        private static SqlParameter paramLName = new SqlParameter("@lName", SqlDbType.NVarChar, 50);
        private static SqlParameter paramUserName = new SqlParameter("@userName", SqlDbType.NVarChar, 50);
        private static SqlParameter paramPassword = new SqlParameter("@password", SqlDbType.NVarChar, 50);

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

            dbCmd = new SqlCommand();
            string sqlQuery = "INSERT INTO Employee(fName, lName, userName, password) VALUES " +
                "(@fName, @lName, @userName, @password)";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            
            paramFName.Value = employee.FName;
            dbCmd.Parameters.Add(paramFName);
            
            paramLName.Value = employee.LName;
            dbCmd.Parameters.Add(paramLName);

            
            paramUserName.Value = employee.Username;
            dbCmd.Parameters.Add(paramUserName);
            
            paramPassword.Value = employee.Password;
            dbCmd.Parameters.Add(paramPassword);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();
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

            dbCmd = new SqlCommand();
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

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return returnList;
        }

        //get an employee - username
        public Employee getEmployeeByUsername(String userName)
        {
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Employee WHERE userName= @userName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
            
            paramUserName.Value = userName;
            dbCmd.Parameters.Add(paramUserName);
           
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

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return employee;
        }

        //update an employee - username
        public int updateEmployee(Employee employee)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE Employee SET " +
                "fName= @fName, lName= @lName, password= @password WHERE " +
                "userName= @userName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramFName.Value = employee.FName;
            dbCmd.Parameters.Add(paramFName);

            paramLName.Value = employee.LName;
            dbCmd.Parameters.Add(paramLName);

            paramUserName.Value = employee.Username;
            dbCmd.Parameters.Add(paramUserName);

            paramPassword.Value = employee.Password;
            dbCmd.Parameters.Add(paramPassword);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }

        //delete an employee - username
        public int deleteEmployeeByUsername(String userName)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "DELETE FROM Employee WHERE userName= @userName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramUserName.Value = userName;
            dbCmd.Parameters.Add(paramUserName);

            try
            {
                result = dbCmd.ExecuteNonQuery(); 
                dbCmd.Parameters.Clear();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }
    }
}
