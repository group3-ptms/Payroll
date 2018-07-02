using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Exception
{
    public class PayrollException:ApplicationException
    {
        public PayrollException():base()
        { }

        public PayrollException(string exMessage):base(exMessage)
        { }

        public PayrollException(string exMessage, System.Exception innerException):base(exMessage,innerException)
        { }
    }
}
