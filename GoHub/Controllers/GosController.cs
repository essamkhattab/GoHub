using GoHub.Models;
using GoHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GoHub.Controllers
{
    public class GosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GosController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gos = _context.Gos
                .Where(g => g.ArticalId == userId && g.DateTime > DateTime.Now)
                .Include(g => g.Genre)
                .ToList();

            return View(gos);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gos = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Go)
                .Include(g => g.Artical)
                .Include(g => g.Genre)
                .ToList();

            var ViewModel = new GosViewModel()
            {
                UpcomingGos = gos,
                 ShowActions = User.Identity.IsAuthenticated ,  
                 Heading = "Gos I'm Attending"
            };

            return View("Gos",ViewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GoFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

            var go = new Go
            {
                ArticalId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                //GetDateTime = viewModel.GetDateTime,
                //GetDateTime = GetDateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _context.Gos.Add(go);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Gos");

        }

        
    }
}