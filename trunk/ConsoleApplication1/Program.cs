using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ControlLayer;


namespace Console Tester
{
    class Program
    {


        static void Main(string[] args)
        {
            System.Console.WriteLine("Prepare for employee insertion.");
            System.Console.ReadLine();
            System.Console.WriteLine("fName= ");
            String fName = Console.ReadLine();
            System.Console.WriteLine("lName= ");
            String lName = Console.ReadLine();
            System.Console.WriteLine("userName= ");
            String userName = Console.ReadLine();
            System.Console.WriteLine("password= ");
            String password = Console.ReadLine();

            EmployeeCtr employeeCtr = EmployeeCtr.getInstance();
            int result = employeeCtr.updateEmployee(fName, lName, userName, password);
            Console.WriteLine("result = " + result);
            Console.ReadLine();

        }

       
    }
}
