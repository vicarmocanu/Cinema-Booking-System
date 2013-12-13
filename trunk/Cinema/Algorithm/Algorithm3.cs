using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.Algorithm
{
    class Algorithm3
    {
        public Algorithm3() { }

        public static int getNumberOfFreeSeats(Seat[][] seats)
        {
            int count = 0;
            int rows = seats.Length;

            Parallel.For(0, rows, i =>
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
            });

            return count;
        }

        public static int getNumberOfFreeSeatsOnLeft(Seat[][] seats)
        {
            int count = 0;
            int rows = seats.Length;

            Parallel.For(0, rows, i =>
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
            });

            return count;
        }

        public static int getNumberOfFreeSeatsOnRight(Seat[][] seats)
        {
            int count = 0;
            int rows = seats.Length;

            Parallel.For(0, rows, i =>
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
            });

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
                    Parallel.For(0, rowNo, (a, loopState) =>
                    {
                        Seat[] innerSeatArray = seats[a];
                        int columnNo = innerSeatArray.Length;

                        Boolean found = false;
                        int b = 0;

                        while (b < columnNo && found != true)
                        {
                            Seat seat = innerSeatArray[b];
                            if (seat.Status.Equals("E") == true)
                            {
                                returnList.Add(seat);
                                found = true;
                            }
                            else
                            {
                                b++;
                            }
                        }
                        if (found == true)
                        {
                            loopState.Break();
                        }
                    });
                }

                //between 2 and 4 - special case, left&right
                if (noOfWantedSeats > 1 && noOfWantedSeats < 5)
                {
                    Parallel.For(0, rowNo, (a, loopState) =>
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
                            int count = noOfWantedSeats - 1;

                            if (leftAvailableSeats >= noOfWantedSeats)
                            {
                                while (x < halfColumnNo && count > 0)
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
                                }
                                if (count == 0)
                                {
                                    loopState.Break();
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
                                        loopState.Break();
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
                            int count = noOfWantedSeats - 1;

                            if (leftAvailableSeats >= noOfWantedSeats)
                            {
                                while (x > 1 && count > 0)
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
                                }
                                if (count == 0)
                                {
                                    loopState.Break();
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
                                        loopState.Break();
                                    }
                                }
                            }
                        }
                    });
                }

                //general case - left&right
                if (noOfWantedSeats > 4)
                {
                    int count = noOfWantedSeats;
                    Parallel.For(0, rowNo, (a, loopState) =>
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
                                while (x < halfColumnNo && count > 0)
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
                                }
                                if (count == 0)
                                {
                                    loopState.Break();
                                }
                            }
                            else
                            {
                                if (rightAvailableSeats >= noOfWantedSeats)
                                {
                                    while (y < columnNo && count > 0)
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
                                    }
                                    if (count == 0)
                                    {
                                        loopState.Break();
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

                            if (leftAvailableSeats >= noOfWantedSeats)
                            {
                                while (x > -1 && count > 0)
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
                                }
                                if (count == 0)
                                {
                                    loopState.Break();
                                }
                            }
                            else
                            {
                                if (rightAvailableSeats >= noOfWantedSeats)
                                {
                                    while (y > halfColumnNo - 1 && count > 0)
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
                                    }
                                    if (count == 0)
                                    {
                                        loopState.Break();
                                    }
                                }
                            }
                        }
                    });
                }
            }
            return returnList;
        }
    }
}
