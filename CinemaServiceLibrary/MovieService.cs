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
            Movie movie = new Movie();
            movie.MovieId = movieCtr.getMovieById(movieId).MovieId;
            movie.Name = movieCtr.getMovieById(movieId).Name;
            movie.Genre = movieCtr.getMovieById(movieId).Genre;
            movie.AgeLimit = movieCtr.getMovieById(movieId).AgeLimit;
            movie.Length = movieCtr.getMovieById(movieId).Length;
            return movie;
        }
    }

    
}
