using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooscles_Management_System.DAL;
using System;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class CustomerCRUDtest
    {
        private string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=""MyDB_new"";Integrated Security=True;";
        private Customer_Repository customerRepository;

        [TestInitialize]
        public void Setup()
        {
            customerRepository = new Customer_Repository(connectionString);
        }

        [TestMethod]
        public void CreateCustomer_Succeeds()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("John Doe\n123 Main St\n1234567890\n01/01/1990\n01/01/2022"));

                // Act
                customerRepository.CreateCustomer();

                // Assert
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Customer created successfully."));
            }
        }

        [TestMethod]
        public void ReadCustomers_Executes()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                customerRepository.ReadCustomers();

                // Assert
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Customer_ID:") || output.Contains("No customers found.")); // Adjust based on your actual output
            }
        }

        [TestMethod]
        public void UpdateCustomer_Succeeds()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("1\nJane Doe\n456 Main St\n0987654321\n01/01/1992\n01/01/2023")); // Assuming ID 1 exists

                // Act
                customerRepository.UpdateCustomer();

                // Assert
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Customer updated successfully."));
            }
        }

        [TestMethod]
        public void DeleteCustomer_Succeeds()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("1")); // Assuming ID 1 exists

                // Act
                customerRepository.DeleteCustomer();

                // Assert
                var output = sw.ToString();
                Assert.IsTrue(output.Contains("Customer deleted successfully.") || output.Contains("Customer not found."));
            }
        }
    }
}
