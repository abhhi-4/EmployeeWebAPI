using System.ComponentModel.DataAnnotations;

namespace EmployeeFront.Models
{
    public class UsersVM
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string PassWord { get; set; }
    }
}
