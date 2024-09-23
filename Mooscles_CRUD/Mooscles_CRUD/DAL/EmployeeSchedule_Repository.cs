using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.DAL
{
    public class EmployeeSchedule_Repository
    {
        private readonly string connectionString;

        public EmployeeSchedule_Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // the following is Create EmployeeSchedule() method moved to here:
        public void CreateEmployeeSchedule()
        {
            Console.WriteLine("Enter Employee Schedule:");
            Console.Write("Date and Employee_ID: ");
            int employee_schedule = Convert.ToInt32(Console.ReadLine());
            Console.Write("Employee_ID: ");
            int employee_id = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO EmployeeSchedule (Employee_Schedule, Employee_ID) VALUES (@Employee_Schedule, @Employee_ID)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Employee_Schedule", employee_schedule);
                    command.Parameters.AddWithValue("@Employee_ID", employee_id);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Employee Schedule created successfully.");
            }
        }


        public void ReadEmployeeSchedule()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Employee_Schedule, Employee_ID";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Employee Schedules:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Employee_Schedule: {reader.GetInt32(0)}, Employee_ID: {reader.GetInt32(1)}");
                        }
                    }
                }
            }
        }

        public void UpdateEmployeeSchedule()
        {
            Console.Write("Enter the date and Employee_ID: ");
            int employee_schedule = Convert.ToInt32(Console.ReadLine());
            Console.Write("Employee_ID: ");
            int employee_id = Convert.ToInt32(Console.ReadLine());
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE EmployeeSchedule SET Employee_Schedule = @Empolyee_Schedule, Employee_ID = @Employee_ID";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Employee_SChedule", employee_schedule);
                    command.Parameters.AddWithValue("@GymClass_Name", employee_id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Schedule updated successfully.");
                    else
                        Console.WriteLine("Schedule not found.");
                }
            }
        }

        public void DeleteEmployeeSchedule()
        {
            Console.Write("Enter the date and Employee_ID to delete: ");
            int employee_Schedule = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM EmployeeSchedule WHERE Employee_Schedule = @Employee_Schedule";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Employee_Schedule", employee_Schedule);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Schedule deleted successfully.");
                    else
                        Console.WriteLine("Schedule not found.");
                }
            }
        }

    }
}
