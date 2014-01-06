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
        private static DbRoom dbRoom = new DbRoom();
        private static SqlCommand dbCmd = null;
        
        //create a reservation object based on the data reader
        private static Reservation createReservation(IDataReader dbReader)
        {
            Reservation reservation = new Reservation();

            reservation.ReservationId = Convert.ToInt32(dbReader["reservationId"].ToString());
            string fName = dbReader["custFName"].ToString();
            string lName = dbReader["custLName"].ToString();
            Customer customer = new Customer();
            customer.CustomerFirstName = fName;
            customer.CustomerLastName = lName;
            reservation.Customer = customer;
            int sessionId = 0;
            sessionId = Convert.ToInt32(dbReader["sessionId"]);
            Session session = new Session();
            session.SessionId = sessionId;
            reservation.Session = session;
            reservation.NoOfSeats = Convert.ToInt32(dbReader["noOfSeats"].ToString());
            reservation.Price = Convert.ToDouble(dbReader["price"].ToString());
            reservation.Status = dbReader["status"].ToString();
            reservation.Date = dbReader["date"].ToString();

            return reservation;
        }

        //insert a reservation
        public int insertReservaion(Reservation reservation)
        {
            int result = -1;

            string attrib = "reservationId";
            string table = "Reservation";
            int max = GetMax.getMax(attrib, table);
            int id = max + 1;
            String currentDate = reservation.getCurrentDate();

            dbCmd = new SqlCommand();
            string sqlQuery = "INSERT INTO Reservation VALUES " +
                "(@reservationId, @custFName, @custLName, @sessionId, @noOfSeats, @price, @status, @date)";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = id;
            dbCmd.Parameters.Add(paramReservationId);

            SqlParameter paramCustFName = new SqlParameter("@custFName", SqlDbType.NVarChar, 50);
            paramCustFName.Value = reservation.Customer.CustomerFirstName;
            dbCmd.Parameters.Add(paramCustFName);

            SqlParameter paramCustLName = new SqlParameter("@custLName", SqlDbType.NVarChar, 50);
            paramCustLName.Value = reservation.Customer.CustomerLastName;
            dbCmd.Parameters.Add(paramCustLName);

            SqlParameter paramSessionId = new SqlParameter("@sessionId", SqlDbType.Int);
            paramSessionId.Value = reservation.Session.SessionId;
            dbCmd.Parameters.Add(paramSessionId);

            SqlParameter paramNoOfSeats = new SqlParameter("@noOfSeats", SqlDbType.Int);
            paramNoOfSeats.Value = reservation.NoOfSeats;
            dbCmd.Parameters.Add(paramNoOfSeats);

            SqlParameter paramPrice = new SqlParameter("@price", SqlDbType.Float);
            paramPrice.Value = reservation.Price;
            dbCmd.Parameters.Add(paramPrice);

            SqlParameter paramStatus = new SqlParameter("@status", SqlDbType.NVarChar, 50);
            paramStatus.Value = reservation.Status;
            dbCmd.Parameters.Add(paramStatus);

            SqlParameter paramDate = new SqlParameter("@date", SqlDbType.Date);
            paramDate.Value = currentDate;
            dbCmd.Parameters.Add(paramDate);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException) { }

            return result;
        }

        //insert the reserved seats
        //reserved seats will be taken from a list
        public List<int> insertReservedSeats(int reservationId, List<Seat> reservedSeats)
        {
            List<int> results = new List<int>();

            foreach (Seat seat in reservedSeats)
            {
                int result = -1;

                dbCmd = new SqlCommand();
                string sqlQuery = "INSERT INTO ReservedSeats VALUES " +
                    "(@reservationId, @seatId, @status) ";
                dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

                SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
                paramReservationId.Value = reservationId;
                dbCmd.Parameters.Add(paramReservationId);

                SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
                paramSeatId.Value = seat.SeatId;
                dbCmd.Parameters.Add(paramSeatId);

                SqlParameter paramStatus = new SqlParameter("@status", SqlDbType.NVarChar, 50);
                paramStatus.Value = "O";
                dbCmd.Parameters.Add(paramStatus);

                try
                {
                    result = dbCmd.ExecuteNonQuery();
                    AccessDbSQLClient.Close();
                    results.Add(result);
                }
                catch (SqlException) { }
            }

            return results;
        }

        //insert a reserved seat
        public int insertReservedSeat(int reservationId, Seat seat)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "INSERT INTO ReservedSeats VALUES " +
                "(@reservationId, @seatId, @status) ";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = reservationId;
            dbCmd.Parameters.Add(paramReservationId);

            SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
            paramSeatId.Value = seat.SeatId;
            dbCmd.Parameters.Add(paramSeatId);

            SqlParameter paramStatus = new SqlParameter("@status", SqlDbType.NVarChar, 50);
            paramStatus.Value = "O";
            dbCmd.Parameters.Add(paramStatus);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException) { }

            return result;
        }

        //get a reservation - id
        public Reservation getReservationById(int reservationId)
        {
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Reservation WHERE reservationId = @reservationId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = reservationId;
            dbCmd.Parameters.Add(paramReservationId);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Reservation reservation = new Reservation();

            if (dbReader.Read())
            {
                reservation = createReservation(dbReader);
            }
            else
            {
                reservation = null;
            }

            return reservation;
        }

        //get the reservations for a customer
        public List<Reservation> getCustomerReservations(String custFName, String custLName)
        {
            List<Reservation> returnList = new List<Reservation>();

            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Reservation WHERE " +
                "custFName= @custFName AND custLName= @custLName";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramCustFName = new SqlParameter("@custFName", SqlDbType.NVarChar, 50);
            paramCustFName.Value = custFName;
            dbCmd.Parameters.Add(paramCustFName);

            SqlParameter paramCustLName = new SqlParameter("@custLName", SqlDbType.NVarChar, 50);
            paramCustLName.Value = custLName;
            dbCmd.Parameters.Add(paramCustLName);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();
            
            while (dbReader.Read())
            {
                Reservation reservation = new Reservation();
                reservation = createReservation(dbReader);
                returnList.Add(reservation);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }
        
        //get all reservations
        public List<Reservation> getAllReservations()
        {
            List<Reservation> returnList = new List<Reservation>();

            string sqlQuery = "SELECT * FROM Reservation";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Reservation reservation = new Reservation();
            while (dbReader.Read())
            {
                reservation = createReservation(dbReader);
                returnList.Add(reservation);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //get the seats from a reservation
        public List<Seat> getSeatsFromReservation(int reservationId)
        {
            List<Seat> returnList = new List<Seat>();

            string sqlQuery = "SELECT ReservedSeats.reservationId, Seat.seatId, " +
                "Seat.seatNumber, Seat.roomNumber, Seat.rowNumber, ReservedSeats.status " +
                "FROM ReservedSeats JOIN Seat ON ReservedSeats.seatId = Seat.seatId " +
                "WHERE reservationId = @reservationId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = reservationId;
            dbCmd.Parameters.Add(paramReservationId);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            while (dbReader.Read())
            {
                Seat seat = new Seat();
                Room room = new Room();

                seat.SeatId = Convert.ToInt32(dbReader["seatId"].ToString());
                seat.SeatNumber = Convert.ToInt32(dbReader["seatNumber"].ToString());
                seat.RowNumber = Convert.ToInt32(dbReader["rowNumber"].ToString());
                room.RoomNumber = Convert.ToInt32(dbReader["roomNumber"].ToString());
                seat.Room = room;
                seat.Status = dbReader["status"].ToString();

                returnList.Add(seat);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //update a reservation - id
        public int updateReservation(Reservation reservation)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE Reservation SET " +
                "custFName= @custFName, custLName= @custLName, sessionId= @sessionId, " +
                "noOfSeats= @noOfSeats, price= @price, status= @status WHERE " +
                "reservationId= @reservationId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = reservation.ReservationId;
            dbCmd.Parameters.Add(paramReservationId);

            SqlParameter paramCustFName = new SqlParameter("@custFName", SqlDbType.NVarChar, 50);
            paramCustFName.Value = reservation.Customer.CustomerFirstName;
            dbCmd.Parameters.Add(paramCustFName);

            SqlParameter paramCustLName = new SqlParameter("@custLName", SqlDbType.NVarChar, 50);
            paramCustLName.Value = reservation.Customer.CustomerLastName;
            dbCmd.Parameters.Add(paramCustLName);

            SqlParameter paramSessionId = new SqlParameter("@sessionId", SqlDbType.Int);
            paramSessionId.Value = reservation.Session.SessionId;
            dbCmd.Parameters.Add(paramSessionId);

            SqlParameter paramNoOfSeats = new SqlParameter("@noOfSeats", SqlDbType.Int);
            paramNoOfSeats.Value = reservation.NoOfSeats;
            dbCmd.Parameters.Add(paramNoOfSeats);

            SqlParameter paramPrice = new SqlParameter("@price", SqlDbType.Float);
            paramPrice.Value = reservation.Price;
            dbCmd.Parameters.Add(paramPrice);

            SqlParameter paramStatus = new SqlParameter("@status", SqlDbType.NVarChar, 50);
            paramStatus.Value = reservation.Status;
            dbCmd.Parameters.Add(paramStatus);

            SqlParameter paramDate = new SqlParameter("@date", SqlDbType.Date);
            paramDate.Value = reservation.Date;
            dbCmd.Parameters.Add(paramDate);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }

        //delete reservation - id
        public int deleteReservation(int reservationId)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "DELETE FROM Reservation WHERE reservationId= @reservationId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = reservationId;
            dbCmd.Parameters.Add(paramReservationId);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }
            return result;
        }

        //update a reserved seat
        public int updateReservedSeat(int reservationId, int seatId, String status)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE ReservedSeats SET " +
                "status= @status WHERE reservationId= @reservationId AND seatId= @seatId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = reservationId;
            dbCmd.Parameters.Add(paramReservationId);

            SqlParameter paramStatus = new SqlParameter("@status", SqlDbType.NVarChar, 50);
            paramStatus.Value = status;
            dbCmd.Parameters.Add(paramStatus);

            SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
            paramSeatId.Value = seatId;
            dbCmd.Parameters.Add(paramSeatId);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }

        //delete a reserved seat from a reservation
        public int deleteReservedSeat(int reservationId, int seatId)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "DELETE FROM ReservedSeats WHERE " +
            "reservationId= @reservationId AND seatId= @seatId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = reservationId;
            dbCmd.Parameters.Add(paramReservationId);

            SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
            paramSeatId.Value = seatId;
            dbCmd.Parameters.Add(paramSeatId);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }
            return result;
        }

        //update all the seats from a reservation
        public int updateSeatsFromReservation(int reservationId, String status)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE ReservedSeats SET status= @status WHERE " +
                "reservationId= @reservationId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramStatus = new SqlParameter("@status", SqlDbType.NVarChar, 50);
            paramStatus.Value = status;
            dbCmd.Parameters.Add(paramStatus);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = reservationId;
            dbCmd.Parameters.Add(paramReservationId);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }        
    
        //delete all seats from reservation
        public int deleteSeatsFromReservation(int reservationId)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "DELETE FROM ReservedSeats "+
            "WHERE reservationId= @reservationId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
            paramReservationId.Value = reservationId;
            dbCmd.Parameters.Add(paramReservationId);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }
            return result;
        }

        public List<int> trustedInsertReservedSeats( List<Seat> reservedSeats)
        {
            List<int> results = new List<int>();

            int wantedId = GetMax.getMax("reservationId", "Reservation");

            foreach (Seat seat in reservedSeats)
            {
                int result = -1;

                dbCmd = new SqlCommand();
                string sqlQuery = "INSERT INTO ReservedSeats VALUES " +
                    "(@reservationId, @seatId, @status)";
                dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

                SqlParameter paramReservationId = new SqlParameter("@reservationId", SqlDbType.Int);
                paramReservationId.Value = wantedId;
                dbCmd.Parameters.Add(paramReservationId);

                SqlParameter paramSeatId = new SqlParameter("@seatId", SqlDbType.Int);
                paramSeatId.Value = seat.SeatId;
                dbCmd.Parameters.Add(paramSeatId);

                SqlParameter paramStatus = new SqlParameter("@status", SqlDbType.NVarChar, 50);
                paramStatus.Value = "O";
                dbCmd.Parameters.Add(paramStatus);

                try
                {
                    result = dbCmd.ExecuteNonQuery();
                    AccessDbSQLClient.Close();
                    results.Add(result);
                }
                catch (SqlException) { }
            }

            return results;
        }
    }
}