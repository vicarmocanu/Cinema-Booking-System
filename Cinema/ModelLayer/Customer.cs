using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.ModelLayer
{
    class Customer
    {
        private String fName;
        private String lName;
        private String city;
        private String address;
        private String email;
        private String phoneNo;
        private String username;
        private String password;

        //constructor
        public Customer(){}
        

        //getters and setters

        public String CustomerFirstName
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

        public String CustomerLastName
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

        public String CustomerCity
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        public String CustomerAddress
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public String CustomerEmail
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public String CustomerPhoneNo
        {
            get
            {
                return phoneNo;
            }
            set
            {
                phoneNo = value;
            }
        }

        public String CustomerUsername
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


        public String CustomerPassword
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
