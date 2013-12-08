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
        static CustomerServiceReference.ICustomerService customerService = new CustomerServiceReference.CustomerServiceClient();
        //static MovieServiceReference.IMovieService movieService = new MovieServiceReference.MovieServiceClient();
        //static EmployeeCtr employeeCtr = new EmployeeCtr();
        static CustomerCtr customerCtr = new CustomerCtr();
        //static MovieCtr movieCtr = new MovieCtr();
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
        }
    }
}
