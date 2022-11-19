using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagement.Models
{
    public class Members
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "MSSV")]
        public string StudentNumber { get; set; }
        [Required]
        [Display(Name = "Mật khẩu")]
        //[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Display(Name = "SĐT")]
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name="Trạng thái")]
        public bool IsAccecpt { get; set; }
        [Display(Name = "CLB")]
        public int ClubId { get; set; }
        [ForeignKey("ClubId")]
        [Display(Name = "CLB")]
        public Clubs Clubs { get; set; }
        [Required]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}
