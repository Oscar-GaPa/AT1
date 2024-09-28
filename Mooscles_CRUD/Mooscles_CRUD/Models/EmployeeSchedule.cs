using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.Models
{
    // EmployeeSchedule Model with attributes from database
    internal class EmployeeSchedule
    {
        public int Schedule_ID { get; set; }
           
        public int Employee_ID { get; set; } 
        
        public string DayOfWeek { get; set; } 
        
        public string ShiftType { get; set; }    
     
    }
}
