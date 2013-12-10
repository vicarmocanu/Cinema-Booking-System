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

        public int getNrOfFreeSeatsOnLineRight(Seat[] innerArray)
        {
            int count = 0;
            int LineSeatsNr = innerArray.Length;
            int middle = 0;
            if (LineSeatsNr % 2 == 0)
            {
                middle = LineSeatsNr / 2;

            }
            else
            {
                middle = (LineSeatsNr / 2) + 1;
            }
            for (int i = middle; i <LineSeatsNr; i++)
            {
                if (innerArray[i].Status.Equals("E") == true)
                {
                    count++;
                }
            }

            return count;

        }

        public int getNrOfFreeSeatsOnLineLeft(Seat[] innerArray)
        {
            int count = 0;
            int LineSeatsNr = innerArray.Length;
            int middle = 0;
            if (LineSeatsNr % 2 == 0)
            {
                middle = LineSeatsNr / 2;

            }
            else
            {
                middle = (LineSeatsNr / 2) + 1;
            }
            for (int i = 0; i < middle; i++)
            {
                if (innerArray[i].Status.Equals("E") == true)
                {
                    count++;
                }
            }

            return count;

        }

        public int getNrOfSeatsOnLine(Seat[] innerArray)
        {
            int count = 0;
            int LineSeatsNr = innerArray.Length;
            for (int i = 0; i < LineSeatsNr; i++)
            {
                if (innerArray[i].Status.Equals("E") == true)
                {
                    count++;
                }

            }

            return count;

        }

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
            int rows = seats.Length;
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
            int count = 0;
            int rows = seats.Length;
            int halfRows = 0;
            if (rows % 2 == 0)
            {
                halfRows = rows / 2;
            }
            else
            {
                halfRows = (rows / 2) + 1;
            }

            for (int i = halfRows; i < rows; i++)
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

        public List<Seat> getSeatsToReserve(Seat[][] seats, int noOfWantedSeats)
        { 
            List<Seat> returnList = new List<Seat>();
            int allAvailableSeats = getNumberOfFreeSeats(seats);
            int topAvailableSeats = getNumberOfFreeSeatsTop(seats);
            int botAvailableSeats = getNumberOfFreeSeatsBot(seats);
            
            
            int rowNumber = seats.Length;
            int halfRows = 0;
            if(rowNumber%2 == 0)
            {
                halfRows = rowNumber/2;

            }
            else
            {
                halfRows = (rowNumber/2) + 1;
            }

            if (noOfWantedSeats <= allAvailableSeats)
            {

                
                if (topAvailableSeats >= botAvailableSeats)
                {
                    for (int a = halfRows - 1; a >= 0; a--)
                    {
                        Seat[] innerSeatArray = seats[a];
                        int columns = innerSeatArray.Length;
                        int halfColumns = 0;
                        if (columns % 2 == 0)
                        {
                            halfColumns = columns / 2;

                        }
                        else
                        {
                            halfColumns = columns / 2 + 1;
                        }

                        int middleChecker = halfColumns - 1;
                        int count = noOfWantedSeats;


                        if (seats[a][middleChecker].Status.Equals("E") == true)
                        { 
                            Seat middleSeat = seats[a][middleChecker];
                            returnList.Add(middleSeat);
                            count--;
                            int leftCount = 0;
                            int rightCount = 0;
                            if (count % 2 == 0)
                            {
                                leftCount = count / 2;
                                rightCount = count / 2;

                            }
                            else
                            {
                                leftCount = count / 2 + 1;
                                rightCount = count / 2;
                            }


                        }
                    }
                }


            }
            return returnList;

        }


    }
}
