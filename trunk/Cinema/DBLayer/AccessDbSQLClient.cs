using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Cinema.DBLayer
{
    public class AccessDbSQLClient
    {
        public static readonly string connectionString = @"Data Server=balder.ucn.dk;Initial Catalog=dmae0912_7;User id=dmae0912_7;Password=IsAllowed;Integrated Security=True";
        public static readonly SqlConnection dbconn = new SqlConnection(connectionString);

        private static SqlCommand dbCmd;

        private static void Open()
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                dbconn.Open();
        }

        public static void Close()
        {
            dbconn.Close();
        }

        public static SqlCommand GetDbCommand(string sql)
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                Open();
            if (dbCmd == null)
            {
                dbCmd = new SqlCommand(sql, dbconn);
            }
            dbCmd.CommandText = sql;
            return dbCmd;
        }


    }
}
