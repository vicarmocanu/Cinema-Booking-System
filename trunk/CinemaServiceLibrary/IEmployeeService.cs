using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CinemaServiceLibrary
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        int insertEmployee(String fName, String lName, String username, String password);

        [OperationContract]
        int updateEmployee(String fName, String lName, String username, String password);
    }

    [DataContract]
    public class Employee
    {
        private String fName;
        private String lName;
        private String username;
        private String password;

        [DataMemberAttribute]
        public String FName
        {
            get { return fName; }
            set { fName = value; }
        }

        [DataMemberAttribute]
        public String LName
        {
            get { return lName; }
            set { lName = value; }
        }

        [DataMemberAttribute]
        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMemberAttribute]
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
