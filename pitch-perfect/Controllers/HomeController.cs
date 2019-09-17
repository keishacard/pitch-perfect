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

        //public async Task<User> GetCurrentUserImg()
        //{
        //    var user = _userManager.GetUserAsync(HttpContext.User);
        //    return user;
        //}

        public IActionResult Index()
        {

            User user = GetUserAsync().Result;
            ViewBag.CurrentUser = user;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
