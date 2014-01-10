using System;
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
        private static readonly System.Object obj1 = new System.Object();
        private static readonly System.Object obj2 = new System.Object();
        private static readonly System.Object obj3 = new System.Object();
        private static readonly System.Object obj4 = new System.Object();
        private static readonly System.Object obj5 = new System.Object();
        private static readonly System.Object obj6 = new System.Object();
        private static readonly System.Object obj7 = new System.Object();
        private static readonly System.Object obj8 = new System.Object();
        private static readonly System.Object obj9 = new System.Object();
        private static readonly System.Object obj10 = new System.Object();

        private static SessionCtr sessionCtr = SessionCtr.getInstance();

        //1
        public int insertSession(int movieId, string EnterTime, string ExitTime, string Date, double Price)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj1, 45000))
            {
                try
                {
                    result = sessionCtr.insertSession(movieId, EnterTime, ExitTime, Date, Price);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj1);
                }
            }

            return result;
        }

        //2
        public int updateSession(int MovieId, string Date, string EnterTime, string ExitTime, double Price, int SessionId)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj2, 45000))
            {
                try
                {
                    result = sessionCtr.updateSession(MovieId, Date, EnterTime, ExitTime, Price, SessionId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj2);
                }
            }

            return result;
        }

        //3
        public List<int> insertSeatSchedule(int sessionId, int roomNumber)
        {
            List<int> returns = new List<int>();

            if (System.Threading.Monitor.TryEnter(obj3, 45000))
            {
                try
                {
                    SeatCtr seatCtr = SeatCtr.getInstance();
                    List<Cinema.ModelLayer.Seat> returnList = seatCtr.getRoomSeats(roomNumber);
                    if (returnList.Count != 0)
                    {
                        returns = sessionCtr.insertSeatSchedule(sessionId, returnList);
                    }
                    else
                    {
                        returns.Add(-2);
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj3);
                }
            }

            return returns;
        }

        //4
        public int updateSeatSchedule(int sessionId, int seatId, String status)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj4, 45000))
            {
                try
                {
                    result = sessionCtr.updateSeatSchedule(sessionId, seatId, status);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj4);
                }
            }

            return result;
        }

        //5
        public int deleteSession(int sessionId)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj5, 45000))
            {
                try
                {
                    result = sessionCtr.deleteSessionById(sessionId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj5);
                }
            }

            return result;
        }

        //6
        public int deleteSeatsFromSession(int sessionId)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj6, 45000))
            {
                try
                {
                    result = sessionCtr.deleteSeatsFromSession(sessionId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj6);
                }
            }

            return result;
        }

        //7
        public Session getSession(int sessionId)
        {
            Session serviceSession = new Session();

            if (System.Threading.Monitor.TryEnter(obj7, 45000))
            {
                try
                {
                    Cinema.ModelLayer.Session hostSession = new Cinema.ModelLayer.Session();
                    Room serviceRoom = new Room();
                    Movie serviceMovie = new Movie();

                    hostSession = sessionCtr.getSessionById(sessionId);
                    try
                    {
                        serviceRoom.RoomNumber = hostSession.Room.RoomNumber;
                        serviceMovie.MovieId = hostSession.Movie.MovieId;

                        serviceSession.SessionId = hostSession.SessionId;
                        serviceSession.Movie = serviceMovie;
                        serviceSession.Room = serviceRoom;
                        serviceSession.Price = hostSession.Price;
                        serviceSession.Date = hostSession.Date;
                        serviceSession.EnterTime = hostSession.EnterTime;
                        serviceSession.ExitTime = hostSession.ExitTime;
                    }
                    catch (NullReferenceException) { }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj7);
                }
            }

            return serviceSession;
        }

        //8
        public List<Session> getSessions()
        {
            List<Session> sessionList = new List<Session>();

            if (System.Threading.Monitor.TryEnter(obj8, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Session> returnList = sessionCtr.getSessions();

                    if (returnList.Count != 0)
                    {
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
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj8);
                }
            }

            return sessionList;
        }

        //9
        public List<Session> getMovieSessions(int movieId)
        {
            List<Session> sessionList = new List<Session>();

            if (System.Threading.Monitor.TryEnter(obj9, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Session> returnList = sessionCtr.getMovieSessions(movieId);
                    if (returnList.Count != 0)
                    {
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
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj9);
                }
            }

            return sessionList;
        }

        //10
        public List<Seat> getSessionSeats(int sessionId)
        {
            List<Seat> seatList = new List<Seat>();

            if (System.Threading.Monitor.TryEnter(obj10, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Seat> returnList = new List<Cinema.ModelLayer.Seat>();
                    returnList = sessionCtr.getSeatsForJaggedArray(sessionId).SelectMany(x => x).ToList();
                    if (returnList.Count != 0)
                    {
                        foreach (Cinema.ModelLayer.Seat hostSeat in returnList)
                        {
                            Seat serviceSeat = new Seat();
                            Room serviceRoom = new Room();

                            serviceSeat.SeatId = hostSeat.SeatId;
                            serviceSeat.SeatNumber = hostSeat.SeatNumber;
                            serviceSeat.RowNumber = hostSeat.RowNumber;
                            serviceRoom.RoomNumber = hostSeat.Room.RoomNumber;
                            serviceSeat.Room = serviceRoom;
                            serviceSeat.Status = hostSeat.Status;

                            seatList.Add(serviceSeat);
                        }
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj10);
                }
            }

            return seatList;
        }
    }
}
