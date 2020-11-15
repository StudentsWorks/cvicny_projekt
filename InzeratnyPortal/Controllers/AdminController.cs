using InzeratnyPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace InzeratnyPortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("User"); //Vsetci uzivatelia okrem admina
            return View(users);
        }


        public IActionResult DeleteUser(string id)
        {
            var items = _context.Item.Where(item => item.UserID == id);

            foreach (var i in items)
            {
                _context.Item.Remove(i);
               
            }
            _context.SaveChanges();

            var user = _context.Users.Where(user => user.Id == id).FirstOrDefault();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Admin");

        }

    }
}
