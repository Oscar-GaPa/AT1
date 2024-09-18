using Mooscles_Management_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.BLL
{
    public class GymClass_Manager
    {
        private readonly GymClass_Repository gymClassRepository;

        public GymClass_Manager(string connectionString)
        {
            gymClassRepository = new GymClass_Repository(connectionString);
        }

        public void CreateGymClass()
        {
            gymClassRepository.CreateGymClass();

        }

        public void ReadGymClasses()
        {
            gymClassRepository.ReadGymClasses();

        }

        public void UpdateGymClass()
        {
            gymClassRepository.UpdateGymClass();

        }

        public void DeleteGymClass()
        {
            gymClassRepository.DeleteGymClass();

        }
    }
}
