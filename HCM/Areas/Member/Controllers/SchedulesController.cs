using HCM.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCM.Areas.Member.Controllers
{
    [Area("Member")]
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("event/Find")]
        public IActionResult FindAllEvents()
        {
            var events = _context.Schedules.Select(e => new
            {
                id = e.Id,
                title = e.Clubs.Name + " - " + e.Location,
                description = e.Description,
                start = e.StartDate,
                end = e.EndDate,
                club = e.Clubs.Name,

                
            }).ToList();

            return new JsonResult(events);
        }
    }
}
