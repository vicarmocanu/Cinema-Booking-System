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
    class DbRoom: IRoom
    {
        private static SqlCommand dbCmd = null;

        //create a room object based on the data reader
        private static Room createRoom(IDataReader dbReader)
        {
            Room room = new Room();

            room.RoomNumber = Convert.ToInt32(dbReader["roomNumber"].ToString());
            room.NumberOfSeats = Convert.ToInt32(dbReader["numberOfSeats"].ToString());
           
            return room;
        }

        //insert a room into the table
        public int insertRoom(Room room)
        {
            int result = -1;

            string attrib = "roomNumber";
            string table = "Room";
            int max = GetMax.getMax(attrib, table);
            int id = max + 1;

            string sqlQuery = "INSERT INTO Room VALUES " +
                "('" + id + 
                "','" + room.NumberOfSeats +"')";
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

        //get all rooms
        public List<Room> getRooms()
        {
            List<Room> returnList = new List<Room>();

            string sqlQuery = "SELECT * FROM Room";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Room room = new Room();

            while (dbReader.Read())
            {
                room = createRoom(dbReader);
                returnList.Add(room);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //get a room based on its number
        public Room getRoomByNumber(int number)
        {
            string sqlQuery = "SELECT * FROM Room WHERE roomNumber= '" + number + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Room room = new Room();

            if (dbReader.Read())
            {
                room = createRoom(dbReader);
            }
            else
            {
                room = null;
            }

            AccessDbSQLClient.Close();

            return room;
        }

        //update a room based on its number
        public int updateRoom(Room room)
        {
            int result = -1;

            string sqlQuery = "UPDATE Room SET " +
                "noOfSeats='" + room.NumberOfSeats + "' " + 
                "WHERE roomNumber='" + room.RoomNumber + "'";
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