using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Mooscles_Management_System.DAL
{
    public class Customer_Repository
    {
        private readonly string connectionString;

        public Customer_Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateCustomer()
        {
            try
            {
                Console.WriteLine("Enter customer details:");

                // Name validation
                string customer_name;
                do
                {
                    Console.Write("Name: ");
                    customer_name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(customer_name) || !Regex.IsMatch(customer_name, "^[a-zA-Z\\s\\-]+$"))
                    {
                        Console.WriteLine("Name can only contain alphabetical characters and cannot be empty.\nPlease enter a valid name.");
                    }
                } while (string.IsNullOrWhiteSpace(customer_name) || !Regex.IsMatch(customer_name, "^[a-zA-Z\\s\\-]+$"));

                // Address validation
                string address;
                do
                {
                    Console.Write("Address: ");
                    address = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(address) || !Regex.IsMatch(address, "^[a-zA-Z0-9\\s,\\-\\.]+$"))
                    {
                        Console.WriteLine("Address can contain alphanumeric characters, spaces, commas, periods, and hyphens, and cannot be empty.\nPlease enter a valid address.");
                    }
                } while (string.IsNullOrWhiteSpace(address) || !Regex.IsMatch(address, "^[a-zA-Z0-9\\s,\\-\\.]+$"));

                int phone_no;
                while (true)
                {
                    Console.Write("Phone number: ");
                    if (int.TryParse(Console.ReadLine(), out phone_no))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid phone number.");
                    }
                }

                // DOB validation
                string dob = "";
                DateTime dateOfBirth;
                bool isValid = false;

                while (!isValid)
                {
                    Console.Write("Date of Birth (dd/MM/yyyy): ");
                    dob = Console.ReadLine();

                    if (!DateTime.TryParseExact(dob, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateOfBirth))
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in dd/MM/yyyy format.");
                    }
                    else if (dateOfBirth > DateTime.Now)
                    {
                        Console.WriteLine("Date of birth cannot be in the future.");
                    }
                    else if (dateOfBirth < DateTime.Now.AddYears(-100))
                    {
                        Console.WriteLine("Date of birth cannot be more than 100 years ago.");
                    }
                    else
                    {
                        isValid = true; // All conditions are met, exit the loop
                    }
                }

                // Starting date validation
                string starting_date = DateTime.Now.ToString("dd/MM/yyyy");

                DateTime startingDate;
                bool isTrue = false;

                while (!isTrue)
                {
                    Console.Write("Starting date (dd/MM/yyyy): ");
                    starting_date = Console.ReadLine();

                    if (!DateTime.TryParseExact(starting_date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out startingDate))
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in dd/MM/yyyy format.");
                    }
                    else if (startingDate > DateTime.Now)
                    {
                        Console.WriteLine("Starting date cannot be in the future.");
                    }
                    else if (startingDate < DateTime.Now.AddYears(-3))
                    {
                        Console.WriteLine("Starting date cannot be more than three years ago.");
                    }
                    else
                    {
                        isTrue = true; // All conditions are met, exit the loop
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Customer (Customer_Name, Address, Phone_NO, DOB, Starting_Date) VALUES (@Customer_Name, @Address, @Phone_NO, @DOB, @Starting_Date)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Customer_Name", customer_name);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Phone_NO", phone_no);
                        command.Parameters.AddWithValue("@DOB", dob);
                        command.Parameters.AddWithValue("@Starting_Date", starting_date);

                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Customer created successfully.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadCustomers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Customer_ID, Customer_Name, Address, Phone_NO, DOB, Starting_Date FROM Customer";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Customer:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Customer_ID: {reader.GetInt32(0)}, Customer_Name: {reader.GetString(1)}, Address: {reader.GetString(2)}, Phone_NO: {reader.GetInt32(3)}, DOB: {reader.GetString(4)}, Starting_Date: {reader.GetString(5)}");
                        }
                    }
                }
            }
        }

        public void UpdateCustomer()
        {
            Console.Write("Enter the ID of the customer to update: ");

            // ID validation and existence check
            int customer_id;
            bool idExists = false;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out customer_id))
                {
                    // Check if the customer ID exists in the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string checkQuery = "SELECT COUNT(1) FROM Customer WHERE Customer_ID = @Customer_ID";
                        using (SqlCommand command = new SqlCommand(checkQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Customer_ID", customer_id);
                            int count = (int)command.ExecuteScalar();
                            if (count > 0)
                            {
                                idExists = true;
                                break; // Customer ID exists, proceed with updating
                            }
                            else
                            {
                                Console.WriteLine("Customer with this ID does not exist. Please enter a valid ID.");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                }
            }

            if (!idExists)
            {
                return; // If ID doesn't exist, exit the method
            }

            try
            {
                Console.WriteLine("Enter new customer details:");

                // Name validation
                string customer_name;
                do
                {
                    Console.Write("Name: ");
                    customer_name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(customer_name) || !Regex.IsMatch(customer_name, "^[a-zA-Z\\s\\-]+$"))
                    {
                        Console.WriteLine("Name can only contain alphabetical characters and cannot be empty.\nPlease enter a valid name.");
                    }
                } while (string.IsNullOrWhiteSpace(customer_name) || !Regex.IsMatch(customer_name, "^[a-zA-Z\\s\\-]+$"));

                // Address validation
                string address;
                do
                {
                    Console.Write("Address: ");
                    address = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(address) || !Regex.IsMatch(address, "^[a-zA-Z0-9\\s,\\-\\.]+$"))
                    {
                        Console.WriteLine("Address can contain alphanumeric characters, spaces, commas, periods, and hyphens, and cannot be empty.\nPlease enter a valid address.");
                    }
                } while (string.IsNullOrWhiteSpace(address) || !Regex.IsMatch(address, "^[a-zA-Z0-9\\s,\\-\\.]+$"));

                int phone_no;
                while (true)
                {
                    Console.Write("Phone number: ");
                    if (int.TryParse(Console.ReadLine(), out phone_no))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid phone number.");
                    }
                }

                // DOB validation
                string dob = "";
                DateTime dateOfBirth;
                bool isValid = false;

                while (!isValid)
                {
                    Console.Write("Date of Birth (dd/MM/yyyy): ");
                    dob = Console.ReadLine();

                    if (!DateTime.TryParseExact(dob, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateOfBirth))
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in dd/MM/yyyy format.");
                    }
                    else if (dateOfBirth > DateTime.Now)
                    {
                        Console.WriteLine("Date of birth cannot be in the future.");
                    }
                    else if (dateOfBirth < DateTime.Now.AddYears(-100))
                    {
                        Console.WriteLine("Date of birth cannot be more than 100 years ago.");
                    }
                    else
                    {
                        isValid = true; // All conditions are met, exit the loop
                    }
                }

                // Starting date validation
                string starting_date = DateTime.Now.ToString("dd/MM/yyyy");

                DateTime startingDate;
                bool isTrue = false;

                while (!isTrue)
                {
                    Console.Write("Starting date (dd/MM/yyyy): ");
                    starting_date = Console.ReadLine();

                    if (!DateTime.TryParseExact(starting_date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out startingDate))
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in dd/MM/yyyy format.");
                    }
                    else if (startingDate > DateTime.Now)
                    {
                        Console.WriteLine("Starting date cannot be in the future.");
                    }
                    else if (startingDate < DateTime.Now.AddYears(-3))
                    {
                        Console.WriteLine("Starting date cannot be more than three years ago.");
                    }
                    else
                    {
                        isTrue = true; // All conditions are met, exit the loop
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Customer SET Customer_Name = @Customer_Name, Address = @Address, Phone_NO = @Phone_NO, DOB = @DOB, Starting_Date = @Starting_Date WHERE Customer_ID = @Customer_ID";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Customer_ID", customer_id);
                        command.Parameters.AddWithValue("@Customer_Name", customer_name);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Phone_NO", phone_no);
                        command.Parameters.AddWithValue("@DOB", dob);
                        command.Parameters.AddWithValue("@Starting_Date", starting_date);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            Console.WriteLine("Customer updated successfully.");
                        else
                            Console.WriteLine("Customer not found.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void DeleteCustomer()
        {
            Console.Write("Enter the ID of the customer to delete: ");
            int customer_id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Customer WHERE Customer_ID = @Customer_ID";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Customer_ID", customer_id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Customer deleted successfully.");
                    else
                        Console.WriteLine("Customer not found.");
                }
            }
        }

    }
}
