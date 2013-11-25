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
        private static SqlCommand dbCmd = null;
        private static DbCustomer dbCustomer = new DbCustomer();
        private static DbSession dbSession = new DbSession();

       
        

        private static Reservation createReservation(IDataReader dbReader)
        {
            Reservation res  = new Reservation();

            res.ReservationId = Convert.ToInt32(dbReader["reservationId"].ToString());
            res.Customer = dbCustomer.getCustomerByName(Convert.ToInt32(dbReader["customer"].ToString()));
            res.Session = dbSession.getSession(Convert.ToInt32(dbReader["session"].ToString()));
            res.NoOfSeats = Convert.ToInt32(dbReader["noOfSeats"].ToString());
            res.ReservedSeats = dbReader["reservedSeats"].ToString();
            res.Price = Convert.ToInt32(dbReader["price"].ToString());
            res.Date = dbReader["date"].ToString();
            res.Status = dbReader["status"].ToString();

            return res;
        }

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
            catch (SqlException sqlEx)
            { }

            return result;
        }

        public LinkedList<Seat> getSeats()
        {
            LinkedList<Seat> returnList = new LinkedList<Seat>();

            string sqlQuery = "SELECT * FROM Seat";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Reservation res;

            while (dbReader.Read())
            {
                res = createReservation(dbReader);
                returnList.Add(res);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        public Movie getReservationByID(int id)
        {
            string sqlQuery = "SELECT * FROM Reservation WHERE reservationId= '" + id + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Reservation res;
            if (dbReader.Read())
            {
                res = createReservation(dbReader);
            }
            else
            {
                res = null;                
            }

            AccessDbSQLClient.Close();

            return res;
        }

        //public Reservation(int reservationId, 
        //    Customer customer, 
        //    Session session, 
        //    int noOfSeats, 
        //    LinkedList<Seat> reservedSeats, 
        //    int price, String date, 
        //    String status)

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
            catch (SqlException sqlEx)
            { }

            return result;
        }

        private static SqlCommand dbCmd = null;
    }
}
