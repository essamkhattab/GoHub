using GoHub.Models;
using GoHub.ViewModels;
using Microsoft.AspNet.Identity;
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
        // GET: gos
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

            return RedirectToAction("Index", "Home");

        }

        
    }
}