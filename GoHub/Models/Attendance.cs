using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoHub.Models
{
    public class Attendance
    {
        public Go Go { get; set; }
        public ApplicationUser Attendee { get; set; }

        [Key]
        [Column(Order = 1)]
        public int GoId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }

    }

    
}