using System;
using System.Collections.Generic;
using System.Text;

namespace KuvioSampleProject.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateModified { get; set; }
    }
}
