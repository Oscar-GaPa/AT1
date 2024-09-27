using Mooslces_Management_System.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.PL
{
    internal class PL_Employee
    {
        static string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=""MyDB_new "";Integrated Security=True;";
        static Employee_Manager employee_Manager = new Employee_Manager(connectionString);
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
                        employee_Manager.CreateEmployee();
                        break;
                    case "2":
                        employee_Manager.ReadEmployees();
                        break;
                    case "3":
                        employee_Manager.UpdateEmployee();
                        break;
                    case "4":
                        employee_Manager.DeleteEmployee();
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
