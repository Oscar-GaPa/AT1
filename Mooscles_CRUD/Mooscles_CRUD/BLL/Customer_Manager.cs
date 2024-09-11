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
        private readonly CustomerRepository CustomerRepository;

        public Customer_Manager(string connectionString)
        {
            CustomerRepository = new CustomerRepository(connectionString);
        }

        public void CreateCustomer()
        {
            CustomerRepository.CreateCustomer();

        }

        public void ReadCustomer()
        {
            CustomerRepository.ReadCustomer();

        }

        public void UpdateCustomer()
        {
            CustomerRepository.UpdateCustomer();

        }

        public void DeleteCustomer()
        {
            CustomerRepository.DeleteCustomer();

        }
    }
}
}
