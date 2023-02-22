using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTwo.Models
{
   public  class EmployeeSkill
    {
        public int EmployeePersonId { get; set; }
        public EmployeePerson? EmployeePerson { get; set; }

        public int SkillId { get; set; }
        public Skill? Skill { get; set; }

    }
}
