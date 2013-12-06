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
        private static MovieCtr movieCtr = MovieCtr.getInstance();

        public int insertMovie(string name, string genre, int ageLimit, int length)
        {
            return movieCtr.insertMovie(name, genre, ageLimit, length);
        }

        public int updateMovie(int movieId, string name, string genre, int ageLimit, int length)
        {
            return movieCtr.updateMovie(movieId, name, genre, ageLimit, length);
        }

        public int deleteMovie(int movieId)
        {
            return movieCtr.deleteMovie(movieId);
        }

        public Movie getMovieById(int movieId)
        {
            Movie serviceMovie = new Movie();
            Cinema.ModelLayer.Movie hostMovie = new Cinema.ModelLayer.Movie();

            hostMovie = movieCtr.getMovieById(movieId);
            serviceMovie.MovieId = hostMovie.MovieId;
            serviceMovie.Name = hostMovie.Name;
            serviceMovie.Genre = hostMovie.Genre;
            serviceMovie.AgeLimit = hostMovie.AgeLimit;
            serviceMovie.Length = hostMovie.Length;

            return serviceMovie;
        }

        public List<Movie> getMovies()
        {
            List<Cinema.ModelLayer.Movie> returnList = movieCtr.getMovies();
            List<Movie> movieList = new List<Movie>();

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

            return movieList;
        }
    }    
}
