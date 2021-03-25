using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JoelsDatabaseSequel.Models;
using Microsoft.EntityFrameworkCore;
using JoelsDatabaseSequel.Models.ViewModels;


namespace JoelsDatabaseSequel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private FilmDBcontext _context;

        public HomeController(ILogger<HomeController> logger, FilmDBcontext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Film film)
        {


            if (ModelState.IsValid)
            {
                _context.Films.Add(film);

                _context.SaveChanges();

                return View("Database", new FilmListViewModel
                {
                    Films = _context.Films
                    .OrderBy(f => f.FilmId)
                    .Where(f => f.Title != "Independence Day")
                });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult RemoveFilm(int FilmId)
        {
            _context.Films.Remove(_context.Films.Where(x => x.FilmId == FilmId).FirstOrDefault());
            _context.SaveChanges();
            return View("Database", new FilmListViewModel
            {
                Films = _context.Films
                  .Where(f => f.Title != "Independence Day")
                  .OrderBy(f => f.FilmId)
            });
        }

        [HttpGet]
        public IActionResult EditFilm(int FilmId)
        {
            return View(_context.Films.Where(x => x.FilmId == FilmId).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult EditFilm(Film film)
        {
            _context.Films.Update(film);
            _context.SaveChanges();

            return View("Database", new FilmListViewModel
            {
                Films = _context.Films
                  .Where(f => f.Title != "Independence Day")
                  .OrderBy(f => f.FilmId)
            });
        }
        [HttpGet]
        public IActionResult Database()
        {
            return View("Database", new FilmListViewModel
            {
                Films = _context.Films
                    .OrderBy(f => f.FilmId)
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
