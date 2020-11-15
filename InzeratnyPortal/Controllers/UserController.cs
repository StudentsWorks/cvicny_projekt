using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InzeratnyPortal.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InzeratnyPortal.Controllers
{

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


    }
}
