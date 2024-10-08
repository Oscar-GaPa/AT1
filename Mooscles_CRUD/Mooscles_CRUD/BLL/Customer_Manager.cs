﻿using Mooscles_Management_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.BLL
{
    public class Customer_Manager
    {
            private readonly Customer_Repository customerRepository;

            public Customer_Manager(string connectionString)
            {
                customerRepository = new Customer_Repository(connectionString);
            }

            public void CreateCustomer()
            {
                customerRepository.CreateCustomer();

            }

            public void ReadCustomers()
            {
                customerRepository.ReadCustomers();

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

