using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pitch_perfect.Data;
using pitch_perfect.Models;

namespace pitch_perfect.Controllers
{
    public class HomeController : Controller
    {
        //dependency injection for getting current user

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(ApplicationDbContext context, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        private Task<User> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[Authorize]
        //[HttpPost("ImageUpload")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ImageUpload(IFormFile file)
        //{
        //    var user = await GetUserAsync();

        //    if (ModelState.IsValid)
        //    {
        //        user.ImagePath = await SaveFile(file, user.Id);

        //        if (user.ImagePath == null)
        //        {
        //            return NotFound();
        //        }

        //        await _userManager.UpdateAsync(user);

        //        return RedirectToAction(nameof(Profile));
        //    }

        //    return NotFound();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
