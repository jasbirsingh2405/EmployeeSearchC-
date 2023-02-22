using EmployeeTwo.Models;

namespace EmployeeTwo.ViewModels
{
    public class EmpDepDesSki
    {
        public EmployeePerson? EmployeePerson { get; set; }
        public List<Department>? Department { get; set; }

       public string? DepartmentName { get; set; }

        public List<Designation>? Designation { get; set; }
        public int? DepartmentId { get; set; }
        public  int? DesignationId { get; set; }
        public List<Skill>? Skill { get; set; }
        public List<int>? skillId { get; set; }

        public List<EmpModelyoo1>? EmpModelyoo1 { get; set; }


    }
}
