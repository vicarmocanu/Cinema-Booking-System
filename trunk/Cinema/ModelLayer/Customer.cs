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

        //simple customer (no registration required) builder - phone number only
        public Customer(String fName, String lName, String phoneNo)
        {
            fName = fName;
            lName = lName;
            phoneNo = phoneNo;
        }

        //simple customer (no registratio required) builder - email only
        public Customer(String fName, String lName, String email)
        {
            fName = fName;
            lName = lName;
            email = email;
        }

        //complete customer builder
        public Customer(String fName, String lName, String city, String address, String email, String phoneNo, String username, String password)
        {
            fName = fName;
            lName = lName;
            city = city;
            address = address;
            email = email;
            phoneNo = phoneNo;
            username = username;
            password = password;
        }

        //empty customer builder
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
