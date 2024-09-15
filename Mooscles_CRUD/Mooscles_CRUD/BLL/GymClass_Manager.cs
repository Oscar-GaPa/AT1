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
        private readonly GymClass_Repository gymclassRepository;

        public GymClass_Manager(string connectionString)
        {
            gymclassRepository = new GymClass_Repository(connectionString);
        }

        public void CreateGymClass()
        {
            gymclassRepository.CreateGymClass();

        }

        public void ReadGymClasses()
        {
            gymclassRepository.ReadGymClasses();

        }

        public void UpdateGymClass()
        {
            gymclassRepository.UpdateGymClass();

        }

        public void DeleteGymClass()
        {
            gymclassRepository.DeleteGymClass();

        }
    }
}
