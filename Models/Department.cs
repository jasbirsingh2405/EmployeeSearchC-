using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTwo.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string? DepartmentName { get; set; }

        public ICollection<EmployeePerson>? EmployeePersons { get; set; }


    }
}
