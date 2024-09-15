using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mooscles_Management_System.DAL
{
    public class Customer_Repository
    {
        private readonly string connectionString;

        public Customer_Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // the following is CreateCustomer() method moved to here:
        public void CreateCustomer()
        {
            Console.WriteLine("Enter customer details:");
            Console.Write("Customer name: ");
            string customer_name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Phone number: ");
            int phone_no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Date of birth: ");
            string dob = Console.ReadLine();
            Console.Write("Starting date: ");
            string starting_date = Console.ReadLine();
            Console.Write("Ending date: ");
            string ending_date = Console.ReadLine();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Customer (Customer_Name, Address, Phone_NO, DOB, Starting_Date, Ending_Date) VALUES (@Customer_Name, @Address, @Phone_NO, @DOB, @Starting_Date, @Ending_Date)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Customer_Name", customer_name);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Phone_NO", phone_no);
                    command.Parameters.AddWithValue("@DOB", dob);
                    command.Parameters.AddWithValue("@Starting_Date", starting_date);
                    command.Parameters.AddWithValue("@Ending_Date", ending_date);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Customer created successfully.");
            }
        }


        public void ReadCustomers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Id, Customer_Name, Address, Phone_NO, DOB, Starting_Date, Ending_Date";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Customer:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader.GetInt32(0)}, Customer_Name: {reader.GetString(1)}, Address: {reader.GetString(2)}, Phone_NO: {reader.GetString(3)}, DOB: {reader.GetString(4)}, Starting_Date: {reader.GetString(5)}, Ending_Date: {reader.GetString(6)}");
                        }
                    }
                }
            }
        }

        public void UpdateCustomer()
        {
            Console.Write("Enter the ID of the customer to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new customer details:");
            Console.Write("Customer name: ");
            string customer_name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Phone number: ");
            int phone_no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Date of birth: ");
            string dob = Console.ReadLine();
            Console.Write("Starting date: ");
            string starting_date = Console.ReadLine();
            Console.Write("Ending date: ");
            string ending_date = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE Customer SET Customer_Name = @Customer_Name, Address = @Address, Phone_NO = @Phone_NO, DOB = @DOB, Starting_Date = @Starting_Date, Ending_Date = @Ending_Date WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Customer_Name", customer_name);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Phone_NO", phone_no);
                    command.Parameters.AddWithValue("@DOB", dob);
                    command.Parameters.AddWithValue("@Starting_Date", starting_date);
                    command.Parameters.AddWithValue("@Ending_Date", ending_date);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Customer updated successfully.");
                    else
                        Console.WriteLine("Customer not found.");
                }
            }
        }

        public void DeleteCustomer()
        {
            Console.Write("Enter the ID of the customer to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Customer WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
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
