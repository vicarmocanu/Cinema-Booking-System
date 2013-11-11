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
        public Customer(String custFirstName, String custLastName, String custPhoneNo)
        {
            fName = custFirstName;
            lName = custLastName;
            phoneNo = custPhoneNo;;
        }

        //simple customer (no registratio required) builder - email only
        public Customer(String custFirstName, String custLastName, String custPhoneNo)
        {
            fName = custFirstName;
            lName = custLastName;
            phoneNo = custPhoneNo;
        }

        //complete customer builder


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




        

    }
}
