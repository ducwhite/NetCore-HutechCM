using HCM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCM.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalClub = _context.Clubs.Count();
            ViewBag.TotalLocation = _context.Locations.Count();
            ViewBag.TotalMember = _context.Members.Count();
            ViewBag.TotalSchedule = _context.Schedules.Count();
            return View();
        }
    }
}
