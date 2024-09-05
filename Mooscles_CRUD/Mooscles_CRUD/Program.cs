using Employees_Management_System.BLL;
using Employees_Management_System.PL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Employees_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            PL_Employee pL_Employee = new PL_Employee();
            PL_Customer pL_Customer = new PL_Customer();
            PL_GymClass pL_GymClass = new PL_GymClass();
            pL_Employee.Run();
        }
    }
}