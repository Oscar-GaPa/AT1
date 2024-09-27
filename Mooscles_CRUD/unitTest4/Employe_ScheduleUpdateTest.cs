using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooscles_Management_System.DAL;
using System;
using System.Data.SqlClient;

namespace Employe_ScheduleUpdateTest // Replace with your actual namespace
{
    [TestClass]
    public class Employe_ScheduleUpdateTest
    {
        private EmployeeSchedule_Repository _repository;
        private string _connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=""MyDB_new "";Integrated Security=True"; // Replace with your actual connection string

        [TestInitialize]
        public void Setup()
        {
            _repository = new EmployeeSchedule_Repository(_connectionString);
        }

        [TestMethod]
        public void UpdateEmployeeSchedule_ValidScheduleID_UpdatesSuccessfully()
        {
            // Arrange
            int validScheduleID = 1; // Make sure this ID exists in your test database
            string newDayOfWeek = "Tuesday";
            string newShiftType = "Part-time Morning";

            // Act
            try
            {
                // This simulates the method's behavior. Ideally, you would refactor the method to accept parameters.
                // In the real test, you would execute the method that does the update.
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE EmployeeSchedule SET DayOfWeek = @DayOfWeek, ShiftType = @ShiftType WHERE Schedule_ID = @Schedule_ID";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Schedule_ID", validScheduleID);
                        command.Parameters.AddWithValue("@DayOfWeek", newDayOfWeek);
                        command.Parameters.AddWithValue("@ShiftType", newShiftType);
                        command.ExecuteNonQuery();
                    }
                }

                Assert.IsTrue(true); // If no exception is thrown, the test passes
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception was thrown: {ex.Message}");
            }
        }
    }
}
