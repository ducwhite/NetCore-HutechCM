using HCM.Data;
using HCM.Extensions;
using HCM.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCM.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public async Task<IActionResult> Index(string username, string password)
        {
            ViewBag.error = "";
            var at = _context.Managers.ToList();
            var data = _context.Managers.Where(p => p.UserName == username && p.Password == password).ToList();
            if (data.Count() > 0)
            {
                List<Login> manager = new List<Login>();
                manager.Add(new Login { managers = at.Find(p => p.UserName == username) });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "Login", manager);
                return RedirectToAction("Index", "Home");
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
            List<Login> manager = new List<Login>();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Login", manager);
            return RedirectToAction("Index");
        }



    }
}
