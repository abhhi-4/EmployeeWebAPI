using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
       
        public String? FirstName { get; set; }
        
        public String? LastName { get; set; }
       
        public decimal? Salary { get; set; }

    }
}
