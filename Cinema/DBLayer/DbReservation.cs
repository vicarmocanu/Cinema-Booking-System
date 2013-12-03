﻿using System;
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
            customer = dbCustomer.getCustomerByName(fName, lName);
            reservation.Customer = customer;
            int sesionId = 0;
            sesionId = Convert.ToInt32(dbReader["sessionId"]);
            Session session = new Session();
            session = dbSession.getSessionById(sesionId);
            reservation.Session = session;
            reservation.NoOfSeats = Convert.ToInt32(dbReader["noOfSeats"].ToString());
            reservation.Price = Convert.ToDouble(dbReader["price"].ToString());
            reservation.Status = dbReader["status"].ToString();

            return reservation;
        }

        //inser a reservation into the Reservation table
        public int insertReservaion(Reservation reservation)
        {
            int result = -1;

            string attrib = "reservationId";
            string table = "Reservation";
            int max = GetMax.getMax(attrib, table);
            int id = max + 1;

            string sqlQuery = "INSERT INTO Reservation VALUES " +
                "('" + id +
                "','" + reservation.Customer.CustomerFirstName + 
                "','" + reservation.Customer.CustomerLastName + 
                "','" + reservation.Session.SessionId + 
                "','" + reservation.NoOfSeats + 
                "','" + reservation.Price + "')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException) { }

            return result;
        }

        //insert the reserved seats into the ReservedSeats table
        //reserved seats will be taken from a list
        public List<int> insertReservedSeats(int reservationId, List<Seat> reservedSeats)
        {
            List<int> results = new List<int>();

            foreach (Seat seat in reservedSeats)
            {
                int result = -1;
                string sqlQuery = "INSERT INTO ReservedSeats VALUES " +
                    "('" + reservationId +
                    "','" + seat.SeatId +
                    "','" + "O" + "')";
                try
                {
                    SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                    result = cmd.ExecuteNonQuery();
                    AccessDbSQLClient.Close();
                    results.Add(result);
                }
                catch (SqlException) { }
            }

            return results;
        }

        //insert a reserved seat into the ReservedSeats table
        public int insertReservedSeat(int reservationId, Seat seat)
        {
            int result = -1;

            string sqlQuery = "INSERT INTO ReservedSeats VALUES " +
                "('" + reservationId +
                "','" + seat.SeatId +
                "','" + "O" + "')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();               
            }
            catch (SqlException) { }

            return result;
        }

        //get a reservation from the Reservation table based on its id
        public Reservation getReservationById(int reservationId)
        {
            string sqlQuery = "SELECT * FROM Reservation WHERE reservationId = '" + reservationId + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

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

            string sqlQuery = "SELECT * FROM Reservation WHERE " +
                "custFName = '" + custFName + 
                "' AND custLName = '" + custLName + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Reservation reservation = new Reservation();

            while (dbReader.Read())
            {
                reservation = createReservation(dbReader);
                returnList.Add(reservation);
            }

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

            return returnList;
        }

        //get the seats from a reservation
        public List<Seat> getSeatsFromReservation(int reservationId)
        {
            List<Seat> returnList = new List<Seat>();

            string sqlQuery = "SELECT ReservedSeats.reservationId, Seat.seatId, "+
                "Seat.seatNumber, Seat.roomNumber, Seat.rowNumber, ReservedSeats.status " +
                "FROM ReservedSeats JOIN Seat ON ReservedSeats.seatId = Seat.seatId " +
                "WHERE reservationId = '" + reservationId + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Seat seat = new Seat();

            while (dbReader.Read())
            {
                seat.SeatId = Convert.ToInt32(dbReader["seatId"].ToString());
                seat.SeatNumber = Convert.ToInt32(dbReader["seatNumber"].ToString());
                seat.RowNumber = Convert.ToInt32(dbReader["rowNumber"].ToString());
                seat.Room = dbRoom.getRoomByNumber(Convert.ToInt32(dbReader["roomNumber"].ToString()));
                seat.Status = dbReader["status"].ToString();
                returnList.Add(seat);
            }

            return returnList;
        }

        //update a reservation
        public int updateReservation(Reservation reservation)
        {
            int result = -1;

            string sqlQuery = "UPDATE Reservation SET " +
                "custFName='" + reservation.Customer.CustomerFirstName + "', " +
                "custLName='" + reservation.Customer.CustomerLastName + "', " +
                "sessionId='" + reservation.Session.SessionId + "', " +
                "noOfSeats='" + reservation.NoOfSeats + "', " +
                "price='" + reservation.Price + "', " +
                "status='" + reservation.Status + "' WHERE " +
                "reservationId='" + reservation.ReservationId + "'";
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

        //update a reserved seat
        public int updateReservedSeat(int reservationId, int seatId, String status)
        {
            int result = -1;

            string sqlQuery = "UPDATE ReservedSeats SET " +
                "status = '" + status + "', " +
                "WHERE reservationId = '" + reservationId + "' AND seatId = '" + seatId + "'";
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

        //update all the seats from a reservation
        public int updateSeatsFromReservation(int reservationId, String status)
        {
            int result = -1;

            string sqlQuery = "UPDATE ReservedSeats SET " +
                "status = '" + status + "', " +
                "WHERE reservationId = '" + reservationId + "'";
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