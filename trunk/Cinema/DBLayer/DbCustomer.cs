using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Cinema.ModelLayer;
using Cinema.DBLayer;
using System.Security.Cryptography;

namespace Cinema.DBLayer
{
    class DbCustomer : ICustomer
    {

        private static SqlCommand dbCmd = null;
        private String cleanString(String str)
        {
            String newString = str.Replace("'", "¶");
            return newString;
        }
        private String undoCleanString(String str)
        { 
            String newString = str.Replace("¶","'");
            return newString;
        }

        public List<Customer> GetCustomer()
        {
            List<Customer> returnList = new List<Customer>();
            string sql = "SELECT * FROM Customer";
            dbCmd = AccessDbSQLClient.GetDbCommand(sql);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Customer cu;

            while (dbReader.Read())
            {
                cu = BuildCustomer(dbReader);

                returnList.Add(cu);
            }

            DBConnection.Close();
            return returnList;
        }

     


    }
}
