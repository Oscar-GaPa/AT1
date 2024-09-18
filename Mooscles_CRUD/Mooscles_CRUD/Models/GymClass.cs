using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.Models
{
    internal class GymClass
    {
        public int GymClass_ID { get; set; }
        public string GymClass_Name { get; set; }   
        public int GymClass_Teacher {  get; set; }  
        public int GymClass_Member { get; set; }    
        public string GymClass_Date { get; set; }  
    }
}
