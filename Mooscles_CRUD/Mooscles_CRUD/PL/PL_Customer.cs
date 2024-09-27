using Mooscles_Management_System.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.PL
{
    internal class PL_Customer
    {
        static string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=""MyDB_new "";Integrated Security=True;";
        static Customer_Manager customerManager = new Customer_Manager(connectionString);
        
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create Customer");
                Console.WriteLine("2. Read Customers");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                        customerManager.CreateCustomer();
                        break;
                    case "2":
                        customerManager.ReadCustomers();
                        break;
                    case "3":
                        customerManager.UpdateCustomer();
                        break;
                    case "4":
                        customerManager.DeleteCustomer();
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
