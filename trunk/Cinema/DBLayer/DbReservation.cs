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
    class DbReservation: IReservation
    {
        private static DbCustomer dbCustomer = new DbCustomer();
        private static DbSession dbSession = new DbSession();
        private static SqlCommand dbCmd = null;


        public int insertReservaion(Reservation res)
        {
            int result = -1;
            string sqlQuery = "INSERT INTO Reservation VALUES " +
                "('" + res.ReservationId +
                "','" + res.Customer +
                "','" + res.Session +
                "','" + res.NoOfSeats +
                "','" + res.ReservedSeats +
                "','" + res.Price +
                "','" + res.Date +
                "','" + res.Status + "')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException) { }

            return result;
        }

        public int updateReservation(Reservation res)
        {
            int result = -1;

            string sqlQuery = "UPDATE Reservation SET " +
                "customer='" + res.Customer + "', " +
                "session='" + res.Session + "', " +
                "noOfSeats='" + res.NoOfSeats + "', " +
                "reservedSeats='" + res.ReservedSeats + "', " +
                "price='" + res.Price + "', " +
                "date='" + res.Date + "', " +
                "status='" + res.Status + "' WHERE " +
                "reservationId='" + res.ReservationId + "'";

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
