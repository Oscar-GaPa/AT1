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
        static GymClass_Manager gymClass_Manager = new GymClass_Manager(connectionString);
        // Create Run() method, then move from Main() method the CLI to here
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Gym Class");
                Console.WriteLine("2. Read Gym Class");
                Console.WriteLine("3. Update Gym Class");
                Console.WriteLine("4. Delete Gym Class");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                        gymClass_Manager.CreateGymClass();
                        break;
                    case "2":
                        gymClass_Manager.ReadGymClasses();
                        break;
                    case "3":
                        gymClass_Manager.UpdateGymClass();
                        break;
                    case "4":
                        gymClass_Manager.DeleteGymClass();
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
                    

