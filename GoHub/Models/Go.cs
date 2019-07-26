using System;
using System.ComponentModel.DataAnnotations;

namespace GoHub.Models
{
    public class Go
    {
        public int Id { get; set; }

        
        public ApplicationUser Artical { get; set; }

        [Required]
        public string ArticalId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public String Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}