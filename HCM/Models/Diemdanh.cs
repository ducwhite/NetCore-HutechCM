using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagement.Models
{
    public class Diemdanh
    {
        public int Id { get; set; }
        [Display(Name="Thành viên")]
        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Members Members { get; set; }
        [Display(Name = "Lịch")]
        public int SchduleId { get; set; }
        [ForeignKey("SchduleId")]
        public Schedules Schedules { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }


    }
}
