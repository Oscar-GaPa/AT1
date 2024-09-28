using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.Models
{
    // Employee Model with attributes from database
    public class Employee
    {
        public int Employee_ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int GymClass { get; set; }
    }
}
