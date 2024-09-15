using Mooscles_Management_System.BLL;
using Mooscles_Management_System.PL;
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


            Console.WriteLine("Please enter 1 for Employee, 2 for Customer, and 3 for Class:");

            bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Employee");
                    Console.WriteLine("2. Customer");
                    Console.WriteLine("3. Gym Class");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine();

                    switch (Console.ReadLine())
                    {
                        case "1":
                            pL_Employee.Run();
                            break;
                        case "2":
                            pL_Customer.Run();
                            break;
                        case "3":
                            pL_GymClass.Run();
                            break;
                        case "4":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }

        }



    }
}
