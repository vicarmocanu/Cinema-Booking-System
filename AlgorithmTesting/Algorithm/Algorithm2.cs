using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.Algorithm
{
    public class Algorithm2
    {
        public Algorithm2() { }

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

        public static List<Seat> getSeatsToReserve(Seat[][] seats, int noOfWantedSeats)
        {
            List<Seat> returnList = new List<Seat>();
            int allAvailableSeats = getNumberOfFreeSeats(seats);
            int topAvailableSeats = getNumberOfFreeSeatsTop(seats);
            int botAvailableSeats = getNumberOfFreeSeatsBot(seats);
			
            int rowNumber = seats.Length;
            int halfRows = 0;
            if (rowNumber % 2 == 0)
            {
                halfRows = rowNumber / 2;
            }
            else
            {
                halfRows = (rowNumber / 2) + 1;
            }

            if (noOfWantedSeats <= allAvailableSeats)
            {
                //top
                if (topAvailableSeats >= botAvailableSeats)
                {
                    //case 1 - one seat
                    if (noOfWantedSeats == 1)
                    {
                        int rowCounter = halfRows - 1;
                        //check the mid
                        Boolean midFound = false;
						
                        while (rowCounter >= 0 && midFound != true)
                        {
                            Seat[] innerSeatArray = seats[rowCounter];
                            int columnNumber = innerSeatArray.Length;
                            int halfColumns = 0;
                            if (columnNumber % 2 == 0)
                            {
                                halfColumns = columnNumber / 2;
                            }
                            else
                            {
                                halfColumns = columnNumber / 2 + 1;
                            }

                            int midColumn = halfColumns - 1;

                            if (getNrOfSeatsOnLine(innerSeatArray) == columnNumber)
                            {
                                Seat middleSeat = seats[rowCounter][midColumn];
                                returnList.Add(middleSeat);
                                midFound = true;
                            }
                            else
                            {
                                rowCounter--;
                            }
                        }
                        //check left
                        if (returnList.Count == 0)
                        {
                            rowCounter = halfRows - 1;
                            Boolean rowFind = false;
							
                            while (rowCounter >= 0 && rowFind != true)
                            {
                                Seat[] innerSeatArray = seats[rowCounter];
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

                                int i = halfColumns - 1;
                                Boolean columnFind = false;

                                while (i >= 0 && columnFind != true)
                                {
                                    if (seats[rowCounter][i].Status.Equals("E") == true)
                                    {
                                        Seat wantedSeat = seats[rowCounter][i];
                                        returnList.Add(wantedSeat);
                                        columnFind = true;
                                    }
                                    else
                                    {
                                        i--;
                                    }
                                }

                                if (columnFind == true)
                                {
                                    rowFind = true;
                                }
                                else
                                {
                                    rowCounter--;
                                }
                            }
                        }
                        //check right
                        if (returnList.Count == 0)
                        {
                            rowCounter = halfRows - 1;
                            Boolean rowFind = false;
							
                            while (rowCounter >= 0 && rowFind != true)
                            {
                                Seat[] innerSeatArray = seats[rowCounter];
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

                                int i = halfColumns;
                                Boolean columnFind = false;

                                while (i < columns && columnFind != true)
                                {
                                    if (seats[rowCounter][i].Status.Equals("E") == true)
                                    {
                                        Seat wantedSeat = seats[rowCounter][i];
                                        returnList.Add(wantedSeat);
                                        columnFind = true;
                                    }
                                    else
                                    {
                                        i++;
                                    }
                                }

                                if (columnFind == true)
                                {
                                    rowFind = true;
                                }
                                else
                                {
                                    rowCounter--;
                                }
                            }
                        }
                    }
                    //case 2 - more than 1
                    else
                    {
                        int rowCounter = halfRows - 1;

                        //put all on mid
                        Boolean midFound = false;
						
                        while (rowCounter >= 0 && midFound != true)
                        {
                            Seat[] innerSeatArray = seats[rowCounter];
                            int columnNumber = innerSeatArray.Length;
                            int halfColumns = 0;
                            if (columnNumber % 2 == 0)
                            {
                                halfColumns = columnNumber / 2;
                            }
                            else
                            {
                                halfColumns = columnNumber / 2 + 1;
                            }

                            int a = halfColumns - 1;
                            int b = halfColumns;

                            if (getNrOfSeatsOnLine(innerSeatArray) == columnNumber)
                            {
                                int count = noOfWantedSeats;
                                int step = 0;
                                Seat first = new Seat();
                                Seat second = new Seat();
								
                                while (count > 0)
                                {
                                    first = seats[rowCounter][a - step];
                                    if (!returnList.Contains(first))
                                    {
                                        returnList.Add(first);
                                        count--;
                                    }
                                    second = seats[rowCounter][b + step];
                                    if (!returnList.Contains(second))
                                    {
                                        returnList.Add(second);
                                        count--;
                                    }
                                    step++;
                                }
								
                                midFound = true;
                            }
                            else
                            {
                                rowCounter--;
                            }
                        }
                        //no possibility to put on mid - so we will try to fill whatever empty seats there are
                        //two cases - left and right
                        if (midFound == false)
                        {
                            Boolean found = false;
                            rowCounter = halfRows - 1;
							
                            while (rowCounter >= 0 && found != true)
                            {
                                Seat[] innerSeatArray = seats[rowCounter];
                                int columnNumber = innerSeatArray.Length;
                                int halfColumns = 0;
                                if (columnNumber % 2 == 0)
                                {
                                    halfColumns = columnNumber / 2;
                                }
                                else
                                {
                                    halfColumns = columnNumber / 2 + 1;
                                }

                                int a = halfColumns - 1;
                                int b = halfColumns;
                                int leftFree = getNrOfFreeSeatsOnLineLeft(innerSeatArray);
                                int rightFree = getNrOfFreeSeatsOnLineRight(innerSeatArray);

                                int count = noOfWantedSeats;

                                //case 1 - seats available on left
                                if (leftFree >= rightFree && leftFree >= noOfWantedSeats)
                                {
                                    Seat seat = new Seat();
									
                                    while (a > 0 & count > 0)
                                    {
                                        seat = seats[rowCounter][a];
                                        if (seat.Status.Equals("E") == true)
                                        {
                                            if (!returnList.Contains(seat))
                                            {
                                                returnList.Add(seat);
                                                count--;
                                                a--;
                                            }
                                        }
                                        else
                                        {
                                            a--;
                                        }
                                    }
                                    if (count == 0)
                                    {
                                        found = true;
                                    }
                                    else
                                    {
                                        rowCounter--;
                                    }
                                }
                                else
                                {
                                    //case 2 - seats available on right
                                    if (leftFree < rightFree && rightFree >= noOfWantedSeats)
                                    {
                                        Seat seat = new Seat();
										
                                        while (b < columnNumber && count > 0)
                                        {
                                            seat = seats[rowCounter][b];
                                            if (seat.Status.Equals("E") == true)
                                            {
                                                if (!returnList.Contains(seat))
                                                {
                                                    returnList.Add(seat);
                                                    count--;
                                                    b++;
                                                }
                                            }
                                            else
                                            {
                                                b++;
                                            }
                                        }
                                        if (count == 0)
                                        {
                                            found = true;
                                        }
                                        else
                                        {
                                            rowCounter--;
                                        }
                                    }
                                    else
                                    {
                                        rowCounter--;
                                    }
                                }
                            }
                        }
                    }
                }
                //bottom
                else
                {
                    //case 1 - one seat
                    if (noOfWantedSeats == 1)
                    {
                        int rowCounter = halfRows;
                        //check the mid
                        Boolean midFound = false;
						
                        while (rowCounter < rowNumber && midFound != true)
                        {
                            Seat[] innerSeatArray = seats[rowCounter];
                            int columnNumber = innerSeatArray.Length;
                            int halfColumns = 0;
                            if (columnNumber % 2 == 0)
                            {
                                halfColumns = columnNumber / 2;
                            }
                            else
                            {
                                halfColumns = columnNumber / 2 + 1;
                            }

                            int midColumn = halfColumns - 1;

                            if (getNrOfSeatsOnLine(innerSeatArray) == columnNumber)
                            {
                                Seat middleSeat = seats[rowCounter][midColumn];
                                returnList.Add(middleSeat);
                                midFound = true;
                            }
                            else
                            {
                                rowCounter--;
                            }
                        }
                        //check left
                        if (returnList.Count == 0) 
                        {
                            rowCounter = halfRows;
                            Boolean rowFind = false;
							
                            while (rowCounter < rowNumber && rowFind != true)
                            {
                                Seat[] innerSeatArray = seats[rowCounter];
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

                                int i = halfColumns - 1;
                                Boolean columnFind = false;

                                while (i >= 0 && columnFind != true)
                                {
                                    if (seats[rowCounter][i].Status.Equals("E") == true)
                                    {
                                        Seat wantedSeat = seats[rowCounter][i];
                                        returnList.Add(wantedSeat);
                                        columnFind = true;
                                    }
                                    else
                                    {
                                        i--;
                                    }
                                }

                                if (columnFind == true)
                                {
                                    rowFind = true;
                                }
                                else
                                {
                                    rowCounter++;
                                }
                            }
                        }
                        //check right
                        if (returnList.Count == 0)
                        {
                            rowCounter = halfRows;
                            Boolean rowFind = false;
							
                            while (rowCounter < rowNumber && rowFind != true)
                            {
                                Seat[] innerSeatArray = seats[rowCounter];
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

                                int i = halfColumns;
                                Boolean columnFind = false;

                                while (i < columns && columnFind != true)
                                {
                                    if (seats[rowCounter][i].Status.Equals("E") == true)
                                    {
                                        Seat wantedSeat = seats[rowCounter][i];
                                        returnList.Add(wantedSeat);
                                        columnFind = true;
                                    }
                                    else
                                    {
                                        i++;
                                    }
                                }

                                if (columnFind == true)
                                {
                                    rowFind = true;
                                }
                                else
                                {
                                    rowCounter++;
                                }
                            }
                        }
                    }
                    //case 2 - more than 1
                    else
                    {
                        int rowCounter = halfRows;
                        Boolean midFound = false;
						
                        while (rowCounter < rowNumber && midFound != true)
                        {
                            Seat[] innerSeatArray = seats[rowCounter];
                            int columnNumber = innerSeatArray.Length;
                            int halfColumns = 0;
                            if (columnNumber % 2 == 0)
                            {
                                halfColumns = columnNumber / 2;
                            }
                            else
                            {
                                halfColumns = columnNumber / 2 + 1;
                            }

                            int a = halfColumns - 1;
                            int b = halfColumns;

                            if (getNrOfSeatsOnLine(innerSeatArray) == columnNumber)
                            {
                                int count = noOfWantedSeats;
                                int step = 0;
                                Seat first = new Seat();
                                Seat second = new Seat();
								
                                while (count > 0)
                                {
                                    first = seats[rowCounter][a - step];
                                    if (!returnList.Contains(first))
                                    {
                                        returnList.Add(first);
                                        count--;
                                    }
                                    second = seats[rowCounter][b + step];
                                    if (!returnList.Contains(second))
                                    {
                                        returnList.Add(second);
                                        count--;
                                    }
                                    step++;
                                }
                                midFound = true;
                            }
                            else
                            {
                                rowCounter++;
                            }
                        }
                        if (midFound == false)
                        {
                            Boolean found = false;
                            rowCounter = halfRows - 1;
							
                            while (rowCounter < rowNumber && found != true)
                            {
                                Seat[] innerSeatArray = seats[rowCounter];
                                int columnNumber = innerSeatArray.Length;
                                int halfColumns = 0;
                                if (columnNumber % 2 == 0)
                                {
                                    halfColumns = columnNumber / 2;
                                }
                                else
                                {
                                    halfColumns = columnNumber / 2 + 1;
                                }

                                int a = halfColumns - 1;
                                int b = halfColumns;
                                int leftFree = getNrOfFreeSeatsOnLineLeft(innerSeatArray);
                                int rightFree = getNrOfFreeSeatsOnLineRight(innerSeatArray);
                                int count = noOfWantedSeats;

                                if (leftFree >= rightFree && leftFree >= noOfWantedSeats)
                                {
                                    Seat seat = new Seat();
									
                                    while (a > 0 & count > 0)
                                    {
                                        seat = seats[rowCounter][a];
                                        if (seat.Status.Equals("E") == true)
                                        {
                                            if (!returnList.Contains(seat))
                                            {
                                                returnList.Add(seat);
                                                count--;
                                                a--;
                                            }
                                        }
                                        else
                                        {
                                            a--;
                                        }
                                    }
                                    if (count == 0)
                                    {
                                        found = true;
                                    }
                                    else
                                    {
                                        rowCounter++;
                                    }
                                }
                                else
                                {
                                    if (leftFree < rightFree && rightFree >= noOfWantedSeats)
                                    {
                                        Seat seat = new Seat();
										
                                        while (b < columnNumber && count > 0)
                                        {
                                            seat = seats[rowCounter][b];
                                            if (seat.Status.Equals("E") == true)
                                            {
                                                if (!returnList.Contains(seat))
                                                {
                                                    returnList.Add(seat);
                                                    count--;
                                                    b++;
                                                }
                                            }
                                            else
                                            {
                                                b++;
                                            }
                                        }
                                        if (count == 0)
                                        {
                                            found = true;
                                        }
                                        else
                                        {
                                            rowCounter++;
                                        }
                                    }
                                    else
                                    {
                                        rowCounter++;
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
