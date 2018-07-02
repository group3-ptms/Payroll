using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Entities
{
    public class Timesheet_Details
    {
        public int Employee_Id { get; set; }
        public char Timesheet_Id { get; set; }
        public int FirstMonth_Hours { get; set; }
        public int SecondMonth_Hours { get; set; }
        public int ThirdMonth_Hours { get; set; }
    }
}
