using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mooscles_Management_System.DAL
{
    public class Employee_Repository
    {
        private readonly string connectionString;

        public Employee_Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // the following is CreateEmployee() method moved to here:
        public void CreateEmployee()
        {
            Console.WriteLine("Enter employee details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Position: ");
            string position = Console.ReadLine();
            Console.Write("Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());

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
                }

                Console.WriteLine("Employee created successfully.");
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
            Console.Write("Enter the Employee_ID of the employee to update: ");
            int employee_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new employee details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Position: ");
            string position = Console.ReadLine();
            Console.Write("Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE Employee SET Name = @Name, Position = @Position, Salary = @Salary WHERE Employee_ID = @Employee_ID";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Employee_ID", employee_id);
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

        public void DeleteEmployee()
        {
            Console.Write("Enter the Id of the employee to delete: ");
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
