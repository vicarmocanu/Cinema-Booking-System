using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;
using System.Threading;

namespace Cinema.Algorithm
{
    class Algorithm3
    {
        private static int allAvailableSeats = -1;
        private static int leftAvailableSeats = -1;
        private static int rightAvailableSeats = -1;
        private static int generalCount = -1;        
        static volatile Boolean parallelFound = false;
        private static List<Seat> returnList;
        private static Seat[][] seats;

        public Algorithm3() { }

        public static int getNumberOfFreeSeats(Seat[][] seats)
        {
            int count = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                Seat[] innerSeatArray = seats[i];
                for (int j = 0; j < innerSeatArray.Length; j++)
                {
                    if (innerSeatArray[j].Status.Equals("E") == true)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int getNumberOfFreeSeatsOnLeft(Seat[][] seats)
        {
            int count = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                Seat[] innerSeatArray = seats[i];
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
                for (int j = 0; j < halfColumns; j++)
                {
                    if (innerSeatArray[j].Status.Equals("E") == true)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int getNumberOfFreeSeatsOnRight(Seat[][] seats)
        {
            int count = 0;
            int rows = seats.Length;
            for (int i = 0; i < rows; i++)
            {
                Seat[] innerSeatArray = seats[i];
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
                for (int j = halfColumns; j < columns; j++)
                {
                    if (seats[i][j].Status.Equals("E") == true)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static List<Seat> getSeatsToReserve(Seat[][] receivedSeats, int noOfWantedSeats)
        {
            returnList = new List<Seat>();
            seats = receivedSeats;
            allAvailableSeats = getNumberOfFreeSeats(seats);
            leftAvailableSeats = getNumberOfFreeSeatsOnLeft(seats);
            rightAvailableSeats = getNumberOfFreeSeatsOnRight(seats);

            if (noOfWantedSeats <= allAvailableSeats)
            {
                int rowNo = seats.Length;

                //for only one seat - all 
                if (noOfWantedSeats == 1)
                {
                    for (int i = 0; i < rowNo; i++)
                    {
                        Seat[] innerSeatArray = seats[i];
                        int columnNo = innerSeatArray.Length;
                        Boolean found = false;
                        int j = 0;
                        while (j < columnNo && found != true)
                        {
                            Seat seat = innerSeatArray[j];
                            if (seat.Status.Equals("E") == true)
                            {
                                returnList.Add(seat);
                                found = true;
                            }
                            else
                            {
                                j++;
                            }
                        }
                    }
                }

                //between 2 and 4 - special case, left&right
                if (noOfWantedSeats > 1 && noOfWantedSeats < 5)
                {
                    for (int a = 0; a < rowNo; a++)
                    {
                        Boolean found = false;
                        if (a % 2 == 0)
                        {
                            Seat[] innerSeatArray = seats[a];
                            int columnNo = innerSeatArray.Length;
                            int halfColumnNo = 0;
                            if (columnNo % 2 == 0)
                            {
                                halfColumnNo = columnNo / 2;
                            }
                            else
                            {
                                halfColumnNo = columnNo / 2 + 1;
                            }
                            int x = 0;
                            int y = halfColumnNo;
                            int count = noOfWantedSeats - 1;

                            if (leftAvailableSeats >= noOfWantedSeats)
                            {
                                while (x < halfColumnNo && found != true)
                                {
                                    Seat first = innerSeatArray[x];
                                    Seat second = innerSeatArray[x + 1];
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
                                        x++;
                                    }
                                    else
                                    {
                                        x++;
                                    }
                                    if (count == 0)
                                    {
                                        found = true;
                                    }
                                }
                                if (count == 0)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (rightAvailableSeats >= noOfWantedSeats)
                                {
                                    while (y < columnNo && count > 0)
                                    {
                                        Seat first = innerSeatArray[y];
                                        Seat second = innerSeatArray[y + 1];
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
                                            y++;
                                        }
                                        else
                                        {
                                            y++;
                                        }
                                    }
                                    if (count == 0)
                                    {
                                        found = true;
                                    }
                                }
                                if (count == 0)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Seat[] innerSeatArray = seats[a];
                            int columnNo = innerSeatArray.Length;
                            int halfColumnNo = 0;
                            if (columnNo % 2 == 0)
                            {
                                halfColumnNo = columnNo / 2;
                            }
                            else
                            {
                                halfColumnNo = columnNo / 2 + 1;
                            }
                            int x = halfColumnNo - 1;
                            int y = columnNo - 1;
                            int count = noOfWantedSeats - 1;

                            if (leftAvailableSeats >= noOfWantedSeats)
                            {
                                while (x > 1 && count != 0)
                                {
                                    Seat first = innerSeatArray[x];
                                    Seat second = innerSeatArray[x - 1];
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
                                        x--;
                                    }
                                    else
                                    {
                                        x--;
                                    }
                                    if (count == 0)
                                    {
                                        found = true;
                                    }
                                }
                                if (count == 0)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (rightAvailableSeats >= noOfWantedSeats)
                                {
                                    while (y > halfColumnNo + 1 && count > 0)
                                    {
                                        Seat first = innerSeatArray[y];
                                        Seat second = innerSeatArray[y - 1];
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
                                            y--;
                                        }
                                        else
                                        {
                                            y--;
                                        }
                                    }
                                    if (count == 0)
                                    {
                                        found = true;
                                    }
                                }
                                if (count == 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                //general case - left&right
                if (noOfWantedSeats > 4)
                {
                    parallelFound = false;
                    generalCount = noOfWantedSeats;
                    int noOfThreads = rowNo;
                    Thread[] threads = new Thread[noOfThreads];
                    for (int i = 0; i < noOfThreads; i++)
                    {
                        threads[i] = new Thread(partialAddition);
                        threads[i].Start(i);
                        int h = 0;
                        while (h < 1000000)
                        {
                            h++;
                        }
                        if (parallelFound == true)
                        {
                            break;
                        }
                    }                    
                }
            }
            return returnList;
        }

        private static void partialAddition(Object obj)
        {
            int a = Convert.ToInt32(obj);            
            if (a % 2 == 0)
            {
                Seat[] innerSeatArray = seats[a];
                int columnNo = innerSeatArray.Length;                
                int halfColumnNo = 0;
                if (columnNo % 2 == 0)
                {
                    halfColumnNo = columnNo / 2;
                }
                else
                {
                    halfColumnNo = columnNo / 2 + 1;
                }                
                int x = 0;
                int y = halfColumnNo;
                
                if (leftAvailableSeats >= generalCount)
                {
                    while (x < halfColumnNo && generalCount > 0)
                    {
                        Seat seat = innerSeatArray[x];
                        if (seat.Status.Equals("E") == true)
                        {
                            if (!returnList.Contains(seat))
                            {
                                returnList.Add(seat);
                            }
                            generalCount--;
                            x++;
                        }
                        else
                        {
                            x++;
                        }
                    }
                    if (generalCount == 0)
                    {
                        parallelFound = true;
                    }
                }
                else
                {
                    if (rightAvailableSeats >= generalCount)
                    {
                        while (y < columnNo && generalCount > 0)
                        {
                            Seat seat = innerSeatArray[y];
                            if (seat.Status.Equals("E") == true)
                            {
                                if (!returnList.Contains(seat))
                                {
                                    returnList.Add(seat);
                                }
                                generalCount--;
                                y++;
                            }
                            else
                            {
                                y++;
                            }
                        }
                        if (generalCount == 0)
                        {
                            parallelFound = true;
                        }
                    }
                }
            }
            else
            {
                Seat[] innerSeatArray = seats[a];
                int columnNo = innerSeatArray.Length;
                int halfColumnNo = 0;
                if (columnNo % 2 == 0)
                {
                    halfColumnNo = columnNo / 2;
                }
                else
                {
                    halfColumnNo = columnNo / 2 + 1;
                }
                int x = halfColumnNo - 1;
                int y = columnNo - 1;

                if (leftAvailableSeats >= generalCount)
                {
                    while (x > -1 && generalCount > 0)
                    {
                        Seat seat = innerSeatArray[x];
                        if(seat.Status.Equals("E") == true)
                        {
                            if (!returnList.Contains(seat))
                            {
                                returnList.Add(seat);
                            }
                            
                            generalCount--;
                            x--;
                        }
                        else
                        {
                            x--;
                        }
                    }
                    if (generalCount == 0)
                    {
                        parallelFound = true;
                    }
                }
                else
                {
                    if (rightAvailableSeats >= generalCount)
                    {
                        while (y > halfColumnNo - 1 && generalCount > 0)
                        {
                            Seat seat = innerSeatArray[y];
                            if (seat.Status.Equals("E") == true)
                            {
                                if (!returnList.Contains(seat))
                                {
                                    returnList.Add(seat);
                                }
                                generalCount--;
                                y--;
                            }
                            else
                            {
                                y--;
                            }
                        }
                        if (generalCount == 0)
                        {
                            parallelFound = true;
                        }
                    }
                }
            }
        }
    }
}
