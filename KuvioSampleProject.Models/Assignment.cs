using System;
using System.Collections.Generic;
using System.Text;

namespace KuvioSampleProject.Models
{
    class Assignment
    {
        public Guid Id { get; set; }
        public Guid Employee { get; set; }
        public Guid Project { get; set; }
        public DateTime DateModified { get; set; }
    }
}
