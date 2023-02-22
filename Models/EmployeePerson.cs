using EmployeeTwo.Utilities;
using Microsoft.AspNetCore.Mvc;
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTwo.Models
{
    public class EmployeePerson
    {
       
        public int EmployeePersonId { get; set; }

        [Required]
       /* [Remote(action:"IsNameValid",controller: "Home")]*/
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string? Gender { get; set; }
        
        public virtual int? DepartmentId {get; set; }
        public virtual int? DesignationId { get; set; }
       
        public Department? Department { get; set; }
        
       
        public Designation? Designation { get; set; }
        [Required]
        public DateTime DOJ { get; set; }

        [JoiningDateValidation(sal:50000,ErrorMessage ="Salary must be greater than 50000")]
        public int Salary { get; set; }

        public IList<EmployeeSkill>? EmployeeSkills { get; set; } =null;

        //public IList<Skill> skls { get; set; } = null;

        internal object include(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
