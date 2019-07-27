using GoHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoHub.ViewModels
{
    public class GoFormViewModel
    {
        [Required]
        public String Venue { get; set; }

        [Required]
        [FutureDate]
        public String Date { get; set; }

        [Required]
        [ValidTime]
        public String Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        //get { return GetDateTime.Parse($"{Date} {Time}"); }
        //public GetDateTime GetDateTime => GetDateTime.Parse($"{Date} {Time}");

        public DateTime GetDateTime()
        {
            return DateTime.Parse(String.Format("{0} {1}", Date, Time));
        }
    }
}


