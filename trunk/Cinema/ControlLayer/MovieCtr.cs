using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;
using Cinema.DBLayer;

namespace Cinema.ControlLayer
{
    class MovieCtr
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

        public MovieCtr()
        { 
        
        }

        public int insertMovie(int movieId, String name, String genre, int ageLimit, String lenght)
        {
            IMovie _dbMovie = new DbMovie();
            Movie movie = new Movie();

            movie.AgeLimit = ageLimit;
            movie.Genre = genre;
            movie.Lenght = lenght;
            movie.MovieId = movieId;
            movie.Name = name;

            return _dbMovie.insertMovie(movie);
        }

        public List<Movie> getMovies()
        { 
            List<Movie> returnList = new List<Movie>();
            DbMovie _dbMovie = new DbMovie();
            returnList = _dbMovie.getMovies();
            return returnList;
        }

        public Movie getMovieById(int id)
        {
            IMovie _dbMovie = new DbMovie();
            return _dbMovie.getMovieByID(id);
        }

        public int updateMovie(int movieId, String name, String genre, int ageLimit, String lenght)
        {
            IMovie _dbMovie = new DbMovie();
            Movie movie = new Movie();

            movie.AgeLimit = ageLimit;
            movie.Genre = genre;
            movie.Lenght = lenght;
            movie.MovieId = movieId;
            movie.Name = name;

            return _dbMovie.updateMovie(movie);
        }



    }
}
