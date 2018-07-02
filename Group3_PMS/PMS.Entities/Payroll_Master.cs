using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Entities
{
    public class Payroll_Master
    {
        public int Employee_Id { get; set; }
        public string Employee_Designation { get; set; }
        public string Employee_Grade { get; set; }
        public int TakeHome_Salary { get; set; }
    }
}
