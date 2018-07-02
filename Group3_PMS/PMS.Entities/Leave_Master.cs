using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Entities
{
    public class Leave_Master
    {
        public int Employee_Id { get; set; }
        public int Leaves_Available { get; set; }
        public int Leaves_Availed { get; set; }
        public int Leaves_Balance { get; set; }

    }
}
