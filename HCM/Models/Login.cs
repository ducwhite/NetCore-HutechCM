using ClubManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCM.Models
{
    public class Login
    {
        public Managers managers { get; set; }
        public Members members { get; set; }
    }
}
