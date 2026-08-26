using Label.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Label.Controllers
{
    public class AlbumController : Controller
    {
        public static readonly List<Album> _albums = new()
        {
            new Album { Id = 1, Title = "Le Jour d'Après", ArtistId = 1, Year = 2024},
            new Album { Id = 2, Title = "Cultive la Lumière", ArtistId = 1, Year = 2026},
            new Album { Id = 3, Title = "Universal Credit", ArtistId = 2, Year = 2022},
            new Album { Id = 4, Title = "Airbag Woke Me Up", ArtistId = 2, Year = 2025},
            new Album { Id = 5, Title = "Hybrid Theory", ArtistId = 3, Year = 2000},
            new Album { Id = 6, Title = "Meteora", ArtistId = 3, Year = 2003},
            new Album { Id = 7, Title = "Random Access Memories", ArtistId = 4, Year = 2013},
            new Album { Id = 8, Title = "Master of Puppets", ArtistId = 5, Year = 1986}
        };

        public static readonly List<Album> _albumsByArtist = new List<Album>();

        public IActionResult Index()
        {
            return View(_albums);
        }

        public IActionResult ByArtist(int bandId)
        {
            //ViewBag.Artist = artist
            _albumsByArtist.Clear();
            foreach (Album album in _albums)
            {
                if(album.ArtistId == bandId)
                {
                    _albumsByArtist.Add(album);
                }
            }
            return View(_albumsByArtist);
        }
    }
}
