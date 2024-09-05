using Employees_Management_System.DAL;
using Employees_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_Management_System.BLL
{
    public class EmployeeManager
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeManager(string connectionString)
        {
            employeeRepository = new EmployeeRepository(connectionString);
        }

        public void CreateEmployee()
        {
            employeeRepository.CreateEmployee();
            
        }

        public void ReadEmployees()
        {
            employeeRepository.ReadEmployees();

        }

        public void UpdateEmployee()
        {
            employeeRepository.UpdateEmployee();

        }

        public void DeleteEmployee()
        {
            employeeRepository.DeleteEmployee();

        }
    }
}
