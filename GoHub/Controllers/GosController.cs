using GoHub.Models;
using GoHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
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
        // GET: Gos
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
        public ActionResult Create(GoFormViewModel viewModel)
        {
            var go = new Go
            {
                ArticalId = User.Identity.GetUserId(),
                DateTime = viewModel.DateTime,
                //DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date,viewModel.Time)),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _context.Gos.Add(go);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

            
        
    }
}