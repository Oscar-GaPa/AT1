using Employees_Management_System.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_GymClass.PL
{
    internal class PL_GymClass
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees_DB;Integrated Security=True;";
        static PL_GymClassManager employeeManager = new PL_GymClassManager(connectionString);
        // Create Run() method, then move from Main() method the CLI to here
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create PL_GymClass");
                Console.WriteLine("2. Read PL_GymClass");
                Console.WriteLine("3. Update PL_GymClass");
                Console.WriteLine("4. Delete PL_GymClass");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                        employeeManager.CreatePL_GymClass();
                        break;
                    case "2":
                        employeeManager.ReadPL_GymClass();
                        break;
                    case "3":
                        employeeManager.UpdatePL_GymClass();
                    case "4":
                        employeeManager.DeletePL_GymClass();
                        break;
                    case "5":
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

