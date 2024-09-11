using GymClass_Management_System.DAL;
using GymClass_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.BLL
{
    public class GymClassManager
    {
        private readonly GymClassRepository gymclassRepository;

        public GymClassManager(string connectionString)
        {
            gymclassRepository = new gymclassRepository(connectionString);
        }

        public void CreateGymClass()
        {
            gymclassRepository.CreateGymClass();

        }

        public void ReadGymClass()
        {
            gymclassRepository.ReadGymClass();

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
