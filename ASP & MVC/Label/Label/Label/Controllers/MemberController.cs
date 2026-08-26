using Label.Models;
using Microsoft.AspNetCore.Mvc;

namespace Label.Controllers
{
    public class MemberController : Controller
    {
        public static readonly List<Member> _members = new()
        {
            new Member {Id = 1, Pseudo = "Wit.", FirstName = "Farès", LastName = string.Empty, Age = 30, BandId = 1},
            new Member {Id = 2, Pseudo = "Jeshi", FirstName = "Jesse", LastName = "Greenway", Age = 31, BandId = 2},
            new Member {Id = 3, Pseudo = "Mike", FirstName = "Michael", LastName = "Kenji Shinoda", Age = 49, BandId = 3},
            new Member {Id = 4, Pseudo = null!, FirstName = "Emily", LastName = "Marcia Armstrong", Age = 40, BandId = 3},
            new Member {Id = 5, Pseudo = "Bid Bad Brad", FirstName = "Bradford", LastName = "Phillip Delson", Age = 49, BandId = 3},
            new Member {Id = 6, Pseudo = "Joe OU Mr. Hahn", FirstName = "Joseph", LastName = "Hahn", Age = 49, BandId = 3},
            new Member {Id = 7, Pseudo = "Dave Farrell OU Phoenix", FirstName = "David", LastName = "Michael Farrell", Age = 49, BandId = 3},
            new Member {Id = 8, Pseudo = "Colin « Doc » Brittain", FirstName = "Colin", LastName = "Cunningham", Age = 39, BandId = 3},
            new Member {Id = 9, Pseudo = null!, FirstName = "Thomas", LastName = "Bangalter", Age = 51, BandId = 4},
            new Member {Id = 10, Pseudo = "Guy-Man", FirstName = "Guillaume Emmanuel", LastName = "de Homem-Christo", Age = 51, BandId = 4},
            new Member {Id = 11, Pseudo = "Papa Het", FirstName = "James", LastName = "Hetfield", Age = 63, BandId = 5},
            new Member {Id = 12, Pseudo = null!, FirstName = "Lars", LastName = "Ulrich", Age = 62, BandId = 5},
            new Member {Id = 13, Pseudo = "The Ripper", FirstName = "Kirk Lee", LastName = "Ulrich", Age = 63, BandId = 5},
            new Member {Id = 14, Pseudo = null!, FirstName = "Robert", LastName = "Trujillo", Age = 61, BandId = 5},

        };
        public IActionResult Index()
        {
            return View(_members);
        }
    }
}
