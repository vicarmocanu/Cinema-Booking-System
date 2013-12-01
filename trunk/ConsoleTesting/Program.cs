using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ControlLayer;

namespace ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Prepare for session insertion.");
            System.Console.ReadLine();
            System.Console.WriteLine("movieId= ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("enterTime= ");
            String enterTime = Console.ReadLine();
            System.Console.WriteLine("exitTime= ");
            String exitTime = Console.ReadLine();
            System.Console.WriteLine("date= ");
            String date = Console.ReadLine();
            System.Console.WriteLine("price= ");
            double price = Convert.ToDouble(Console.ReadLine());

            SessionCtr sessionCtr = SessionCtr.getInstance();
            int result = sessionCtr.insertSession(movieId, enterTime, exitTime, date, price);
            Console.WriteLine("result = " + result);
            Console.ReadLine();
        }
    }
}
