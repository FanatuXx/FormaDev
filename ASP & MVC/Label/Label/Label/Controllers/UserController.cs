using Label.Models;
using Microsoft.AspNetCore.Mvc;

namespace Label.Controllers
{
    public class UserController : Controller
    {
        public static readonly List<User> _users = new()
        {
            new User { Id = 1, Name = "Thomas", Email = "Thomas@genius.com", Role = "student"},
            new User { Id = 2, Name = "Thierry", Email = "TheGoat@Senior.com", Role = "Admin"},
            new User { Id = 3, Name = "Khun", Email = "CeMecEstInhumain@gmail.com", Role = "User"}
        };

        public IActionResult Index()
        {
            return View(_users);
        }
    }
}
