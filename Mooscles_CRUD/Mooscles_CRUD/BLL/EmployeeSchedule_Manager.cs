using Mooscles_Management_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.BLL
{

    // Class to manage employee schedule-related operations
    public class EmployeeSchedule_Manager
    {
        private readonly EmployeeSchedule_Repository employeeScheduleRepository;

        public EmployeeSchedule_Manager(string connectionString)
        {
            employeeScheduleRepository = new    EmployeeSchedule_Repository(connectionString);
        }

        // CRUD methods for the EmployeeSchedule Class
        public void CreateEmployeeSchedule()
        {
            employeeScheduleRepository.CreateEmployeeSchedule();

        }

        public void ReadEmployeeSchedules()
        {
            employeeScheduleRepository.ReadEmployeeSchedules();

        }

        public void UpdateEmployeeSchedule()
        {
            employeeScheduleRepository.UpdateEmployeeSchedule();

        }

        public void DeleteEmployeeSchedule()
        {
            employeeScheduleRepository.DeleteEmployeeSchedule();

        }
    }
}
