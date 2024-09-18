using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.DAL
{
    public class GymClass_Repository
    {
        private readonly string connectionString;

        public GymClass_Repository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // the following is CreateGymClass() method moved to here:
        public void CreateGymClass()
        {
            Console.WriteLine("Enter Gym Class details:");
            Console.Write("Class Name: ");
            string gymClass_Name = Console.ReadLine();
            Console.Write("Teacher: ");
            int gymClass_Teacher = Convert.ToInt32(Console.ReadLine());
            Console.Write("Member: ");
            int gymClass_Member = Convert.ToInt32(Console.ReadLine());
            Console.Write("Date: ");
            string gymClass_Date = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO GymClass (GymClass_Name, GymClass_Teacher, GymClass_Member, GymClass_Date) VALUES (@GymClass_Name, @GymClass_Teacher, @GymClass_Member, @GymClass_Date)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@GymClass_Name", gymClass_Name);
                    command.Parameters.AddWithValue("@GymClass_Teacher", gymClass_Teacher);
                    command.Parameters.AddWithValue("@GymClass_Member", gymClass_Member);
                    command.Parameters.AddWithValue("@GymClass_Date", gymClass_Date);
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

                string selectQuery = "SELECT GymClass_ID, GymClass_Name, GymClass_Teacher, GymClass_Member, GymClass_Date FROM GymClass";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Gym Classes:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"GymClass_ID: {reader.GetInt32(0)}, GymClass_Name: {reader.GetString(1)}, GymClass_Teacher: {reader.GetInt32(2)}, GymClass_Member: {reader.GetInt32(3)}, GymClass_Date: {reader.GetString(4)}");
                        }
                    }
                }
            }
        }

        public void UpdateGymClass()
        {
            Console.Write("Enter the Id of the class to update: ");
            int gymClass_ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new class details:");
            Console.Write("Class Name: ");
            string gymClass_Name = Console.ReadLine();
            Console.Write("Class Teacher: ");
            int gymClass_Teacher = Convert.ToInt32(Console.ReadLine());
            Console.Write("Class Member: ");
            int gymClass_Member = Convert.ToInt32(Console.ReadLine());
            Console.Write("Class Date: ");
            string gymClass_Date = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE GymClass SET GymClass_Name = @GymClass_Name, GymClass_Teacher = @GymClass_Teacher, GymClass_Member = @GymClass_Member, GymClass_Date = @GymClass_Date WHERE GymClass_ID = @GymClass_ID";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@GymClass_ID", gymClass_ID);
                    command.Parameters.AddWithValue("@GymClass_Name", gymClass_Name);
                    command.Parameters.AddWithValue("@GymClass_Teacher", gymClass_Teacher);
                    command.Parameters.AddWithValue("@GymClass_Member", gymClass_Member);
                    command.Parameters.AddWithValue("@GymClass_Date", gymClass_Date);
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
            Console.Write("Enter the Gym Class ID of the gym class to delete: ");
            int gymClass_ID = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM GymClass WHERE gymClass_ID = @GymClass_ID";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@GymClass_ID", gymClass_ID);
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
