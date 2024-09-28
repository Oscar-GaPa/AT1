using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooscles_Management_System.Models
{
    // Customer Model with attributes from database
    public class Customer
    {
        public int Customer_ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone_NO { get; set; }
        public string DOB { get; set; }   
        public string Starting_Date { get; set; }
       
    }
}
