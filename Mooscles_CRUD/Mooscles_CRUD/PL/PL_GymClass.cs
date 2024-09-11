using Mooscles_Management_System.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.PL
{
    internal class PL_GymClass
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees_DB;Integrated Security=True;";
        static Gym_ClassManager gym_ClassManager = new Gym_ClassManager(connectionString);
        // Create Run() method, then move from Main() method the CLI to here
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Gym_Class");
                Console.WriteLine("2. Read Gym_Class");
                Console.WriteLine("3. Update Gym_Class");
                Console.WriteLine("4. Delete Gym_Class");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                        gym_ClassManager.CreateGym_Class();
                        break;
                    case "2":
                        gym_ClassManager.ReadGym_Class();
                        break;
                    case "3":
                        gym_ClassManager.UpdateGym_Class();
                        break;
                    case "4":
                        gym_ClassManager.DeleteGym_Class();
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
}
