using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;


namespace Cinema.Algorithm
{
    class Algorithm2
    {
        public int getNumberOfFreeSeats(Seat[][] seats)
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

        public int getNumberOfFreeSeatsTop(Seat[][] seats)
        {
            int count = 0;
            int rows = seats.Lenght;
            int halfRows = 0;
            if (rows % 2 == 0)
            {
                halfRows = rows / 2;
            }
            else
            {
                halfRows = (rows / 2) + 1;
            }

            for(int i = 0;i<halfRows; i++)
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

        public int getNumberOfFreeSeatsBot(Seat[][] seats)
        { 
            
        }
    }
}
