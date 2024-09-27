using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooscles_Management_System.DAL;
using System;
using System.IO;
using System.Data.SqlClient;

namespace YourNamespace.Tests 
{
    [TestClass]
    public class EmployeeScheduleRepositoryTests
    {
        private EmployeeSchedule_Repository _repository;
        private string _connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=""MyDB_new"";Integrated Security=True;"; // Replace with your actual connection string

        [TestInitialize]
        public void Setup()
        {
            _repository = new EmployeeSchedule_Repository(_connectionString);
        }

        [TestMethod]
        public void DeleteEmployeeSchedule_ValidScheduleID_DeletesSuccessfully()
        {
            // Arrange
            int validScheduleID;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Insert a record to delete
                string insertQuery = "INSERT INTO EmployeeSchedule (Employee_ID, DayOfWeek, ShiftType) VALUES (1, 'Monday', 'Full-time'); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    validScheduleID = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            // Act
            string input = validScheduleID.ToString() + Environment.NewLine;
            var inputStream = new StringReader(input);
            Console.SetIn(inputStream);

            _repository.DeleteEmployeeSchedule();

            // Assert
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(1) FROM EmployeeSchedule WHERE Schedule_ID = @Schedule_ID";
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@Schedule_ID", validScheduleID);
                    int count = (int)command.ExecuteScalar();
                    Assert.AreEqual(0, count, "Schedule was not deleted successfully.");
                }
            }
        }
    }
}

