using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubManagement.Models;
using HCM.Data;

namespace HCM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Managers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Managers.ToListAsync());
        }

        // GET: Admin/Managers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managers == null)
            {
                return NotFound();
            }

            return View(managers);
        }

        // GET: Admin/Managers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Managers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,UserName,Password,Email")] Managers managers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(managers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(managers);
        }

        // GET: Admin/Managers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers.FindAsync(id);
            if (managers == null)
            {
                return NotFound();
            }
            return View(managers);
        }

        // POST: Admin/Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,UserName,Password,Email")] Managers managers)
        {
            if (id != managers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(managers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagersExists(managers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(managers);
        }

        // GET: Admin/Managers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managers == null)
            {
                return NotFound();
            }

            return View(managers);
        }

        // POST: Admin/Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var managers = await _context.Managers.FindAsync(id);
            _context.Managers.Remove(managers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagersExists(int id)
        {
            return _context.Managers.Any(e => e.Id == id);
        }
    }
}
