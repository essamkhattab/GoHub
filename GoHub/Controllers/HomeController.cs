using GoHub.Models;
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
        
        public ActionResult Index()
        {
            var upcomingGos = _context.Gos
                .Include(g => g.Artical)
                .Where(g => g.DateTime > DateTime.Now);

            return View(upcomingGos);
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