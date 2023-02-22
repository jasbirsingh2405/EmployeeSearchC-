using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTwo.ViewModels
{
    public class EmpModelyoo1
    {
        [Key]
        public int EmployeePersonId { get; set; }
        
        
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
        
        public string? DOB { get; set; }
        
        public string? Gender { get; set; }
        public string? DepartmentName { get; set; }
        public string? DesignationName { get; set; }

        public int Salary { get; set; }

        
        public string? DOJ { get; set; }

        public string? skillConcat { get; set; }

        [NotMapped] 
        public List<string>? Skills { get; set; }

        public int Index;

        
        



    }
}
