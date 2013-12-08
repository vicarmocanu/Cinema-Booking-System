using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ControlLayer;
using Cinema.ModelLayer;

namespace ConsoleTesting
{
    class Program
    {
        //static EmployeeServiceReference.IEmployeeService employeeService = new EmployeeServiceReference.EmployeeServiceClient();
        //static CustomerServiceReference.ICustomerService customerService = new CustomerServiceReference.CustomerServiceClient();
        //static MovieServiceReference.IMovieService movieService = new MovieServiceReference.MovieServiceClient();
        static ReservationServiceReference.IReservationService reservationService = new ReservationServiceReference.ReservationServiceClient();
        //static EmployeeCtr employeeCtr = new EmployeeCtr();
        //static CustomerCtr customerCtr = new CustomerCtr();
        //static MovieCtr movieCtr = new MovieCtr();
        static ReservationCtr reservationCtr = new ReservationCtr();
        static void Main(string[] args)
        {
            /*
            System.Console.WriteLine("Prepare for employee insertion.");
            System.Console.ReadLine();
            System.Console.Write("fName= ");
            String fName = Console.ReadLine();
            System.Console.Write("lName= ");
            String lName = Console.ReadLine();
            System.Console.Write("username= ");
            String username = Console.ReadLine();
            System.Console.Write("password= ");
            String password = Console.ReadLine();

            int result = employeeService.insertEmployee(fName, lName, username, password);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for employee updation.");
            System.Console.ReadLine();
            System.Console.Write("fName= ");
            String fName = Console.ReadLine();
            System.Console.Write("lName= ");
            String lName = Console.ReadLine();
            System.Console.Write("username= ");
            String username = Console.ReadLine();
            System.Console.Write("password= ");
            String password = Console.ReadLine();

            int result = employeeService.updateEmployee(fName, lName, username, password);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for employee deletion.");
            System.Console.ReadLine();
            System.Console.Write("username= ");
            String username = Console.ReadLine();

            int result = employeeService.deleteEmployeeByUserName(username);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for employee searching by username.");
            System.Console.ReadLine();
            System.Console.Write("username= ");
            String username = Console.ReadLine();
             
            EmployeeServiceReference.Employee employee = employeeService.getEmployeeByUserName(username);
             
            Console.WriteLine(employee.Username);
            Console.WriteLine(employee.FName);
            Console.WriteLine(employee.LName);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("A list of employees.");
            System.Console.ReadLine();
            EmployeeServiceReference.Employee[] employees = employeeService.getEmployees();
            for (int i = 0; i < employees.Length; i++)
            {
                System.Console.WriteLine(employees[i].Username + " " + employees[i].Username + ";");
            }
            System.Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for customer insertion.");
            System.Console.ReadLine();
            System.Console.Write("fName= ");
            String fName = Console.ReadLine();
            System.Console.Write("lName= ");
            String lName = Console.ReadLine();
            System.Console.Write("city= ");
            String city = Console.ReadLine();
            System.Console.Write("address= ");
            String address = Console.ReadLine();
            System.Console.Write("email= ");
            String email = Console.ReadLine();
            System.Console.Write("phoneNo= ");
            String phoneNo = Console.ReadLine();
            System.Console.Write("username= ");
            String username = Console.ReadLine();
            System.Console.Write("password= ");
            String password = Console.ReadLine();

            int result = customerService.insertCustomer(fName, lName, city, address, email, phoneNo, username, password);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for customer updation.");
            System.Console.ReadLine();
            System.Console.Write("fName= ");
            String fName = Console.ReadLine();
            System.Console.Write("lName= ");
            String lName = Console.ReadLine();
            System.Console.Write("city= ");
            String city = Console.ReadLine();
            System.Console.Write("address= ");
            String address = Console.ReadLine();
            System.Console.Write("email= ");
            String email = Console.ReadLine();
            System.Console.Write("phoneNo= ");
            String phoneNo = Console.ReadLine();
            System.Console.Write("username= ");
            String username = Console.ReadLine();
            System.Console.Write("password= ");
            String password = Console.ReadLine();

            int result = customerService.updateCustomer(fName, lName, city, address, email, phoneNo, username, password);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for customer deletion.");
            System.Console.ReadLine();
            System.Console.Write("fName= ");
            String fName = Console.ReadLine();
            System.Console.Write("lName= ");
            String lName = Console.ReadLine();

            int result = customerService.deleteCustomerByName(fName, lName);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for customer deletion.");
            System.Console.ReadLine();
            System.Console.Write("userName= ");
            String userName = Console.ReadLine();

            int result = customerService.deleteCustomerByUserName(userName);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for customer searching by name.");
            System.Console.ReadLine();
            System.Console.Write("fName= ");
            String fName = Console.ReadLine();
            System.Console.Write("lName= ");
            String lName = Console.ReadLine();

            CustomerServiceReference.Customer customer = customerService.getCustomerByName(fName, lName);

            Console.WriteLine(customer.CustomerFirstName);
            Console.WriteLine(customer.CustomerLastName);
            Console.WriteLine(customer.CustomerCity);
            Console.WriteLine(customer.CustomerAddress);
            Console.WriteLine(customer.CustomerEmail);
            Console.WriteLine(customer.CustomerPhoneNo);
            Console.WriteLine(customer.CustomerUsername);
            Console.WriteLine(customer.CustomerPassword);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for customer searching by username.");
            System.Console.ReadLine();
            System.Console.Write("username= ");
            String username = Console.ReadLine();

            CustomerServiceReference.Customer customer = customerService.getCustomerByUsername(username);

            Console.WriteLine(customer.CustomerFirstName);
            Console.WriteLine(customer.CustomerLastName);
            Console.WriteLine(customer.CustomerCity);
            Console.WriteLine(customer.CustomerAddress);
            Console.WriteLine(customer.CustomerEmail);
            Console.WriteLine(customer.CustomerPhoneNo);
            Console.WriteLine(customer.CustomerUsername);
            Console.WriteLine(customer.CustomerPassword);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("A list of customers.");
            System.Console.ReadLine();
            CustomerServiceReference.Customer[] customers = customerService.getCustomers();
            for (int i = 0; i < customers.Length; i++)
            {
                System.Console.WriteLine(customers[i].CustomerUsername + " " + customers[i].CustomerUsername + ";");
            }
            System.Console.ReadLine();
            */
            
            /*
            System.Console.WriteLine("Prepare for movie insertion.");
            System.Console.ReadLine();
            System.Console.Write("name= ");
            String name = Console.ReadLine();
            System.Console.Write("genre= ");
            String genre = Console.ReadLine();
            System.Console.Write("ageLimit= ");
            int ageLimit = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("length= ");
            int length = Convert.ToInt32(Console.ReadLine());

            int result = movieService.insertMovie(name, genre, ageLimit, length);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for movie updation.");
            System.Console.ReadLine();
            System.Console.Write("movieId= ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("name= ");
            String name = Console.ReadLine();
            System.Console.Write("genre= ");
            String genre = Console.ReadLine();
            System.Console.Write("ageLimit= ");
            int ageLimit = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("length= ");
            int length = Convert.ToInt32(Console.ReadLine());

            int result = movieService.updateMovie(movieId, name, genre, ageLimit, length);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            /*
            System.Console.WriteLine("Prepare for movie deletion.");
            System.Console.ReadLine();
            System.Console.Write("movieId= ");
            int movieId = Convert.ToInt32(Console.ReadLine());

            int result = movieService.deleteMovie(movieId);

            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            ///*
            //System.Console.WriteLine("movieId= ");
            //int movieId = Convert.ToInt32(System.Console.ReadLine());
            //MovieServiceReference.Movie movie = movieService.getMovieById(movieId);
            //Console.WriteLine(movie.Name);
            //Console.ReadLine();
            //*/

            /*
            System.Console.WriteLine("A list of movies.");
            System.Console.ReadLine();            
            MovieServiceReference.Movie[] movies = movieService.getMovies();
            for(int i = 0; i<movies.Length; i++)
            {
                System.Console.WriteLine(movies[i].MovieId + " " + movies[i].Name + ";");
            } 
            System.Console.ReadLine();
            */
            
            ///*
            //System.Console.WriteLine("A list of movies.");
            //System.Console.ReadLine();
            //List<Movie> returnList = new List<Movie>();
            //returnList = movieCtr.getMovies();
            //foreach (Movie movie in returnList)
            //{
            //    System.Console.WriteLine(movie.MovieId + " " + movie.Name + " " + movie.AgeLimit + ";");
            //}
            //Console.ReadLine();
            //*/           

            //System.Console.WriteLine("Prepare for reservation insertion.");
            //System.Console.ReadLine();
            //System.Console.Write("firstName= ");
            //String firstName = Console.ReadLine();
            //System.Console.Write("lastName= ");
            //String lastName = Console.ReadLine();
            //System.Console.Write("sessionId= ");
            //int sessionId = Convert.ToInt32(Console.ReadLine());
            //System.Console.Write("numberOfSeats= ");
            //int numberOfSeats = Convert.ToInt32(Console.ReadLine());
            //System.Console.Write("price= ");
            //int price = Convert.ToInt32(Console.ReadLine());

            //int result = reservationService.insertReservation(firstName, lastName, sessionId, numberOfSeats, price);

            //Console.WriteLine("result = " + result);
            //Console.ReadLine();

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

            
            //System.Console.WriteLine("Prepare for reserved seat updation.");
            //System.Console.ReadLine();
            //System.Console.Write("reservationId= ");
            //int reservationId = Convert.ToInt32(Console.ReadLine());
            //System.Console.Write("seatId= ");
            //int seatId = Convert.ToInt32(Console.ReadLine());
            //System.Console.Write("status= ");
            //String status = Console.ReadLine();

            //int result = reservationService.updateReservedSeat(reservationId, seatId, status);

            //Console.WriteLine("result = " + result);
            //Console.ReadLine();
            



            //System.Console.WriteLine("Prepare for seats from reservation updation.");
            //System.Console.ReadLine();
            //System.Console.Write("reservationId= ");
            //int reservationId = Convert.ToInt32(Console.ReadLine());
            //System.Console.Write("status= ");
            //String status = Console.ReadLine();

            //int result = reservationService.updateSeatsFromReservation(reservationId, status);

            //Console.WriteLine("result = " + result);
            //Console.ReadLine();






            //System.Console.WriteLine("Prepare for getting reservation.");
            //System.Console.ReadLine();
            //System.Console.Write("reservationId= ");
            //int reservationId = Convert.ToInt32(Console.ReadLine());

            //ReservationServiceReference.Reservation reservation = reservationService.getReservation(reservationId);

            //Console.WriteLine(reservation.ReservationId);
            //Console.WriteLine(reservation.Customer);
            //Console.WriteLine(reservation.Session);
            //Console.WriteLine(reservation.NoOfSeats);
            //Console.WriteLine(reservation.ReservedSeats);
            //Console.WriteLine(reservation.Price);
            //Console.WriteLine(reservation.Date);
            //Console.WriteLine(reservation.Status);
            //Console.ReadLine();



            //System.Console.WriteLine("A list of reservations.");
            //System.Console.ReadLine();
            //ReservationServiceReference.Reservation[] reservations = reservationService.getReservations();
            //for (int i = 0; i < reservations.Length; i++)
            //{
            //    System.Console.WriteLine(reservations[i].ReservationId + " " +  reservations[i].Status ";");
            //}
            //System.Console.ReadLine();
        }
    }
}
