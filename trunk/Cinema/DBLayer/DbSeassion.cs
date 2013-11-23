using Cinema.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DBLayer
{
    class DbSeassion :ISession
    {
        private static SqlCommand dbCmd = null;

        public int insertSessionInformation(Session session)
        {
            int result = -1;
            string sqlQuery = "INSERT INTO Session VALUES " +
                "('" + session.SessionId +
                "','" + session.Movie.MovieId +
                "','" + session.Date +
                "','" + session.EnterTime +
                "','" + session.ExitTime + "')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException) { }

            return result;
        }

        //get all sessions
        public List<Session> getSessions()
        {
            List<Session> returnList = new List<Session>();

            string sqlQuery = "SELECT * FROM Session";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Customer customer;

            while (dbReader.Read())
            {
                customer = createCustomer(dbReader);
                returnList.Add(customer);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }


       
    }
}
