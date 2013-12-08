using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer();

namespace Cinema.Algorithm
{
    class Algorithm
    {
        public Algorithm(){}
        
        public List<Seat> getSeatsToReserve(Seats[][] seats, int noOfWantedSeats)
        {
    List<Seat> returnList = new List<Seat>();
	int totalAvailableSeats = getNumberOfFreeSeats(seats);
    int rows = seats.Length;

	if(noOfWantedSeats <= totalAvailableSeats)
	{
		
		
		
		
		if(noOfWantedSeats = 1)
		{
			for(int a=0; a< rows; a++)
		{
			Seat[] innerSeatArray = seats[i];
			int columns = innerSeatArray.Length;			
			int halfColumns = 0;
			if(colums % 2 == 0)
			{
				halfColumns = columns / 2 ;
			}
			else
			{
				halfColumns = columns / 2 + 1;
			}
			
			int x = 0;
			int y = halfColums;
			
			{
				boolean found = false;
				if(getNumberOfSeatsOnLeft(seats) !=0)
				{
					while (g < halfColumns && found!=true)
					{	
						Seat seat = innerSeatArray[g];
						if(seat.Status.Equals("E") == true)
						{
							returnList.Add(seat);
							found = true;	
						}
						else
						{
							g++;
						}
					}
				}
				else
				{
					if(getNumberOfSeatsOnRight(seats) !=0)
					{
						while(h< columns && found!=true)
						{
							Seat seat = innerSeatArray[h];
							if(seat.Status.Equals("E") == true)
							{
								returnList.Add(seat);
								fount = true;
							}
							else
							{
								h++;
							}
						}
					}
				}
			}
			else
			{
				if(noOfWantedSeats >1 & noOfWantedSeats < 5)
				{
					int count = noOfWantedSeats - 1;
				
				
				
				
				else
				{
					int count = noOfWantedSeats - 1;
					while (j < columns - 2 && count != 0)
					{
						Seat first = innerSeatArray[j];
						Seat second = innerSeatArray[j + 1];
						if (first.Status.Equals("E") == true && second.Status.Equals("E") == true)
						{
							if (!returnList.Contains(first))
							{
								returnList.Add(first);
							}
							if (!returnList.Contains(second))
							{
								returnList.Add(second);
							}
							count--;
							j++;
						}
						else
						{
							j++;
						}
					}
				}
		}
	}
    }
}
        public int getNumberOFFreeSeats(Seat[][] seats)
        {
            int count = 0;
            int rows = seats.Length;
            for(int i = 0; i<rows; i++)
            {
                Seat[] innerSeatArray = seats[i];
                int columns = innerSeatArray.Length;
                for(int j = 0; j<columns; j++)
                {
                    if(seats[i][j].Status.Equals("E") == true)
                    {
                        count ++;
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
                    if(seats[i][j].Status.Equals("E") == true;
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
                    if(seats[i][j].Status.Equals("E") == true;
                    {
                        count ++ ;
                    }
                }
            }
            return count;
        }
    }