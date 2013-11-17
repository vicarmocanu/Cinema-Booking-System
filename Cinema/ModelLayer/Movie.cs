using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ModelLayer
{
    class Movie
    {
        private int movieId;
        public int MovieId
        {
            get { return movieId; }
            set { movieId = value; }
        }

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String genre;
        public String Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private int ageLimit;
        public int AgeLimit
        {
            get { return ageLimit; }
            set { ageLimit = value; }
        }

        private String lenght;
        public String Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        public Movie(int movieId, String name, String genre, int ageLimit, string lenght)
        {
            movieId = movieId;
            name = name;
            genre = genre;
            ageLimit = ageLimit;
            lenght = lenght;

        }

        public Movie()
        { }
    }
}
