using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;
using Cinema.ModelLayer;

namespace CinemaServiceLibrary
{    
    public class MovieService : IMovieService
    {
        private static readonly System.Object obj1 = new System.Object();
        private static readonly System.Object obj2 = new System.Object();
        private static readonly System.Object obj3 = new System.Object();
        private static readonly System.Object obj4 = new System.Object();
        private static readonly System.Object obj5 = new System.Object();
        private static readonly System.Object obj6 = new System.Object();

        private static MovieCtr movieCtr = MovieCtr.getInstance();

        //1
        public int insertMovie(string name, string genre, int ageLimit, int length)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj1, 45000))
            {
                try
                {
                    result = movieCtr.insertMovie(name, genre, ageLimit, length);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj1);
                }
            }

            return result;
        }

        //2
        public int updateMovie(int movieId, string name, string genre, int ageLimit, int length)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj2, 45000))
            {
                try
                {
                    result = movieCtr.updateMovie(movieId, name, genre, ageLimit, length);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj2);
                }
            }

            return result;
        }

        //3
        public int deleteMovie(int movieId)
        {
            int result = -1;

            if (System.Threading.Monitor.TryEnter(obj3, 45000))
            {
                try
                {
                    result = movieCtr.deleteMovie(movieId);
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj3);
                }
            }

            return result;
        }

        //4
        public Movie getMovieById(int movieId)
        {
            Movie serviceMovie = new Movie();

            if (System.Threading.Monitor.TryEnter(obj4, 45000))
            {
                try
                {
                    Cinema.ModelLayer.Movie hostMovie = new Cinema.ModelLayer.Movie();
                    hostMovie = movieCtr.getMovieById(movieId);
                    try
                    {
                        serviceMovie.MovieId = hostMovie.MovieId;
                        serviceMovie.Name = hostMovie.Name;
                        serviceMovie.Genre = hostMovie.Genre;
                        serviceMovie.AgeLimit = hostMovie.AgeLimit;
                        serviceMovie.Length = hostMovie.Length;
                    }
                    catch (NullReferenceException) { }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj4);
                }
            }

            return serviceMovie;
        }

        //5
        public Movie getMovieByName(String name)
        {
            Movie serviceMovie = new Movie();

            if (System.Threading.Monitor.TryEnter(obj5, 45000))
            {
                try
                {
                    Cinema.ModelLayer.Movie hostMovie = new Cinema.ModelLayer.Movie();
                    hostMovie = movieCtr.getMovieByName(name);
                    try
                    {
                        serviceMovie.MovieId = hostMovie.MovieId;
                        serviceMovie.Name = hostMovie.Name;
                        serviceMovie.Genre = hostMovie.Genre;
                        serviceMovie.AgeLimit = hostMovie.AgeLimit;
                        serviceMovie.Length = hostMovie.Length;
                    }
                    catch (NullReferenceException) { }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj5);
                }
            }

            return serviceMovie;
        }

        //6
        public List<Movie> getMovies()
        {
            List<Movie> movieList = new List<Movie>();

            if (System.Threading.Monitor.TryEnter(obj6, 45000))
            {
                try
                {
                    List<Cinema.ModelLayer.Movie> returnList = movieCtr.getMovies();
                    if (returnList.Count != 0)
                    {
                        foreach (Cinema.ModelLayer.Movie cinemaMovie in returnList)
                        {
                            Movie serviceMovie = new Movie();

                            serviceMovie.MovieId = cinemaMovie.MovieId;
                            serviceMovie.Name = cinemaMovie.Name;
                            serviceMovie.Genre = cinemaMovie.Genre;
                            serviceMovie.AgeLimit = cinemaMovie.AgeLimit;
                            serviceMovie.Length = cinemaMovie.Length;

                            movieList.Add(serviceMovie);
                        }
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(obj6);
                }
            }

            return movieList;
        }
    }    
}
