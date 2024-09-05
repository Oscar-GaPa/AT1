using Employees_Management_System.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_Management_System.PL
{
    public class PL_Employee
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees_DB;Integrated Security=True;";
        static EmployeeManager employeeManager = new EmployeeManager(connectionString);
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
                        employeeManager.CreateEmployee();
                        break;
                    case "2":
                        employeeManager.ReadEmployees();
                        break;
                    case "3":
                        employeeManager.UpdateEmployee();
                        break;
                    case "4":
                        employeeManager.DeleteEmployee();
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
