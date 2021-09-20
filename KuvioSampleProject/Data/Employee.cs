﻿using System;
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

        public string Birthday { get; set; }

        public string Age { get; set; }

        public string DateModified { get; set; }
    }
}
