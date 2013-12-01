using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.ModelLayer
{
   public class TimeTable
    {
        private Movie movie;
        private List<Session> sessionList;

        //constructor
        public TimeTable() { }

        //getters and setters

        public Movie Movie
        {
            get 
            { 
                return movie; 
            }
            set 
            { 
                movie = value;
            }
        }  

        public List<Session> SessionList
        {
            get 
            { 
                return sessionList;
            }
            set
            { 
                sessionList = value;
            }
        }       
    }
}
