using GoHub.Models;
using System.Collections.Generic;

namespace GoHub.ViewModels
{
    public class GosViewModel
    {
        public IEnumerable<Go> UpcomingGos { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}