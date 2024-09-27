using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooscles_Management_System.DAL;
using System;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class EmployeeCRUDtest
    {
        private string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=""MyDB_new"";Integrated Security=True;";
        private Employee_Repository employeeRepository;

        [TestInitialize]
        public void Setup()
        {
            employeeRepository = new Employee_Repository(connectionString);
        }

        [TestMethod]
        public void CreateEmployee_Succeeds()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("John Doe\nDeveloper\n50000"));

                // Act
                employeeRepository.CreateEmployee();

                // Assert
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Employee created successfully."));
            }
        }

        [TestMethod]
        public void ReadEmployees_Executes()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                employeeRepository.ReadEmployees();

                // Assert
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Employee_ID:") || output.Contains("No employees found.")); // Adjust based on your actual output
            }
        }

        [TestMethod]
        public void UpdateEmployee_Succeeds()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("1\nJane Doe\nManager\n60000")); // Assuming ID 1 exists

                // Act
                employeeRepository.UpdateEmployee();

                // Assert
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Employee updated successfully.") || output.Contains("Employee not found."));
            }
        }

        [TestMethod]
        public void DeleteEmployee_Succeeds()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("1")); // Assuming ID 1 exists

                // Act
                employeeRepository.DeleteEmployee();

                // Assert
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Employee deleted successfully.") || output.Contains("Employee not found."));
            }
        }
    }
}
