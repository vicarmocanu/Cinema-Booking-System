using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cinema.DBLayer
{
    class DbConnection
    {
        public static readonly string connectionString = @"Data Source=;Initial Catalog=;Trusted_Connection=True";
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
