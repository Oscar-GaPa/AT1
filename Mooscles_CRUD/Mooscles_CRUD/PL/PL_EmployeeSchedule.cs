using Mooscles_Management_System.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.PL
{
    internal class PL_EmployeeSchedule
    {
        static string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=""MyDB_new "";Integrated Security=True;";
        static EmployeeSchedule_Manager employeeSchedule_Manager = new EmployeeSchedule_Manager(connectionString);
        // Create Run() method, then move from Main() method the CLI to here
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Employee Schedule");
                Console.WriteLine("2. Read Employee Schedule");
                Console.WriteLine("3. Update Employee Schedule");
                Console.WriteLine("4. Delete Employee Schedule");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                        employeeSchedule_Manager.CreateEmployeeSchedule();
                        break;
                    case "2":
                        employeeSchedule_Manager.ReadEmployeeSchedules();
                        break;
                    case "3":
                        employeeSchedule_Manager.UpdateEmployeeSchedule();
                        break;
                    case "4":
                        employeeSchedule_Manager.DeleteEmployeeSchedule();
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
                    

