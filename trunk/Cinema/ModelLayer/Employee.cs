using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ModelLayer
{
    class Employee
    {
        private String fName;
        private String lName;
        private String username;
        private String password;

        //constructor
        public Employee() { }

        //getters and setters

        public String FName
        {
            get
            {
                return fName; 
            }
            set
            {
                fName = value; 
            }
        }

        public String LName
        {
            get 
            {
                return lName; 
            }
            set
            {
                lName = value; 
            }
        }

        public String Username
        {
            get
            {
                return username; 
            }
            set
            {
                username = value; 
            }
        }

        public String Password
        {
            get 
            {
                return password; 
            }
            set 
            { 
                password = value; 
            }
        }       
    }
}
