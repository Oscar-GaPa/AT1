using Employees_Management_System.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_Management_System.PL
{
    internal class PL_GymClass
    {

        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees_DB;Integrated Security=True;";
        static PL_GymClass pl_GymClassManager = new PL_GymClassManager(connectionString);
        // Create Run() method, then move from Main() method the CLI to here
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Read Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                        pl_GymClassManager.CreatePL_GymClass();
                        break;
                    case "2":
                        pl_GymClassManager.ReadPL_GymClass();
                        break;
                    case "3":
                        pl_GymClassManager.UpdatePL_GymClass();
                        break;
                    case "4":
                        pl_GymClassManager.DeletePL_GymClass();
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
