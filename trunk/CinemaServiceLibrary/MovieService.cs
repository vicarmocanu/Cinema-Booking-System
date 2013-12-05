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
        private static MovieCtr movieCtr = new MovieCtr();

        public int insertMovie(string name, string genre, int ageLimit, int length)
        {
            return movieCtr.insertMovie(name, genre, ageLimit, length);
        }

        public int updateMovie(int movieId, string name, string genre, int ageLimit, int length)
        {
            return movieCtr.updateMovie(movieId, name, genre, ageLimit, length);
        }

        public Movie getMovieById(int movieId)
        {
            Movie serviceMovie = new Movie();
            serviceMovie.MovieId = movieCtr.getMovieById(movieId).MovieId;
            serviceMovie.Name = movieCtr.getMovieById(movieId).Name;
            serviceMovie.Genre = movieCtr.getMovieById(movieId).Genre;
            serviceMovie.AgeLimit = movieCtr.getMovieById(movieId).AgeLimit;
            serviceMovie.Length = movieCtr.getMovieById(movieId).Length;
            return serviceMovie;
        }

        public List<Movie> getMovies()
        {
            List<Cinema.ModelLayer.Movie> returnList = movieCtr.getMovies();
            //ListOfMovies listOfMovies = new ListOfMovies();
            List<Movie> movieList = new List<Movie>();
            foreach (Cinema.ModelLayer.Movie cinemaMovie in returnList)
            {
                Movie serviceMovie = new Movie();
                serviceMovie.MovieId = cinemaMovie.MovieId;
                serviceMovie.Name = cinemaMovie.Name;
                serviceMovie.Genre = cinemaMovie.Genre;
                serviceMovie.AgeLimit = cinemaMovie.AgeLimit;
                serviceMovie.Length = cinemaMovie.Length;
                //listOfMovies.Movies.Add(serviceMovie);
                movieList.Add(serviceMovie);
            }
            //return listOfMovies.Movies;
            return movieList;
        }
    }    
}
