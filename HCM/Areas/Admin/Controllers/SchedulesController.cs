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
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Schedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Schedules.Include(s => s.Clubs);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules
                .Include(s => s.Clubs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedules == null)
            {
                return NotFound();
            }

            return View(schedules);
        }

        // GET: Admin/Schedules/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Name");
            return View();
        }

        // POST: Admin/Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,StartDate,EndDate,Location,ClubId")] Schedules schedules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Name", schedules.ClubId);
            return View(schedules);
        }

        // GET: Admin/Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules.FindAsync(id);
            if (schedules == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Name", schedules.ClubId);
            return View(schedules);
        }

        // POST: Admin/Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,StartDate,EndDate,Location,ClubId")] Schedules schedules)
        {
            if (id != schedules.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchedulesExists(schedules.Id))
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
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Name", schedules.ClubId);
            return View(schedules);
        }

        // GET: Admin/Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedules = await _context.Schedules
                .Include(s => s.Clubs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedules == null)
            {
                return NotFound();
            }

            return View(schedules);
        }

        // POST: Admin/Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedules = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(schedules);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchedulesExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}
