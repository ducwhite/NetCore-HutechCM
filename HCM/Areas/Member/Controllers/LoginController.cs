using HCM.Data;
using HCM.Extensions;
using HCM.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCM.Areas.Member.Controllers
{
    [Area("Member")]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string StudentNumber, string password)
        {
            ViewBag.error = "";
            var at = _context.Members.ToList();
            var data = _context.Members.Where(p => p.StudentNumber == StudentNumber && p.Password == password).ToList();
            if (data.Count() > 0)
            {
                List<Login> member = new List<Login>();
                member.Add(new Login { members = at.Find(p => p.StudentNumber == StudentNumber) });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "Login", member);
                return RedirectToAction("Index", "Schedules");
            }

            else
            {
                ViewBag.error = "Đăng nhập thất bại";
                return View("Index");

            }
        }

        public IActionResult Logout()
        {

            SessionHelper.GetObjectFromJson<List<Login>>(HttpContext.Session, "Login").Clear();
            List<Login> member = new List<Login>();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Login", member);
            return RedirectToAction("Index");
        }
    }
}