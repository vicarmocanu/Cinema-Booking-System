using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;
using Cinema.DBLayer;

namespace Cinema.ControlLayer
{
   public class MovieCtr
    {
        private static MovieCtr instance = null;

        public static MovieCtr getInstance()
        {
            if (instance == null)
            {
                instance = new MovieCtr();
            }
            return instance;
        }

        public MovieCtr(){}

        public int insertMovie(String name, String genre, int ageLimit, int length)
        {
            IMovie _dbMovie = new DbMovie();
            Movie movie = new Movie();

            movie.AgeLimit = ageLimit;
            movie.Genre = genre;
            movie.Length = length;
            movie.Name = name;

            return _dbMovie.insertMovie(movie);
        }

        public List<Movie> getMovies()
        {
            IMovie _dbMovie = new DbMovie();

            List<Movie> returnList = new List<Movie>();
            returnList = _dbMovie.getMovies();

            return returnList;
        }

        public Movie getMovieById(int id)
        {
            IMovie _dbMovie = new DbMovie();
            return _dbMovie.getMovieByID(id);
        }

        public Movie getMovieByName(String name)
        {
            IMovie _dbMovie = new DbMovie();
            return _dbMovie.getMovieByName(name);
        }

        public int updateMovie(int movieId, String name, String genre, int ageLimit, int length)
        {
            IMovie _dbMovie = new DbMovie();
            Movie movie = new Movie();

            movie.AgeLimit = ageLimit;
            movie.Genre = genre;
            movie.Length = length;
            movie.MovieId = movieId;
            movie.Name = name;

            return _dbMovie.updateMovie(movie);
        }

        public int deleteMovie(int movieId)
        {
            IMovie _dbMovie = new DbMovie();
            return _dbMovie.deleteMovie(movieId);
        }
    }
}
