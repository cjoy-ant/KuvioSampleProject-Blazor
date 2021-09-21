using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Data
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public string Customer { get; set; }
        public DateTime Deadline { get; set; }

        public bool Complete { get; set; }
        public DateTime DateModified { get; set; }
    }
}
