using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagement.Models
{
    public class Managers
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Họ tên")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required]
        //[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
