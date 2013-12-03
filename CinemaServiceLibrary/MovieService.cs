using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cinema.ControlLayer;

namespace CinemaServiceLibrary
{    
    public class MovieService : IMovieService
    {
        private static MovieCtr movieCtr = new MovieCtr();
        
        public int insertMovie(int movieId, string name, string genre, int ageLimit, string lenght)
        {
            return movieCtr.insertMovie(movieId, name, genre, ageLimit, lenght);
        }

        public int updateMovie(int movieId, string name, string genre, int ageLimit, string lenght)
        {
            return movieCtr.updateMovie(movieId, name, genre, ageLimit, lenght);
        }
    }
}
