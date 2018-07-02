using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Entities
{
    /// <summary>
    /// Entity class for the Group3_Payroll.Employee_Security
    /// </summary>
    public class Employee_Security
    {
        public int Security_Id { get; set; }
        public string Security_Question { get; set; }
        public string Security_Answer { get; set; }
    }
}
