using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTwo.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        [Required]
        public string? SkillName { get; set; }

        public IList<EmployeeSkill>? EmployeeSkills { get; set; }

    }
}
