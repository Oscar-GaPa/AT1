using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone_NO { get; set; }
        public string DOB { get; set; }   
        public decimal Starting_Date { get; set; }
        public decimal Ending_Date { get; set; }
    }
}
