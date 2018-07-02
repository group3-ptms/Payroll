using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Entities
{
    public class Payroll_Details
    {
        public int Employee_Id { get; set; }
        public int Employee_Basic { get; set; }
        public int Employee_HRA { get; set; }
        public int Employee_DA { get; set; }
        public int Employee_PF { get; set; }
        public int Employee_Net_Salary { get; set; }
    }
}
