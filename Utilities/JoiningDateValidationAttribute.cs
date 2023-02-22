using EmployeeTwo.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTwo.Utilities
{
    public class JoiningDateValidationAttribute :ValidationAttribute
    {
        private readonly int sal;

        public JoiningDateValidationAttribute(int sal)
        {
            this.sal = sal;
        }

        public override bool IsValid(Object  value)
        {   int salary=Convert.ToInt32(value);
            return salary>sal;
        }
    }
}
