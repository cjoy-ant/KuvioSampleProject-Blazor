using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(1)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(1)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Select a Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        public DateTime DateModified { get; set; }
    }
}
