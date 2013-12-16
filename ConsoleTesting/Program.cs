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
        static ReservationServiceReference.IReservationService reservationService = new ReservationServiceReference.ReservationServiceClient();
        static RoomServiceReference.IRoomService roomService = new RoomServiceReference.RoomServiceClient();
        static SeatServiceReference.ISeatService seatService = new SeatServiceReference.SeatServiceClient();
        static CustomerServiceReference.ICustomerService customerService = new CustomerServiceReference.CustomerServiceClient();

        static void Main(string[] args)
        {
            /*
            System.Console.WriteLine("Prepare for customer retrieval.");
            System.Console.ReadLine();
            System.Console.WriteLine("userName= ");
            String username = System.Console.ReadLine();
            CustomerServiceReference.Customer serviceCustomer = new CustomerServiceReference.Customer();
            serviceCustomer = customerService.getCustomerByUsername(username);
            if (serviceCustomer.CustomerLastName == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.Write(serviceCustomer.CustomerFirstName + " " + serviceCustomer.CustomerLastName);
            }
            Console.ReadLine();

            System.Console.WriteLine("Prepare for reservation retrieval.");
            System.Console.ReadLine();
            System.Console.WriteLine("reservationId= ");
            int reservationId = Convert.ToInt32(Console.ReadLine());
            ReservationServiceReference.Reservation serviceReservation = new ReservationServiceReference.Reservation();
            serviceReservation = reservationService.getReservation(reservationId);
            System.Console.WriteLine(serviceReservation.ReservationId + " " + serviceReservation.Customer.CustomerFirstName + " " + serviceReservation.Date + ";");
            System.Console.ReadLine();


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


            System.Console.WriteLine("Prepare for room seat matrix insertion.");
            Console.ReadLine();
            Console.WriteLine("rows= ");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("columns= ");
            int columns = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("roomNumber= ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());
            int[] results = seatService.insertSeatMatrix(rows, columns, roomNumber);
            for (int i = 1; i < results.Length; i++)
            {
                Console.WriteLine(results[i]);
            }
            Console.ReadLine();
        }
    }
}