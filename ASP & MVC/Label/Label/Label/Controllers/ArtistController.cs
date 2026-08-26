using Label.Models;
using Microsoft.AspNetCore.Mvc;

namespace Label.Controllers
{
    public class ArtistController : Controller
    {
        public static readonly List<Artist> _artists = new()
        {
            new Artist { Id = 1, Name = "wit.", Genra = "French Rap", Country = "France", Active = true},
            new Artist { Id = 2, Name = "Jeshi", Genra = "London Rap", Country = "England", Active = true},
            new Artist { Id = 3, Name = "Linkin Park", Genra = "Rock", Country = "US", Active = true},
            new Artist { Id = 4, Name = "Daft Punk", Genra = "Electronic", Country = "France", Active = false},
            new Artist { Id = 5, Name = "Metallica", Genra = "Rock", Country = "US", Active = true}
        }; 

        public IActionResult Index()
        {
            return View(_artists);
        }
    }
}
