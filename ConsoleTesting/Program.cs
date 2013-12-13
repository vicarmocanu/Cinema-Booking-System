using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleTesting
{
    class Program
    {
        static int target = 61;
        static Boolean found = false;
        static int[][] numbers = new int[5][];

        static ReservationServiceReference.IReservationService reservationService = new ReservationServiceReference.ReservationServiceClient();
        static RoomServiceReference.IRoomService roomService = new RoomServiceReference.RoomServiceClient();
        static SeatServiceReference.ISeatService seatService = new SeatServiceReference.SeatServiceClient();
        static CustomerServiceReference.ICustomerService customerService = new CustomerServiceReference.CustomerServiceClient();

        static void Main(string[] args)
        {
            /*
            System.Console.WriteLine("Prepare for reservation retrieval.");
            System.Console.ReadLine();
            System.Console.WriteLine("reservationId= ");
            int reservationId = Convert.ToInt32(Console.ReadLine());
            ReservationServiceReference.Reservation serviceReservation = new ReservationServiceReference.Reservation();
            serviceReservation = reservationService.getReservation(reservationId);
            System.Console.WriteLine(serviceReservation.ReservationId + " " + serviceReservation.Customer.CustomerFirstName + " " + serviceReservation.Date + ";");
            System.Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for customer insertion");
            System.Console.ReadLine();
            System.Console.WriteLine("fName= ");
            String fName = Console.ReadLine();
            System.Console.WriteLine("lName= ");
            String lName = Console.ReadLine();
            System.Console.WriteLine("userName= ");
            String userName = Console.ReadLine();
            System.Console.WriteLine("city= ");
            String city = Console.ReadLine();
            System.Console.WriteLine("address= ");
            String address = Console.ReadLine();
            System.Console.WriteLine("email= ");
            String email = Console.ReadLine();
            System.Console.WriteLine("phoneNo= ");
            String phoneNo = Console.ReadLine();
            System.Console.WriteLine("password= ");
            String password = Console.ReadLine();           

            int result = customerService.insertCustomer(fName, lName, city, address, email, phoneNo, userName, password);
            System.Console.WriteLine("result= " + result);
            System.Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for room seat matrix insertion.");
            Console.ReadLine();
            Console.WriteLine("rows= ");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("columns= ");
            int columns = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("roomNumber= ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());

            int[] result = seatService.insertSeatMatrix(rows, columns, roomNumber);
            for (int i = 1; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.ReadLine();
             */

            /*
            int[][] numbers = new int[5][];
            numbers[0] = new int[4] { 0, 0, 0, 0 };
            numbers[1] = new int[4] { 0, 1, 0, 0 };
            numbers[2] = new int[4] { 1, 1, 0, 0 };
            numbers[3] = new int[4] { 0, 0, 1, 0 };
            numbers[4] = new int[4] { 0, 1, 1, 1 };
            int count = 0;
            Parallel.For(0, 3, i =>               
            {
                int[] innerArray = numbers[i];
                int columns = innerArray.Length;
                for (int j = 0; j < columns; j++)
                {
                    if (numbers[i][j] == 0)
                    {
                        count++;
                    }
                }
            });
            Console.WriteLine(count);
            Console.ReadLine();
            */

            Console.WriteLine("Prepare to initiate search.");
            Console.ReadLine();
            
            numbers[0] = new int[4] { 78, 156, 296, 45 };
            numbers[1] = new int[4] { 14, 18, 91, 25 };
            numbers[2] = new int[4] { 42, 9, 3, 2 };
            numbers[3] = new int[4] { 135, 48, 61, 10 };
            numbers[4] = new int[4] { 0, 2, 61, 77 };

            int rows = numbers.Length;
            int noOfThreads = rows;
             
            Thread[] threads = new Thread[noOfThreads];
            for (int i = 0; i < noOfThreads; i++)
            {
                threads[i] = new Thread(getColumnTarget);
                threads[i].Start(i);
            }

            Console.ReadLine();
        }

        public static void getColumnTarget(object obj)
        {
            int chosenLine = Convert.ToInt32(obj);
            int[] innerArray = numbers[chosenLine];
            
            for (int i = 0; i < innerArray.Length; i++)
            {
                if (innerArray[i] == target)
                {
                    int showLine = chosenLine + 1;
                    int showColumn = i + 1;
                    Console.WriteLine("Found at line " + showLine + " and column " + showColumn);
                }
            }           
        }
    }
}