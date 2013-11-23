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

        public String FName
        {
            get { return fName; }
            set { fName = value; }
        }
        private String lName;

        public String LName
        {
            get { return lName; }
            set { lName = value; }
        }
        private String username;

        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public Employee() { }
    }
}
