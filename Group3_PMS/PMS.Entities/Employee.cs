using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Entities
{
    /// <summary>
    /// Entities classs for Group3_Payroll.Employee_Master
    /// </summary>
    public class Employee
    {
        public int Employee_Id { get; set; }        
        public string Employee_Password { get; set; }
        public DateTime DOJ { get; set; }
        public string Employee_FirstName { get; set; }
        public string Employee_LastName { get; set; }
        public string Employee_Address { get; set; }
        public int Security_Id { get; set; }
    }
}
