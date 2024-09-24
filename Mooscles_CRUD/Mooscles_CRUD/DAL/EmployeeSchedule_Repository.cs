using Mooscles_Management_System.Models;
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

        public void CreateEmployeeSchedule()
        {
            try
            {
                // Employee ID validation and existence check
                Console.Write("Enter employee ID: ");
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
                                    break; // Employee ID exists, proceed with scheduling
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

                // Day of the week validation
                string[] validDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                string dayOfWeek = "";
                bool isDayValid = false;

                while (!isDayValid)
                {
                    Console.Write("Day of the week (Monday, Tuesday, etc.): ");
                    dayOfWeek = Console.ReadLine();

                    if (Array.Exists(validDays, day => day.Equals(dayOfWeek, StringComparison.OrdinalIgnoreCase)))
                    {
                        isDayValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid day. Please enter a valid day of the week (e.g., Monday).");
                    }
                }

                // Shift type validation
                string[] validShifts = { "Full-time", "Part-time Morning", "Part-time Afternoon", "Day Off" };
                string shiftType = "";
                bool isShiftValid = false;

                while (!isShiftValid)
                {
                    Console.Write("Shift type (Full-time, Part-time Morning, Part-time Afternoon, Day Off): ");
                    shiftType = Console.ReadLine();

                    if (Array.Exists(validShifts, shift => shift.Equals(shiftType, StringComparison.OrdinalIgnoreCase)))
                    {
                        isShiftValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid shift type. Please enter either 'Full-time', 'Part-time Morning', 'Part-time Afternoon', or 'Day Off'.");
                    }
                }


                // Insert the schedule into the database (the Schedule_ID is automatically generated)
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO EmployeeSchedule (Employee_ID, DayOfWeek, ShiftType) VALUES (@Employee_ID, @DayOfWeek, @ShiftType)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Employee_ID", employee_id);
                        command.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                        command.Parameters.AddWithValue("@ShiftType", shiftType);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Employee Schedule created successfully.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadEmployeeSchedules()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Schedule_ID, Employee_ID, DayOfWeek, ShiftType FROM EmployeeSchedule";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Employee Schedules:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Schedule_ID: {reader.GetInt32(0)}, Employee_ID: {reader.GetInt32(1)}, DayOfWeek: {reader.GetString(2)}, ShiftType: {reader.GetString(3)}");
                        }
                    }
                }
            }
        }

        public void UpdateEmployeeSchedule()
        {
            Console.WriteLine("Enter Schedule ID to update schedule:");

            // Schedule ID validation and existence check
            int schedule_id;
            bool idExists = false;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out schedule_id))
                {
                    // Check if the schedule ID exists in the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string checkQuery = "SELECT COUNT(1) FROM EmployeeSchedule WHERE Schedule_ID = @Schedule_ID";
                        using (SqlCommand command = new SqlCommand(checkQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Schedule_ID", schedule_id);
                            int count = (int)command.ExecuteScalar();
                            if (count > 0)
                            {
                                idExists = true;
                                break; // Schedule ID exists, proceed with scheduling
                            }
                            else
                            {
                                Console.WriteLine("Schedule with this ID doesn't exist. Please enter a valid ID.");
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

            // Day of the week validation
            string[] validDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string dayOfWeek = "";
            bool isDayValid = false;

            while (!isDayValid)
            {
                Console.Write("Day of the week (Monday, Tuesday, etc.): ");
                dayOfWeek = Console.ReadLine();

                if (Array.Exists(validDays, day => day.Equals(dayOfWeek, StringComparison.OrdinalIgnoreCase)))
                {
                    isDayValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid day. Please enter a valid day of the week (e.g., Monday).");
                }
            }

            // Shift type validation
            string[] validShifts = { "Full-time", "Part-time Morning", "Part-time Afternoon", "Day Off" };
            string shiftType = "";
            bool isShiftValid = false;

            while (!isShiftValid)
            {
                Console.Write("Shift type (Full-time, Part-time Morning, Part-time Afternoon, Day Off): ");
                shiftType = Console.ReadLine();

                if (Array.Exists(validShifts, shift => shift.Equals(shiftType, StringComparison.OrdinalIgnoreCase)))
                {
                    isShiftValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid shift type. Please enter either 'Full-time', 'Part-time Morning', 'Part-time Afternoon', or 'Day Off'.");
                }
            }
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "UPDATE EmployeeSchedule SET DayOfWeek = @DayOfWeek, ShiftType = @ShiftType WHERE Schedule_ID = @Schedule_ID";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Schedule_ID", schedule_id);
                    command.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                    command.Parameters.AddWithValue("@ShiftType", shiftType);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Employee Schedule updated successfully.");
            }
        }

        public void DeleteEmployeeSchedule()
        {
            Console.WriteLine("Enter ID of the schedule to be deleted:");

            // Schedule ID validation and existence check
            int schedule_id;
            bool idExists = false;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out schedule_id))
                {
                    // Check if the schedule ID exists in the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string checkQuery = "SELECT COUNT(1) FROM EmployeeSchedule WHERE Schedule_ID = @Schedule_ID";
                        using (SqlCommand command = new SqlCommand(checkQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Schedule_ID", schedule_id);
                            int count = (int)command.ExecuteScalar();
                            if (count > 0)
                            {
                                idExists = true;
                                break; // Schedule ID exists, proceed with scheduling
                            }
                            else
                            {
                                Console.WriteLine("Schedule with this ID doesn't exist. Please enter a valid ID.");
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
        
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM EmployeeSchedule WHERE Schedule_ID = @Schedule_ID";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Schedule_ID", schedule_id);
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
