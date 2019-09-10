﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pitch_perfect.Data;
using pitch_perfect.Models;

namespace pitch_perfect.Controllers
{
    public class PitchesController : Controller
    {
        //dependency injection for getting current user

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public PitchesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<User> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        //private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Pitches
        public async Task<IActionResult> Index()
        {
            //get curr user
            var user = await GetUserAsync();
            var applicationDbContext = _context.Pitch
                .Where(p => p.UserId == user.Id)
                .Include(p => p.UserId)
                .Include(p => p.Title);
            return View(await applicationDbContext.ToListAsync());
        }




        // GET: Pitches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitch = await _context.Pitch
                .FirstOrDefaultAsync(m => m.PitchId == id);
            if (pitch == null)
            {
                return NotFound();
            }

            return View(pitch);
        }

        // GET: Pitches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pitches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PitchId,Title,Synopsis,SubmittedTo,DateSubmitted,Notes,Accepted,DateAccepted,UserId")] Pitch pitch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pitch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pitch);
        }

        // GET: Pitches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitch = await _context.Pitch.FindAsync(id);
            if (pitch == null)
            {
                return NotFound();
            }
            return View(pitch);
        }

        // POST: Pitches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PitchId,Title,Synopsis,SubmittedTo,DateSubmitted,Notes,Accepted,DateAccepted,UserId")] Pitch pitch)
        {
            if (id != pitch.PitchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pitch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PitchExists(pitch.PitchId))
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
            return View(pitch);
        }

        // GET: Pitches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitch = await _context.Pitch
                .FirstOrDefaultAsync(m => m.PitchId == id);
            if (pitch == null)
            {
                return NotFound();
            }

            return View(pitch);
        }

        // POST: Pitches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pitch = await _context.Pitch.FindAsync(id);
            _context.Pitch.Remove(pitch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PitchExists(int id)
        {
            return _context.Pitch.Any(e => e.PitchId == id);
        }
    }
}
