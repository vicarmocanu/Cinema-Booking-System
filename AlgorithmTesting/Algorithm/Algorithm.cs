using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.Algorithm
{
    public class Algorithm
    {
        public Algorithm() { }

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

        public static int getNumberOfFreeSeatsOnLeft(Seat[][] seats)
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

                for (int j = 0; j < halfColumns; j++)
                {
                    if (seats[i][j].Status.Equals("E") == true)
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

        public static List<Seat> getSeatsToReserve(Seat[][] seats, int noOfWantedSeats)
        {
            List<Seat> returnList = new List<Seat>();

            int allAvailableSeats = getNumberOfFreeSeats(seats);
            int leftAvailableSeats = getNumberOfFreeSeatsOnLeft(seats);
            int rightAvailableSeats = getNumberOfFreeSeatsOnRight(seats);

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
                        if (found == true)
                        {
                            break;
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
                            int count = noOfWantedSeats;

                            if (leftAvailableSeats >= noOfWantedSeats)
                            {
                                while (x < halfColumnNo && found != true)
                                {
                                    Seat seat = innerSeatArray[x];
                                    if (seat.Status.Equals("E") == true)
                                    {
                                        if (!returnList.Contains(seat))
                                        {
                                            returnList.Add(seat);
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
                                if (found == true)
                                {
                                    break;
                                }
                                else
                                {
                                    returnList.Clear();

                                }
                            }
                            else
                            {
                                if (rightAvailableSeats >= noOfWantedSeats)
                                {
                                    while (y < columnNo && found != true)
                                    {
                                        Seat seat = innerSeatArray[y];
                                        if (seat.Status.Equals("E") == true)
                                        {
                                            if (!returnList.Contains(seat))
                                            {
                                                returnList.Add(seat);
                                            }
                                            count--;
                                            y++;
                                        }
                                        else
                                        {
                                            y++;
                                        }
                                        if (count == 0)
                                        {
                                            found = true;
                                        }
                                    }
                                    if (found == true)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        returnList.Clear();

                                    }
                                }
                            }
                        }
                        if (a % 2 != 0)
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
                            int count = noOfWantedSeats;

                            if (leftAvailableSeats >= noOfWantedSeats)
                            {
                                while (x > -1 && found != true)
                                {
                                    Seat seat = innerSeatArray[x];
                                    if (seat.Status.Equals("E") == true)
                                    {
                                        if (!returnList.Contains(seat))
                                        {
                                            returnList.Add(seat);
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
                                if (found == true)
                                {
                                    break;
                                }
                                else
                                {
                                    returnList.Clear();

                                }
                            }
                            else
                            {
                                if (rightAvailableSeats >= noOfWantedSeats)
                                {
                                    while (y > halfColumnNo - 1 && found != true)
                                    {
                                        Seat seat = innerSeatArray[y];
                                        if (seat.Status.Equals("E") == true)
                                        {
                                            if (!returnList.Contains(seat))
                                            {
                                                returnList.Add(seat);
                                            }
                                            count--;
                                            y--;
                                        }
                                        else
                                        {
                                            y--;
                                        }
                                        if (count == 0)
                                        {
                                            found = true;
                                        }
                                    }
                                    if (found == true)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        returnList.Clear();

                                    }
                                }
                            }
                        }
                    }
                }

                //general case - left&right
                if (noOfWantedSeats > 4)
                {
                    Boolean found = false;
                    int count = noOfWantedSeats;
                    for (int a = 0; a < rowNo; a++)
                    {
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

                            if (leftAvailableSeats >= noOfWantedSeats)
                            {
                                while (x < halfColumnNo && found != true)
                                {
                                    Seat seat = innerSeatArray[x];
                                    if (seat.Status.Equals("E") == true)
                                    {
                                        if (!returnList.Contains(seat))
                                        {
                                            returnList.Add(seat);
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
                            }
                            else
                            {
                                if (rightAvailableSeats >= noOfWantedSeats)
                                {
                                    while (y < columnNo && found != true)
                                    {
                                        Seat seat = innerSeatArray[y];
                                        if (seat.Status.Equals("E") == true)
                                        {
                                            if (!returnList.Contains(seat))
                                            {
                                                returnList.Add(seat);
                                            }
                                            count--;
                                            y++;
                                        }
                                        else
                                        {
                                            y++;
                                        }
                                        if (count == 0)
                                        {
                                            found = true;
                                        }
                                    }
                                }
                            }
                        }
                        if (a % 2 != 0)
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

                            if (leftAvailableSeats >= noOfWantedSeats)
                            {
                                while (x > -1 && found != true)
                                {
                                    Seat seat = innerSeatArray[x];
                                    if (seat.Status.Equals("E") == true)
                                    {
                                        if (!returnList.Contains(seat))
                                        {
                                            returnList.Add(seat);
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
                            }
                            else
                            {
                                if (rightAvailableSeats >= noOfWantedSeats)
                                {
                                    while (y > halfColumnNo - 1 && found != true)
                                    {
                                        Seat seat = innerSeatArray[y];
                                        if (seat.Status.Equals("E") == true)
                                        {
                                            if (!returnList.Contains(seat))
                                            {
                                                returnList.Add(seat);
                                            }
                                            count--;
                                            y--;
                                        }
                                        else
                                        {
                                            y--;
                                        }
                                        if (count == 0)
                                        {
                                            found = true;
                                        }

                                    }
                                }
                            }
                        }

                    }

                }
            }

                return returnList;
            
        }
    }

}
