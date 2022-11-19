using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagement.Models
{
    public class Clubs
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="CLB")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }
        //[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt { get; set; }
        [Required]
        [Display(Name = "Giờ sinh hoạt")]
        public string Time { get; set; }
        [Display(Name = "Ảnh")]
        public string Image { get; set; }
        [Display(Name = "Mô tả")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "Yêu cầu")]
        [Required]
        public string Require { get; set; }
        [Display(Name = "Chi tiết")]
        [Required]
        public string ClubDetails { get; set; }
        [Display(Name = "Địa điểm")]
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Locations Locations { get; set; }
        [Display(Name = "Người tạo")]
        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        [Display(Name = "Người tạo")]
        public Managers Managers { get; set; }
    }
}
