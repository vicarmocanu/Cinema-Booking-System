using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting
{
    class Program
    {
        static ReservationServiceReference.IReservationService reservationService = new ReservationServiceReference.ReservationServiceClient();

        static void Main(string[] args)
        {
            
            System.Console.WriteLine("ReservationInsertion");
            System.Console.ReadLine();
            System.Console.WriteLine("fname= ");
            String firstName = Console.ReadLine();
            System.Console.WriteLine("lastName= ");
            String lastName = Console.ReadLine();
            System.Console.WriteLine("sessionId= ");
            int sessionId = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("numberOfSeats= ");
            int numberOfSeats = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("price= ");
            double price = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("status = ");
            String status = Console.ReadLine();

            int result = reservationService.insertReservation(firstName, lastName, sessionId, numberOfSeats, price, status);
            Console.WriteLine("result = " + result);
            Console.ReadLine();
            

            DateTime currentDate = DateTime.Now;
            String currentDateString = currentDate.ToString("yyyy-MM-dd");
            
           
            String wantedDate = "1900-01-01";
            wantedDate = currentDateString;

            Console.WriteLine(wantedDate);
            Console.ReadLine();
        }
    }
}