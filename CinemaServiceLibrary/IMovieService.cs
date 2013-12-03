using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    [ServiceContract]
    public interface IMovieService
    {
        [OperationContract]
        int insertMovie(int movieId, String name, String genre, int ageLimit, String lenght);

        [OperationContract]
        public int updateMovie(int movieId, String name, String genre, int ageLimit, String lenght);
       
    }
}
