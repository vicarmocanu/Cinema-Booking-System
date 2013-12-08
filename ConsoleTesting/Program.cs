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
        static RoomServiceReference.IRoomService roomService = new RoomServiceReference.RoomServiceClient();
        static SeatServiceReference.ISeatService seatService = new SeatServiceReference.SeatServiceClient();

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

            
            //System.Console.WriteLine("A list of reservations.");
            //System.Console.ReadLine();
            //ReservationServiceReference.Reservation[] reservations = reservationService.getReservations();
            //for (int i = 0; i < reservations.Length; i++)
            //{
            //    System.Console.WriteLine(reservations[i].ReservationId + " " + reservations[i].Price + ";");
            //}
            //System.Console.ReadLine();
            

            /*
            System.Console.WriteLine("Prepare for room insertion.");
            System.Console.ReadLine();
            System.Console.Write("roomNumber= ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("numberOfSeats= ");
            int numberOfSeats = Convert.ToInt32(Console.ReadLine());

            int result = roomService.insertRoom(roomNumber, numberOfSeats);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for room updation.");
            System.Console.ReadLine();
            System.Console.Write("roomNumber= ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("numberOfSeats= ");
            int numberOfSeats = Convert.ToInt32(Console.ReadLine());

            int result = roomService.updateRoom(roomNumber, numberOfSeats);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for room deletion.");
            System.Console.ReadLine();
            System.Console.Write("number= ");
            int number = Convert.ToInt32(Console.ReadLine());

            int result = roomService.deleteRoomByNumber(number);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */


                                       /////   D B R O O M   /////
            //System.Console.WriteLine("Prepare for room searching by number.");
            //System.Console.ReadLine();
            //System.Console.Write("number= ");
            //int number = Convert.ToInt32(Console.ReadLine());

            //RoomServiceReference.Room room = roomService.getRoomByNumber(number);

            //Console.WriteLine(room.RoomNumber);
            //Console.WriteLine(room.NumberOfSeats);
            //Console.ReadLine();




            //System.Console.WriteLine("A list of rooms.");
            //System.Console.ReadLine();
            //RoomServiceReference.Room[] rooms = roomService.getRooms();
            //for (int i = 0; i < rooms.Length; i++)
            //{
            //    System.Console.WriteLine(rooms[i].RoomNumber + " " + rooms[i].NumberOfSeats + ";");
            //}
            //System.Console.ReadLine();

            /*
            System.Console.WriteLine("Prepare for seat insertion.");
            System.Console.ReadLine();
            System.Console.Write("seatNumber= ");
            int seatNumber = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("rowNumber= ");
            int rowNumber = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("roomNumber= ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());

            int result = seatService.insertSeat(seatNumber, rowNumber, roomNumber);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for seat updation.");
            System.Console.ReadLine();
            System.Console.Write("seatID= ");
            int seatID = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("seatNumber= ");
            int seatNumber = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("rowNumber= ");
            int rowNumber = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("roomNumber= ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());

            int result = seatService.updateSeat(seatID, seatNumber, rowNumber, roomNumber);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for seat deletion.");
            System.Console.ReadLine();
            System.Console.Write("id= ");
            int id = Convert.ToInt32(Console.ReadLine());

            int result = seatService.deleteSeatById(id);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for room seats deletion.");
            System.Console.ReadLine();
            System.Console.Write("roomNumber= ");
            int roomNumber = Convert.ToInt32(Console.ReadLine());

            int result = seatService.deleteRoomSeats(roomNumber);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

                                     ///// D B R O O M /////
            //System.Console.WriteLine("Prepare for seat searching by id.");
            //System.Console.ReadLine();
            //System.Console.Write("id= ");
            //int id = Convert.ToInt32(Console.ReadLine());

            //SeatServiceReference.Seat seat = seatService.getSeat(id);

            //Console.WriteLine(seat.SeatId);
            //Console.WriteLine(seat.SeatNumber);
            //Console.WriteLine(seat.RowNumber);
            ////Console.WriteLine(seat.Status);
            //Console.WriteLine(seat.Room);
            //Console.ReadLine();




            //System.Console.WriteLine("Prepare for seat matrix insertion.");
            //System.Console.ReadLine();
            //System.Console.Write("rows= ");
            //int rows = Convert.ToInt32(Console.ReadLine());
            //System.Console.Write("columns= ");
            //int columns = Convert.ToInt32(Console.ReadLine());
            //System.Console.Write("roomNumber= ");
            //int roomNumber = Convert.ToInt32(Console.ReadLine());

            //SeatServiceReference.Seat seat = seatService.insertSeatMatrix(rows, columns, roomNumber);
            //Console.WriteLine("result = " + seat);
            //Console.ReadLine();




            //System.Console.WriteLine("Prepare for room seats searching by roomNumber.");
            //System.Console.ReadLine();
            //System.Console.Write("roomNumber= ");
            //int roomNumber = Convert.ToInt32(Console.ReadLine());

            //SeatServiceReference.Seat seat = seatService.getRoomSeats(roomNumber);

            //Console.WriteLine(seat.SeatId);
            //Console.WriteLine(seat.SeatNumber);
            //Console.WriteLine(seat.RowNumber);
            ////Console.WriteLine(seat.Status);
            //Console.WriteLine(seat.Room);
            //Console.ReadLine();


                                 ///// D B R O O M /////
            //System.Console.WriteLine("A list of seats.");
            //System.Console.ReadLine();
            //SeatServiceReference.Seat[] seats = seatService.getSeats();
            //for (int i = 0; i < seats.Length; i++)
            //{
            //    System.Console.WriteLine(seats[i].SeatId + " " + seats[i].SeatNumber + ";");
            //}
            //System.Console.ReadLine();
        }
    }
}