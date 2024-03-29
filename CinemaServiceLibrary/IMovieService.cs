﻿using System;
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
        int insertMovie(String name, String genre, int ageLimit, int length);

        [OperationContract]
        int updateMovie(int movieId, String name, String genre, int ageLimit, int length);
        
        [OperationContract]
        int deleteMovie(int movieId);

        [OperationContract]
        Movie getMovieById(int movieId);

        [OperationContract]
        Movie getMovieByName(String name);

        [OperationContract]
        List<Movie> getMovies();
    }

    [DataContract]
    public class Movie
    {
        public int movieId;
        public String name;
        public String genre;
        public int ageLimit;
        public int length;
        public List<Movie> movies;

        [DataMemberAttribute]
        public int MovieId
        {
            get { return movieId; }
            set { movieId = value; }
        }

        [DataMemberAttribute]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMemberAttribute]
        public String Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        [DataMemberAttribute]
        public int AgeLimit
        {
            get { return ageLimit; }
            set { ageLimit = value; }
        }

        [DataMemberAttribute]
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
    }
}
