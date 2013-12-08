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
            /*
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
            */

            /*
            System.Console.WriteLine("Prepare for reservation updation.");
            System.Console.ReadLine();
            System.Console.Write("firstName= ");
            String firstName = Console.ReadLine();
            System.Console.Write("lastName= ");
            String lastName = Console.ReadLine();
            System.Console.Write("sessionId= ");
            int sessionId = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("numberOfSeats= ");
            int numberOfSeats = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("price= ");
            int price = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("status= ");
            String status = Console.ReadLine();
            System.Console.Write("reservationId= ");
            int reservationId = Convert.ToInt32(Console.ReadLine());

            int result = reservationService.updateReservation(firstName, lastName, sessionId, numberOfSeats, price, status, reservationId);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */
            
            /*
            System.Console.WriteLine("Prepare for reserved seat insertion.");
            System.Console.ReadLine();
            System.Console.Write("reservationId= ");
            int reservationId = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("seatId= ");
            int seatId = Convert.ToInt32(Console.ReadLine());

            int result = reservationService.insertReservedSeat(reservationId, seatId);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */
            
            System.Console.WriteLine("A list of reservations.");
            System.Console.ReadLine();
            ReservationServiceReference.Reservation[] reservations = reservationService.getReservations();
            for (int i = 0; i < reservations.Length; i++)
            {
                System.Console.WriteLine(reservations[i].ReservationId + " " +  reservations[i].Price + ";");
            }
            System.Console.ReadLine();


        }
    }
}