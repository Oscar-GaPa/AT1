using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.ComponentModel.Design;

namespace Mooscles_Management_System.DAL
{
    public class Employee_Repository
    {
        private readonly string connectionString;

        public Employee_Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateEmployee()
        {
            try
            {
                Console.WriteLine("Enter employee details:");

                // Name validation
                string name;
                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, "^[a-zA-Z\\s\\-]+$"))
                    {
                        Console.WriteLine("Name can only contain alphabetical characters and cannot be empty.\nPlease enter a valid name.");
                    }
                } while (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, "^[a-zA-Z\\s\\-]+$"));

                // Position validation
                string position;
                do
                {
                    Console.Write("Position: ");
                    position = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(position) || !Regex.IsMatch(position, "^[a-zA-Z\\s\\-]+$"))
                    {
                        Console.WriteLine("Position can only contain alphabetical characters and cannot be empty.\nPlease enter a valid position.");
                    }
                } while (string.IsNullOrWhiteSpace(position) || !Regex.IsMatch(position, "^[a-zA-Z\\s\\-]+$"));

                // Salary validation
                int salary;
                while (true)
                {
                    Console.Write("Salary: ");
                    if (int.TryParse(Console.ReadLine(), out salary))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid salary.");
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Employee (Name, Position, Salary) VALUES (@Name, @Position, @Salary)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Position", position);
                        command.Parameters.AddWithValue("@Salary", salary);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Employee created successfully.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Employee_ID, Name, Position, Salary FROM Employee";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Employees:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Employee_ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, Position: {reader.GetString(2)}, Salary: {reader.GetInt32(3)}");
                        }
                    }
                }
            }
        }

        public void UpdateEmployee()
        {
            Console.Write("Enter the ID of the employee to update: ");

            // ID validation and existence check
            int employee_id;
            bool idExists = false;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out employee_id))
                {
                    // Check if the employee ID exists in the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string checkQuery = "SELECT COUNT(1) FROM Employee WHERE Employee_ID = @Employee_ID";
                        using (SqlCommand command = new SqlCommand(checkQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Employee_ID", employee_id);
                            int count = (int)command.ExecuteScalar();
                            if (count > 0)
                            {
                                idExists = true;
                                break; // Employee ID exists, proceed with updating
                            }
                            else
                            {
                                Console.WriteLine("Employee with this ID doesn't exist. Please enter a valid ID.");
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
                Console.WriteLine("Enter new employee details:");
                // Name validation
                string name;
                do
                {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, "^[a-zA-Z\\s\\-]+$"))
                    {
                        Console.WriteLine("Name can only contain alphabetical characters and cannot be emply.\nPlease enter a valid name.");
                    }
                } while (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, "^[a-zA-Z\\s\\-]+$"));

                // Position validation
                string position;
                do
                {
                    Console.Write("Position: ");
                    position = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(position) || !Regex.IsMatch(position, "^[a-zA-Z\\s\\-]+$"))
                    {
                        Console.WriteLine("Position can only contain alphabetical characters and cannot be emply.\nPlease enter a valid position.");
                    }
                } while (string.IsNullOrWhiteSpace(position) || !Regex.IsMatch(position, "^[a-zA-Z\\s\\-]+$"));

                // Salary validation
                int salary;
                while (true)
                {
                    Console.Write("Salary: ");
                    if (int.TryParse(Console.ReadLine(), out salary))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid salary.");
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Employee SET Name = @Name, Position = @Position, Salary = @Salary WHERE Employee_ID = @Employee_ID";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Employee_ID", employee_id);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Position", position);
                        command.Parameters.AddWithValue("@Salary", salary);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            Console.WriteLine("Employee updated successfully.");
                                else
                            Console.WriteLine("Employee not found.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter the ID of the employee to delete: ");
            int employee_id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Employee WHERE Employee_ID = @Employee_ID";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Employee_ID", employee_id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Employee deleted successfully.");
                    else
                        Console.WriteLine("Employee not found.");
                }
            }
        }

    }
}
