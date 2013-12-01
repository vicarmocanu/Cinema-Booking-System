using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ModelLayer
{
    public class Movie
    {
        private int movieId;
        private String name;
        private String genre;
        private int ageLimit;
        private String lenght;

        //constructor
        public Movie() { }

        //getters and setters

        public int MovieId
        {
            get
            { 
                return movieId;
            }
            set 
            { 
                movieId = value; 
            }
        }

        public String Name
        {
            get
            { 
                return name;
            }
            set 
            { 
                name = value;
            }
        }

        public String Genre
        {
            get 
            { 
                return genre;
            }
            set 
            { 
                genre = value; 
            }
        }

        public int AgeLimit
        {
            get
            { 
                return ageLimit; 
            }
            set 
            { 
                ageLimit = value;
            }
        }

        public String Lenght
        {
            get 
            { 
                return lenght; 
            }
            set
            { 
                lenght = value; 
            }
        }
    }
}
