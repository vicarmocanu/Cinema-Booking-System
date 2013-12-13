using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Cinema.ModelLayer;

namespace Cinema.Algorithm
{
    class Algorithm4
    {
        private static Seat[][] seats;
        private static Seat[] innerArray;
        private static List<Seat> returnList;
        private int count = -1;

        public static Seat[][] Seats
        {
            get { return Algorithm4.seats; }
            set { Algorithm4.seats = value; }
        }

        public Algorithm4() { }

        public static int getNrOfFreeSeatsOnLineRight(Seat[] innerArray)
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

            for (int i = middle; i < LineSeatsNr; i++)
            {
                if (innerArray[i].Status.Equals("E") == true)
                {
                    count++;
                }
            }

            return count;
        }

        public static int getNrOfFreeSeatsOnLineLeft(Seat[] innerArray)
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

        public static int getNrOfSeatsOnLine(Seat[] innerArray)
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

        public static int getNumberOfFreeSeats(Seat[][] seats)
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

        public static int getNumberOfFreeSeatsTop(Seat[][] seats)
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

            for (int i = 0; i < halfRows; i++)
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

        public static int getNumberOfFreeSeatsBot(Seat[][] seats)
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

        public void mainAlgorithm(Seat[][] receivedSeats, int noWantedSeats)
        {
            count = noWantedSeats;
            seats = receivedSeats;            
        }


        public void midOneSeat(object obj)
        {
            int row = -1;
            row = Convert.ToInt32(obj);

            innerArray = seats[row];
            int allEmptySeats = getNrOfSeatsOnLine(innerArray);
            int columns = innerArray.Length;
            int halfColumns = 0;
            if (columns % 2 == 0)
            {
                halfColumns = columns / 2;
            }
            else
            {
                halfColumns = columns / 2 + 1;
            }
            int midColumn = halfColumns - 1;

            if (allEmptySeats == columns)
            {
                Seat middleSeat = seats[row][midColumn];
                returnList.Add(middleSeat);
                count--;
            }
        }

        public void oneSeat(object obj)
        {
            int row = -1;
            row = Convert.ToInt32(obj);

            innerArray = seats[row];
        }
    }
}
