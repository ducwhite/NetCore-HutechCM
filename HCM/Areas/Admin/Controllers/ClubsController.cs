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
    public class ClubsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Clubs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clubs.Include(c => c.Locations).Include(c => c.Managers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Clubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubs = await _context.Clubs
                .Include(c => c.Locations)
                .Include(c => c.Managers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubs == null)
            {
                return NotFound();
            }

            return View(clubs);
        }

        // GET: Admin/Clubs/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Email");
            return View();
        }

        // POST: Admin/Clubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Username,Password,CreateAt,Time,Image,Description,Require,ClubDetails,LocationId,ManagerId")] Clubs clubs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", clubs.LocationId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Email", clubs.ManagerId);
            return View(clubs);
        }

        // GET: Admin/Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubs = await _context.Clubs.FindAsync(id);
            if (clubs == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", clubs.LocationId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Email", clubs.ManagerId);
            return View(clubs);
        }

        // POST: Admin/Clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Username,Password,CreateAt,Time,Image,Description,Require,ClubDetails,LocationId,ManagerId")] Clubs clubs)
        {
            if (id != clubs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clubs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubsExists(clubs.Id))
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", clubs.LocationId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Email", clubs.ManagerId);
            return View(clubs);
        }

        // GET: Admin/Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubs = await _context.Clubs
                .Include(c => c.Locations)
                .Include(c => c.Managers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubs == null)
            {
                return NotFound();
            }

            return View(clubs);
        }

        // POST: Admin/Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clubs = await _context.Clubs.FindAsync(id);
            _context.Clubs.Remove(clubs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubsExists(int id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}
