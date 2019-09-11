using System;
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
    public class PublicationsController : Controller
    {
        //dependency injection for getting current user

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public PublicationsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<User> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        // GET: Publications

        public async Task<IActionResult> Index()
        {
            //get curr user
            var user = await GetUserAsync();
            var applicationDbContext = _context.Publication
                .Where(p => user.Id == p.UserId)
                .Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Publications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication
                .FirstOrDefaultAsync(m => m.PublicationId == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // GET: Publications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("PublicationId,Title,Specialty,UserId")] Publication publication)
        {
            var user = await GetUserAsync();
            //remove user bc the model will be invalid if not; there is no user column in pitches table
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                publication.UserId = user.Id;

                _context.Add(publication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publication);
        }

        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", publication.UserId);
            return View(publication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublicationId,Title,Specialty,UserId")] Publication publication)
        {
            var user = await GetUserAsync();
            //remove user again, just like above
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (id != publication.PublicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationExists(publication.PublicationId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", publication.UserId);
            return View(publication);
        }




        // GET: Publications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publication
                .FirstOrDefaultAsync(m => m.PublicationId == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Publication.FindAsync(id);
            _context.Publication.Remove(publication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationExists(int id)
        {
            return _context.Publication.Any(e => e.PublicationId == id);
        }
    }
}
