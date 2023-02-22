using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTwo.Models
{
    public class Designation
    {
        public int DesignationId { get; set; }
        [Required]
        public string? DesignationName { get; set; }

        public ICollection<EmployeePerson>? EmployeePersons { get; set; }


    }
}
