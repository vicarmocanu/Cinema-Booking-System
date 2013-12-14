﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;

namespace CinemaServiceLibrary
{    
    public class SessionService : ISessionService
    {
        private System.Object lockThis = new System.Object();
        private static SessionCtr sessionCtr = SessionCtr.getInstance();

        public int insertSession(int movieId, string EnterTime, string ExitTime, string Date, double Price)
        {
            lock (lockThis)
            {
                return sessionCtr.insertSession(movieId, EnterTime, ExitTime, Date, Price);
            }
        }

        public int updateSession(int MovieId, string Date, string EnterTime, string ExitTime, double Price, int SessionId)
        {
            lock (lockThis)
            {
                return sessionCtr.updateSession(MovieId, Date, ExitTime, ExitTime, Price, SessionId);
            }
        }

        public List<int> insertSeatSchedule(int sessionId, int roomNumber)
        {
            lock (lockThis)
            {
                SeatCtr seatCtr = SeatCtr.getInstance();
                List<Cinema.ModelLayer.Seat> returnList = seatCtr.getRoomSeats(roomNumber);
                return sessionCtr.insertSeatSchedule(sessionId, returnList);
            }
        }

        public int updateSeatSchedule(int sessionId, int seatId, String status)
        {
            lock (lockThis)
            {
                return sessionCtr.updateSeatSchedule(sessionId, seatId, status);
            }
        }

        public int deleteSession(int sessionId)
        {
            lock (lockThis)
            {
                return sessionCtr.deleteSessionById(sessionId);
            }
        }

        public int deleteSeatsFromSession(int sessionId)
        {
            lock (lockThis)
            {
                return sessionCtr.deleteSeatsFromSession(sessionId);
            }
        }

        public Session getSession(int sessionId)
        {
            lock (lockThis)
            {
                Session serviceSession = new Session();
                Cinema.ModelLayer.Session hostSession = new Cinema.ModelLayer.Session();
                Room serviceRoom = new Room();
                Movie serviceMovie = new Movie();

                hostSession = sessionCtr.getSessionById(sessionId);

                serviceRoom.RoomNumber = hostSession.Room.RoomNumber;
                serviceMovie.MovieId = hostSession.Movie.MovieId;

                serviceSession.SessionId = hostSession.SessionId;
                serviceSession.Movie = serviceMovie;
                serviceSession.Room = serviceRoom;
                serviceSession.Price = hostSession.Price;
                serviceSession.Date = hostSession.Date;
                serviceSession.EnterTime = hostSession.EnterTime;
                serviceSession.ExitTime = hostSession.ExitTime;

                return serviceSession;
            }
        }

        public List<Session> getSessions()
        {
            lock (lockThis)
            {
                List<Cinema.ModelLayer.Session> returnList = sessionCtr.getSessions();
                List<Session> sessionList = new List<Session>();
                foreach (Cinema.ModelLayer.Session hostSession in returnList)
                {
                    Session serviceSession = new Session();
                    Room serviceRoom = new Room();
                    Movie serviceMovie = new Movie();

                    serviceRoom.RoomNumber = hostSession.Room.RoomNumber;
                    serviceMovie.MovieId = hostSession.Movie.MovieId;

                    serviceSession.SessionId = hostSession.SessionId;
                    serviceSession.Movie = serviceMovie;
                    serviceSession.Room = serviceRoom;
                    serviceSession.Price = hostSession.Price;
                    serviceSession.Date = hostSession.Date;
                    serviceSession.EnterTime = hostSession.EnterTime;
                    serviceSession.ExitTime = hostSession.ExitTime;

                    sessionList.Add(serviceSession);
                }
                return sessionList;
            }
        }

        public List<Session> getMovieSessions(int movieId)
        {
            lock (lockThis)
            {
                List<Cinema.ModelLayer.Session> returnList = sessionCtr.getMovieSessions(movieId);
                List<Session> sessionList = new List<Session>();
                foreach (Cinema.ModelLayer.Session hostSession in returnList)
                {
                    Session serviceSession = new Session();
                    Room serviceRoom = new Room();
                    Movie serviceMovie = new Movie();

                    serviceRoom.RoomNumber = hostSession.Room.RoomNumber;
                    serviceMovie.MovieId = hostSession.Movie.MovieId;

                    serviceSession.SessionId = hostSession.SessionId;
                    serviceSession.Movie = serviceMovie;
                    serviceSession.Room = serviceRoom;
                    serviceSession.Price = hostSession.Price;
                    serviceSession.Date = hostSession.Date;
                    serviceSession.EnterTime = hostSession.EnterTime;
                    serviceSession.ExitTime = hostSession.ExitTime;

                    sessionList.Add(serviceSession);
                }
                return sessionList;
            }
        }
    }
}