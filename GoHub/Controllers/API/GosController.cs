using GoHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoHub.Controllers.API
{
    [Authorize]
    public class GosController : ApiController
    {
        private ApplicationDbContext _context;

        public GosController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var go = _context.Gos
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .Single(g => g.Id == id && g.ArticalId == userId);

            if (go.IsCanceled)
                return NotFound();

            go.Cancel();

            _context.SaveChanges();

            return Ok();
        }
    }
}
