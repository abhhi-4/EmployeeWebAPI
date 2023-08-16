using System.ComponentModel;

namespace EmployeeFront.Models
{
    public class EmployeeVM
    {
    
        public int EmpID { get; set; }

        [DisplayName("Employee First Name")]
        public String? FirstName { get; set; }

        [DisplayName("Employee First Name")]
        public String? LastName { get; set; }

        public decimal? Salary { get; set; }
    }
}
