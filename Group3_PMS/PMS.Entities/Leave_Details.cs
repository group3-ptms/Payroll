using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Entities
{
    public class Leave_Details
    {
        public int Employee_Id { get; set; }
        public DateTime Leave_From { get; set; }
        public DateTime Leave_To { get; set; }
        public int No_Of_Days { get; set; }
        public DateTime Apply_Date { get; set; }
        public string Leave_Reason { get; set; }
        public string Leave_Description { get; set; }
        
    }
}
