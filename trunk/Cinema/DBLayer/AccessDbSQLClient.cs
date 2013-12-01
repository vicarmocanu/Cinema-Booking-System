using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Cinema.DBLayer
{
    public class AccessDbSQLClient
    {
        private static String connectionString = @"Data Source=balder.ucn.dk; Initial Catalog=dmae0912_7; User id=dmae0912_7; Password=IsAllowed; Integrated Security=False";
        private static SqlConnection dbConnection = new SqlConnection(connectionString);
        private static SqlCommand dbCommand = new SqlCommand(null, dbConnection);

        public static void Open()
        {
            if (dbConnection.State.ToString().CompareTo("Open") != 0)
            {
                dbConnection.Open();
            }
        }

        public static void Close()
        {
            dbConnection.Close();
        }

        public static SqlCommand GetDbCommand(String sqlQuery)
        {
            Open();
            if (dbCommand == null)
            {
                dbCommand = new SqlCommand(sqlQuery, dbConnection);
            }
            dbCommand.CommandText = sqlQuery;
            dbCommand.Prepare();
            return dbCommand;
        }
    }
}
