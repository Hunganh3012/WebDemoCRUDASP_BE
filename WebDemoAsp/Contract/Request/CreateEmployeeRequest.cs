using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemoAsp.Contract.Request
{
    public class CreateEmployeeRequest
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }

        public DateTime Doj { get; set; }
        public string Gender { get; set; }

        public int DesignationID { get; set; }
        public string Designation { get; set; }
    }
}
