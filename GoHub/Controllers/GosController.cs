using GoHub.Models;
using GoHub.ViewModels;
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
        public ActionResult Create()
        {
            var viewModel = new GoFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}