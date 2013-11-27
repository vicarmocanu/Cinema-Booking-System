using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.DBLayer
{
    interface IMovie
    {
       
        int insertMovie(Movie mov);
        List<Movie> getMovies();
        Movie getMovieByID(int id);
        int updateMovie(Movie mov);
    }
}
