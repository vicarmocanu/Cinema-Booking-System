﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.DBLayer
{
    interface IEmployee
    {        
        int insertEmployee(Employee employee);
        List<Employee> getEmployees();
        Employee getEmployeeByUsername(String username);
        int updateEmployee(Employee employee);
        int deleteEmployeeByUsername(String username);

    }
}
