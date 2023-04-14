using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemoAsp.Exceptions
{
    public class EmployeeException :Exception
    {
        public EmployeeException()
        {
        }

        public EmployeeException(string message)
            : base(message)
        {
        }

        public EmployeeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
