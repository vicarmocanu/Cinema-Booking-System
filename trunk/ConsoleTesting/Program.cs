using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting
{
    class Program
    {
        //static EmployeeServiceReference.IEmployeeService employeeService = new EmployeeServiceReference.EmployeeServiceClient();
        //static CustomerServiceReference.ICustomerService customerService = new CustomerServiceReference.CustomerServiceClient();
        static MovieServiceReference.IMovieService movieService = new MovieServiceReference.MovieServiceClient();
        static void Main(string[] args)
        {
            /*
            System.Console.WriteLine("Prepare for movie insertion.");
            System.Console.ReadLine();
            System.Console.WriteLine("name= ");
            String name = Console.ReadLine();
            System.Console.WriteLine("genre= ");
            String genre = Console.ReadLine();
            System.Console.WriteLine("ageLimit= ");
            int ageLimit = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("length= ");
            int lenglth = Convert.ToInt32(Console.ReadLine());

            int result = movieService.insertMovie(name, genre, ageLimit, lenght);
            
            Console.WriteLine("result = " + result);
            Console.ReadLine();
            */

            System.Console.WriteLine("movieId= ");
            int movieId = Convert.ToInt32(System.Console.ReadLine());
            MovieServiceReference.Movie movie = movieService.getMovieById(movieId);
            Console.WriteLine(movie.Name);
            Console.ReadLine();
            
            
        }
    }
}
