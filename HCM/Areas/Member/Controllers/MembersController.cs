using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubManagement.Models;
using HCM.Data;

namespace HCM.Areas.Member.Controllers
{
    [Area("Member")]
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Member/Members
        public async Task<IActionResult> Index(int id)
        {
            var id2 = id > 0 ? id : -1;
            var club = _context.Clubs.ToList();
            ViewBag.ListByClub = club;
            var applicationDbContext = _context.Members.Include(m => m.Clubs);

            if (id2 != -1)
            {
                return View(await applicationDbContext.Where(m => m.ClubId == id2).ToListAsync());
            }


            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Member/Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .Include(m => m.Clubs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // GET: Member/Members/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Name");
            return View();
        }

        // POST: Member/Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,StudentNumber,Password,Email,PhoneNumber,IsAccecpt,ClubId,Description")] Members members)
        {
            if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Name", members.ClubId);
            return View(members);
        }

        // GET: Member/Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Name", members.ClubId);
            return View(members);
        }

        // POST: Member/Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,StudentNumber,Password,Email,PhoneNumber,IsAccecpt,ClubId,Description")] Members members)
        {
            if (id != members.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.Id))
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
            ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Name", members.ClubId);
            return View(members);
        }

        // GET: Member/Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .Include(m => m.Clubs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: Member/Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var members = await _context.Members.FindAsync(id);
            _context.Members.Remove(members);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
