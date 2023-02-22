using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTwo.ViewModels
{
    public class SearchModel
    {
        [Key]
        public int EmployeePersonId { get; set; }
        
        
        public string? FirstName { get; set; }
       
        public string? LastName { get; set; }
        
        public DateTime DOB { get; set; }
        
        public string? Gender { get; set; }
       
        public int Salary { get; set; }

        
        public DateTime DOJ { get; set; }

        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }

        public string? skillConcat { get; set; }

        
       

        
        



    }
}
