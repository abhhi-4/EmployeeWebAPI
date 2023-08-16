using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string PassWord { get; set; }
    }
}
