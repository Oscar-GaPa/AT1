using Employees_Management_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Manager.BLL
{
    internal class Customer_Manager
    {
        public class Customer_Manager
        {
            private readonly CustomerRepository CustomerRepository;

            public Customer_Manager(string connectionString)
            {
                customerRepository = new CustomerRepository(connectionString);
            }

            public void CreateCustomer()
            {
                customerRepository.CreateCustomer();

            }

            public void ReadCustomer()
            {
                customerRepository.ReadCustomer();

            }

            public void UpdateCustomer()
            {
                customerRepository.UpdateCustomer();

            }

            public void DeleteCustomer()
            {
                customerRepository.DeleteCustomer();

            }
        }
    }
}
