using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AlgorithmTesting
{
    class Program
    {
        static int[][] seats; //= new int[5][];
        static int count = -1;
        static int noOfWantedSeats = 6;
        static Object _lock = new Object();
        static Boolean liniarFound = false;
        static volatile Boolean parallelFound = false;



        static void Main(string[] args)
        {
            int[][] receivedSeats = new int[5][];
            receivedSeats[0] = new int[10] { 2, 1, 1, 1, 1, 1, 0, 0, 0, 0 };
            receivedSeats[1] = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            receivedSeats[2] = new int[10] { 0, 2, 1, 1, 0, 0, 0, 0, 0, 0 };
            receivedSeats[3] = new int[10] { 0, 0, 0, 0, 2, 1, 0, 1, 0, 1 };
            receivedSeats[4] = new int[10] { 0, 0, 0, 0, 1, 0, 1, 0, 2, 0 };
            seats = receivedSeats;

            System.Console.WriteLine("Start?");
            System.Console.ReadLine();
            System.Console.WriteLine("Liniar");
            System.Console.ReadLine();
            LiniarSearch();           
            System.Console.ReadLine();
            System.Console.WriteLine("Paralel");
            System.Console.ReadLine();
            ThreadSearch();
            System.Console.ReadLine();
            List<int> list = seats.SelectMany(x => x).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            System.Console.ReadLine();
        }

        public static void LiniarSearch()
        {
            int result = -1;
            for (int i = 0; i < seats.Length; i++)
            {                
                liniarFound = false;
                count = noOfWantedSeats;
                int[] innerArray = seats[i];
                int columns = innerArray.Length;
                int j = 0;
                while (j < columns && liniarFound != true)
                {
                    if (innerArray[j] == 0)
                    {
                        count--;
                        j++;
                    }
                    else
                    {
                        j++;
                    }
                    if (count == 0)
                    {
                        result = i + 1;
                        System.Console.WriteLine("Found at: " + result);
                        liniarFound = true;
                    }
                }
                if(liniarFound == true)
                {                    
                    break;
                }
            }
        }

        public static void PartialSearch(Object obj)
        {
            int i = Convert.ToInt32(obj);
            int result = -1;
            //parallelFound = false;
            //count = noOfWantedSeats;            
            int[] innerArray = seats[i];
            int columns = innerArray.Length;
            int j = 0;
            while (j < columns && parallelFound != true)
            {
                if (innerArray[j] == 0)
                {
                    count--;
                    j++;
                }
                else
                {
                    j++;
                }
                if (count == 0)
                {
                    result = i + 1;
                    System.Console.WriteLine("Found at: " + result);
                    parallelFound = true;
                }
            }
        }

        public static void ThreadSearch()
        {
            int rows = seats.Length;
            int noOfThreads = rows;

            Thread[] threads = new Thread[noOfThreads];

            count = noOfWantedSeats; 
            for (int i = 0; i < rows; i++)
            {
                threads[i] = new Thread(PartialSearch);
                threads[i].Start(i);
                int h = 0;
                while(h< 1000000)
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
}
