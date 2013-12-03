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
        //static EmployeeServiceReference.IEmployeeService employeeService = new EmployeeServiceReference.EmployeeServiceClient();
        static CustomerServiceReference.ICustomerService customerService = new CustomerServiceReference.CustomerServiceClient();
        static void Main(string[] args)
        {
            System.Console.WriteLine("Prepare for customer insertion.");
            System.Console.ReadLine();
            System.Console.WriteLine("fName= ");
            String fName = Console.ReadLine();
            System.Console.WriteLine("lName= ");
            String lName = Console.ReadLine();
            System.Console.WriteLine("userName= ");
            String userName = Console.ReadLine();
            System.Console.WriteLine("password= ");
            String password = Console.ReadLine();
            System.Console.WriteLine("city= ");
            String city = Console.ReadLine();
            System.Console.WriteLine("address= ");
            String address = Console.ReadLine();
            System.Console.WriteLine("email= ");
            String email = Console.ReadLine();
            System.Console.WriteLine("phoneNo= ");
            String phoneNo = Console.ReadLine();

            int result = customerService.insertCustomer(fName, lName, city, address, email, phoneNo, userName, password);
            
            Console.WriteLine("result = " + result);
            Console.ReadLine();
            
        }
    }
}
