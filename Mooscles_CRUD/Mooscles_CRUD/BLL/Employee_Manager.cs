using Mooscles_Management_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooslces_Management_System.BLL
{
    public class Employee_Manager
    {
        private readonly Employee_Repository employee_Repository;

        public Employee_Manager(string connectionString)
        {
            employee_Repository = new Employee_Repository(connectionString);
        }

        public void CreateEmployee()
        {
            employee_Repository.CreateEmployee();

        }

        public void ReadEmployees()
        {
            employee_Repository.ReadEmployees();

        }

        public void UpdateEmployee()
        {
            employee_Repository.UpdateEmployee();

        }

        public void DeleteEmployee()
        {
            employee_Repository.DeleteEmployee();

        }
    }
}
