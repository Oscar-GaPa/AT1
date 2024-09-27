using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooscles_Management_System.DAL;
using System;
using System.Data.SqlClient;

namespace UnitTest
{
    [TestClass]
    public class EmployeeScheduleRepositoryTests
    {
        private EmployeeSchedule_Repository _repository;
        private string _connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=""MyDB_new "";Integrated Security=True"; // Replace with your actual connection string

        [TestInitialize]
        public void Setup()
        {
            _repository = new EmployeeSchedule_Repository(_connectionString);
        }

        [TestMethod]
        public void ReadEmployeeSchedules_ExecutesSuccessfully()
        {
            // Act
            try
            {
                _repository.ReadEmployeeSchedules();
                Assert.IsTrue(true); // If no exception is thrown, the test passes
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception was thrown: {ex.Message}");
            }
        }
    }

}      