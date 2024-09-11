using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.DAL
{
    public class GymClassRepository
    {
        private readonly string connectionString;

        public GymClassRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // the following is CreateGymClass() method moved to here:
        public void CreateGymClass()
        {
            Console.WriteLine("Enter Gym Class details:");
            Console.Write("Class Name: ");
            string className = Console.ReadLine();
            Console.Write("Schedule: ");
            string schedule = Console.ReadLine();
            Console.Write("Class Instructor: ");
            string classInstructor = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO GymClasses (ClassName, Schedule, ClassInstructor) VALUES (@ClassName, @Schedule, @ClassInstructor)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ClassName", className);
                    command.Parameters.AddWithValue("@Schedule", schedule);
                    command.Parameters.AddWithValue("@ClassInstructor", classInstructor);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Gym Class created successfully.");
            }
        }


        public void ReadGymClasses()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT ClassId, ClassName, Schedule, ClassInstructor FROM GymClasses";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Gym Classes:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ClassId: {reader.GetInt32(0)}, ClassName: {reader.GetString(1)}, Schedule: {reader.GetString(2)}, ClassInstructor: {reader.GetString(3)}");
                        }
                    }
                }
            }
        }

        public void UpdateGymClass()
        {
            Console.Write("Enter the Id of the class to update: ");
            int classId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new class details:");
            Console.Write("Class Name: ");
            string className = Console.ReadLine();
            Console.Write("Schedule: ");
            string schedule = Console.ReadLine();
            Console.Write("Instructor: ");
            string classInstructor = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE GymClasses SET className = @ClassName, schedule = @Schedule, classInstructor = @ClassInstructor WHERE classId = @ClassId";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ClassId", classId);
                    command.Parameters.AddWithValue("@ClassName", className);
                    command.Parameters.AddWithValue("@Schedule", schedule);
                    command.Parameters.AddWithValue("@ClassInstructor", classInstructor);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Employee updated successfully.");
                    else
                        Console.WriteLine("Employee not found.");
                }
            }
        }

        public void DeleteGymClass()
        {
            Console.Write("Enter the Id of the gym class to delete: ");
            int classId = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM GymClasses WHERE classId = @ClassId";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@ClassId", classId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Gym Class deleted successfully.");
                    else
                        Console.WriteLine("Gym Class not found.");
                }
            }
        }

    }
}
