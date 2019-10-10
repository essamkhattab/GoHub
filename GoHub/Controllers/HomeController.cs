using GoHub.Models;
using GoHub.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GoHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
           _context =new ApplicationDbContext();
        }
        
        public ActionResult Index(string query = null)
        {
            var upcomingGos = _context.Gos
                .Include(g => g.Artical)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);
            if (!String.IsNullOrWhiteSpace(query))
            {
                upcomingGos = upcomingGos
                    .Where(g =>
                        g.Artical.Name.Contains(query) ||
                        g.Genre.Name.Contains(query) ||
                        g.Venue.Contains(query));
            }

            var ViewModel = new GosViewModel
            {
                UpcomingGos = upcomingGos,
                ShowActions = User.Identity.IsAuthenticated,
                Heading =  "Upcoming Gos",
                SearchTerm = query
            };

            return View("Gos",ViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}