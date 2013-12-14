using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static int[][] seats = new int[5][];
        static Object obj = new Object();
        static int count = 0;
        static int noWantedSeats = 4;
        static Boolean found = false;
        
        
        static void Main(string[] args)
        {
            seats[0] = new int[4] { 0, 1, 1, 0 };
            seats[1] = new int[4] { 1, 1, 1, 1 };
            seats[2] = new int[4] { 1, 0, 0, 0 };
            seats[3] = new int[4] { 1, 0, 0, 0 };
            seats[4] = new int[4] { 0, 0, 0, 0 };

            int noOfWantedSeats = 4;

            Boolean found = false;
            int count = -1;

            Console.Write("Serial");
            for (int i = 0; i < seats.Length; i++)
            {
                count = noOfWantedSeats;
                int[] innerArray = seats[i];
                int columns = innerArray.Length;
                for (int j = 0; j < columns; j++)
                {
                    if (seats[i][j] == 0)
                    {
                        count--;
                    }
                    if (count == 0)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == true)
                {
                    System.Console.WriteLine(i + 1);
                    break;
                }
            }

            Console.WriteLine("Parallel");
            int noOfThreads = seats.Length;
            Thread[] threads = new Thread[noOfThreads];
            for (int i = 0; i < noOfThreads; i++)
            {
                threads[i] = new Thread(getColumnTarget);
                threads[i].Start();
                int j = 0;
                while (j < 1000000)
                {
                    j++;
                }
                if (found == true)
                    break;      
            }
            

            Console.ReadLine();

        }

        public static void getColumnTarget(object obj)
        {
            int chosenLine = Convert.ToInt32(obj);
            int[] innerArray = seats[chosenLine];
            count = noWantedSeats;
            int columns = innerArray.Length;
            int i = 0;
            found = false;
            while (i < columns && found != true)
            {
                if (innerArray[i] == 0)
                {
                    count--;
                }
                else
                {
                    i++;
                }
                if(count == 0)
                {
                    System.Console.WriteLine("Line: " + chosenLine);
                    found = true;
                }
            }
        }   

    }
}
