using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Data
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime DateModified { get; set; }
    }
}
