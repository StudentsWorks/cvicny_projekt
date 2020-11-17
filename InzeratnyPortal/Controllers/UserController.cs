using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InzeratnyPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InzeratnyPortal.Controllers
{

    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public UserController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = _context.Users.Where(user => user.Email == User.Identity.Name).FirstOrDefault().Id;
            var items = _context.Item.Where(item => item.UserID == userId);

            return View(items);
        }
        

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Save(string name)
        {
            var userId = _context.Users.Where(user => user.Email == User.Identity.Name).FirstOrDefault().Id;
            var user = _context.Users.Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            if (name != null)
            {
                user.UserName = name;
                _context.SaveChanges();
            }

            var items = _context.Item.Where(item => item.UserID == userId);

            return View("Index", items);
        }

    }
}
