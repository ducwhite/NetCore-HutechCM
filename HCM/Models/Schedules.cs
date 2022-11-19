using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagement.Models
{
    public class Schedules
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Bắt đầu")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Kết thúc")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Địa điểm")]
        public string Location { get; set; }
        [Display(Name = "CLB")]
        public int ClubId { get; set; }
        [ForeignKey("ClubId")]
        [Display(Name = "CLB")]
        public Clubs Clubs { get; set; }
    }
}
