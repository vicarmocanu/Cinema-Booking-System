using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace Cinema.ModelLayer
{
   public class Session
   {
       private int sessionId;
       private Movie movie;
       private Room room;
       private String date;
       private String enterTime;
       private String exitTime;
       private Seat[][] seats;
       private double price;
       
       //constructor
       public Session() { }  
       
       //getters and setters
       
       public int SessionId
       {
           get 
           {
               return sessionId;
           }
           set 
           {
               sessionId = value;
           }
       }
       
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
       
       public Room Room
       {
           get 
           {
               return room;
           }
           set 
           { 
               room = value; 
           }
       }
       
       public String Date
       {
           get
           { 
               return date;
           }
           set 
           { 
               date = value;
           }
       }
       
       public String EnterTime
       {
           get 
           { 
               return enterTime;
           }
           set
           { 
               enterTime = value; 
           }
       }
       
       public String ExitTime
       {
           get 
           { 
               return exitTime;
           }
           set
           { 
               exitTime = value; 
           }
       }
       
       public Seat[][] Seats
       {
           get 
           {
               return seats; 
           }
           set 
           { 
               seats = value;
           }
       }
       
       public double Price
       {
           get 
           { 
               return price;
           }
           set 
           { 
               price = value; 
           }
       }
       
       //own methods
       
       //make a suitable 00:00:00 time from a time
       //used when creating a session object from the database
       public String suitableTime(String time)
       {
           String suitableTime = "default";
           suitableTime = time.Substring(0, 8);
           return suitableTime;
       } 
   }
}
