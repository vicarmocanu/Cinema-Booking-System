using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Cinema.DBLayer
{
    class GetMax
    {
        private static SqlCommand dbCmd = null; 

        public GetMax()
        { 
        
        }

        public static int getMax(String attrib, String table)
        {
            String _sqlQuery = "SELECT MAX(" + attrib + ") AS maxim FROM " + table ;
            dbCmd = AccessDbSQLClient.GetDbCommand(_sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            int maxim = 0;
            if(dbReader.Read())
            {
                maxim = Convert.ToInt32(dbReader["maxim"].ToString());
            }
            AccessDbSQLClient.Close();
            return maxim;

        }

    }

}

