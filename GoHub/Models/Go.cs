using System;
using System.ComponentModel.DataAnnotations;

namespace GoHub.Models
{
    public class Go
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Artical { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public String Venue { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}