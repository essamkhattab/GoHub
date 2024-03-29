﻿using System.Linq;
using System.Web.Http;
using GoHub.Dtos;
using GoHub.Models;
using Microsoft.AspNet.Identity;

namespace GoHub.Controllers.API
{
    [Authorize]
    public  class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GoId == dto.GoId))
                return BadRequest("The attendance already exists.");
            var attendance = new Attendance
            {
                GoId = dto.GoId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }


        
    }
}
