using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.Algorithm
{
    class Algorithm
    {
        public Algorithm() { }


        public int getNumberOFFreeSeats(Seat[][] seats)
        {
            int count = 0;
            int rows = seats.Length;
            for (int i = 0; i < rows; i++)
            {
                Seat[] innerSeatArray = seats[i];
                int columns = innerSeatArray.Length;
                for (int j = 0; j < columns; j++)
                {
                    if (seats[i][j].Status.Equals("E") == true)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int getNumberOfFreeSeatsOnLeft(Seat[][] seats)
        {
            int count = 0;
            int rows = seats.Length;
            for(int i = 0; i<rows; i++)
            {
                Seat[] innerSeatArray = seats[i];
                int columns = innerSeatArray.Length;
                int halfColumns = 0;
                
                if(columns % 2 == 0)
                {
                    halfColumns = columns / 2;
                }
                else
                {
                    halfColumns = columns / 2 + 1;			
                }
		        
                for(int j=0; j<halfColumns; j++)
                {
                    if (seats[i][j].Status.Equals("E") == true)
                    {
                        count ++ ;
                    }
                }
            }
            return count;
        }

        public int getNumberOfFreeSeatsOnRight(Seat[][] seats)
        {
            int count = 0;
            int rows = seats.Length;
            for(int i = 0; i<rows; i++)
            {
                Seat[] innerSeatArray = seats[i];
                int columns = innerSeatArray.Length;
                int halfColumns = 0;
                
                if(columns % 2 == 0)
                {
                    halfColumns = columns / 2;
                }
                else
                {
                    halfColumns = columns / 2 + 1;	
                }
		
                for(int j= halfColumns; j<columns; j++)
                {
                    if (seats[i][j].Status.Equals("E") == true) 
                    {
                        count ++ ;
                    }
                }
            }
            return count;
        }
    }
}