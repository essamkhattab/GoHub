using GoHub.Models;
using System;
using System.Collections.Generic;

namespace GoHub.ViewModels
{
    public class GoFormViewModel
    {
        public String Venue { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime DateTime => DateTime.Parse($"{Date} {Time}");
    }
}

//get { return DateTime.Parse($"{Date} {Time}"); }
