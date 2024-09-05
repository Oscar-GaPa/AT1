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
            pL_Employee.Run();
        }
    }
}