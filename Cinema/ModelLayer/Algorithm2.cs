using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema
{
    public class Algorithm2
    {
        public Algorithm2() { }

        private static int getNumberOfFreeSeatsOnLeft(Seat[][] seats)
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

        private static int getNumberOfFreeSeatsOnRight(Seat[][] seats)
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
            int leftAvailableSeats = getNumberOfFreeSeatsOnLeft(seats);
            int rightAvailableSeats = getNumberOfFreeSeatsOnRight(seats);

            int rowNumber = seats.Length;
            

            if (noOfWantedSeats < allAvailableSeats || noOfWantedSeats == allAvailableSeats)
            {
                int halfRows = 0;
                if (rowNumber % 2 == 0)
                {
                    halfRows = rowNumber / 2;
                }
                else
                {
                    halfRows = (rowNumber / 2) + 1;
                }

                //Top-bottom check used mainly for 
                //filling up empty rows.

                //top
                if (topAvailableSeats > botAvailableSeats || topAvailableSeats == botAvailableSeats)
                {
                    //case 1 - one seat
                    if (noOfWantedSeats == 1)
                    {
                        int rowCounter = halfRows - 1;

                        //check mid
                        Boolean midFound = false;
                        while (rowCounter > -1 && midFound != true)
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

                        //check left-right
                        if (returnList.Count == 0)
                        {
                            rowCounter = halfRows - 1;
                            Boolean rowFind = false;
                            while (rowCounter > -1 && rowFind != true)
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

                                //left
                                if (getNrOfFreeSeatsOnLineLeft(innerSeatArray) > noOfWantedSeats || getNrOfFreeSeatsOnLineLeft(innerSeatArray) == noOfWantedSeats)
                                {
                                    int i = halfColumns - 1;
                                    Boolean columnFindLeft = false;
                                    while (i > -1 && columnFindLeft != true)
                                    {
                                        if (seats[rowCounter][i].Status.Equals("E") == true)
                                        {
                                            Seat wantedSeat = seats[rowCounter][i];
                                            returnList.Add(wantedSeat);
                                            columnFindLeft = true;
                                        }
                                        else
                                        {
                                            i--;
                                        }
                                    }
                                    if (columnFindLeft == true)
                                    {
                                        rowFind = true;
                                    }
                                }
                                else
                                {
                                    //right
                                    if (getNrOfFreeSeatsOnLineRight(innerSeatArray) > noOfWantedSeats || getNrOfFreeSeatsOnLineRight(innerSeatArray) == noOfWantedSeats)
                                    {
                                        int i = halfColumns;
                                        Boolean columnFindRight = false;
                                        while (i < columns && columnFindRight != true)
                                        {
                                            if (seats[rowCounter][i].Status.Equals("E") == true)
                                            {
                                                Seat wantedSeat = seats[rowCounter][i];
                                                returnList.Add(wantedSeat);
                                                columnFindRight = true;
                                            }
                                            else
                                            {
                                                i++;
                                            }
                                        }
                                        if (columnFindRight == true)
                                        {
                                            rowFind = true;
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
                    else
                    {
                        int rowCounter = halfRows - 1;
                        Boolean midFound = false;
                        int count = noOfWantedSeats;

                        //case 2 - a line is empty and I can put all seats on that line
                        while (rowCounter > -1 && midFound != true)
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

                            if ((getNrOfSeatsOnLine(innerSeatArray) > noOfWantedSeats || getNrOfSeatsOnLine(innerSeatArray) == noOfWantedSeats) && getNrOfSeatsOnLine(innerSeatArray) == columnNumber)
                            {
                                int midCount = count;
                                Boolean lineFound = false;
                                int a = halfColumns - 1;
                                int b = halfColumns;
                                int step = 0;
                                while (lineFound != true)
                                {
                                    Seat first = new Seat();
                                    Seat second = new Seat();
                                    first = seats[rowCounter][a - step];
                                    second = seats[rowCounter][b + step];
                                    step++;
                                    if (midCount > 0)
                                    {
                                        returnList.Add(first);
                                        midCount--;
                                        if (midCount > 0)
                                        {
                                            returnList.Add(second);
                                            midCount--;
                                        }
                                    }
                                    if (midCount == 0)
                                    {
                                        lineFound = true;
                                    }
                                }
                                if (lineFound == true)
                                {
                                    midFound = true;
                                }
                            }
                            else
                            {
                                rowCounter--;
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

                        //check mid
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
                                rowCounter++;
                            }
                        }

                        //check left-right
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
                                //left
                                if (getNrOfFreeSeatsOnLineLeft(innerSeatArray) > noOfWantedSeats || getNrOfFreeSeatsOnLineLeft(innerSeatArray) == noOfWantedSeats)
                                {
                                    int i = halfColumns - 1;
                                    Boolean columnFindLeft = false;
                                    while (i > -1 && columnFindLeft != true)
                                    {
                                        if (seats[rowCounter][i].Status.Equals("E") == true)
                                        {
                                            Seat wantedSeat = seats[rowCounter][i];
                                            returnList.Add(wantedSeat);
                                            columnFindLeft = true;
                                        }
                                        else
                                        {
                                            i--;
                                        }
                                    }
                                    if (columnFindLeft == true)
                                    {
                                        rowFind = true;
                                    }
                                }
                                else
                                {
                                    //right
                                    if (getNrOfFreeSeatsOnLineRight(innerSeatArray) > noOfWantedSeats || getNrOfFreeSeatsOnLineRight(innerSeatArray) == noOfWantedSeats)
                                    {
                                        int i = halfColumns;
                                        Boolean columnFindRight = false;
                                        while (i < columns && columnFindRight != true)
                                        {
                                            if (seats[rowCounter][i].Status.Equals("E") == true)
                                            {
                                                Seat wantedSeat = seats[rowCounter][i];
                                                returnList.Add(wantedSeat);
                                                columnFindRight = true;
                                            }
                                            else
                                            {
                                                i++;
                                            }
                                        }
                                        if (columnFindRight == true)
                                        {
                                            rowFind = true;
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
                    else
                    {
                        int rowCounter = halfRows;
                        Boolean midFound = false;
                        int count = noOfWantedSeats;

                        //case 2 - a line is empty and I can put all seats on that line
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

                            if ((getNrOfSeatsOnLine(innerSeatArray) > noOfWantedSeats || getNrOfSeatsOnLine(innerSeatArray) == noOfWantedSeats) && getNrOfSeatsOnLine(innerSeatArray) == columnNumber)
                            {
                                int midCount = count;
                                Boolean lineFound = false;
                                int a = halfColumns - 1;
                                int b = halfColumns;
                                int step = 0;
                                while (lineFound != true)
                                {
                                    Seat first = new Seat();
                                    Seat second = new Seat();
                                    first = seats[rowCounter][a - step];
                                    second = seats[rowCounter][b + step];
                                    step++;
                                    if (midCount > 0)
                                    {
                                        returnList.Add(first);
                                        midCount--;
                                        if (midCount > 0)
                                        {
                                            returnList.Add(second);
                                            midCount--;
                                        }
                                    }
                                    if (midCount == 0)
                                    {
                                        lineFound = true;
                                    }
                                }
                                if (lineFound == true)
                                {
                                    midFound = true;
                                }
                            }
                            else
                            {
                                rowCounter++;
                            }
                        }
                    }
                }

                //left-right check when top-bottom fails
                if (returnList.Count == 0)
                {
                    int count = noOfWantedSeats;
                    for (int i = 0; i < rowNumber; i++)
                    {
                        Boolean found = false;
                        Seat[] innerSeatArray = seats[i];
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

                        //left side
                        if (leftAvailableSeats > noOfWantedSeats || leftAvailableSeats == noOfWantedSeats)
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
                        }
                        else
                        {
                            //right check
                            if (rightAvailableSeats > noOfWantedSeats || rightAvailableSeats == noOfWantedSeats)
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
                            }
                        }
                    }
                }

                //complete liniar search - if all fails
                if (returnList.Count == 0)
                {
                    int count = noOfWantedSeats;
                    for (int i = 0; i < rowNumber; i++)
                    {
                        Seat[] innerSeatArray = seats[i];
                        int columnNo = innerSeatArray.Length;
                        for (int j = 0; j < columnNo; j++)
                        {
                            Seat seat = innerSeatArray[j];
                            if (seat.Status.Equals("E") == true)
                            {
                                if (!returnList.Contains(seat))
                                {
                                    returnList.Add(seat);
                                }
                                count--;
                            }
                            if (count == 0)
                            {
                                break;
                            }
                        }
                        if (count == 0)
                        {
                            break;
                        }
                    }
                }
            }
            
            return returnList;
        }
    }
}