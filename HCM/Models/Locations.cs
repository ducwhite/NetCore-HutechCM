using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubManagement.Models
{
    public class Locations
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Khu")]
        public string Name { get; set; }
    }
}
