using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GoHub.Models
{
    public class Go
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }    

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

        public ICollection<Attendance> Attendances { get; private set; }

        public Go()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GoCanceled(this);


            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);

            }
        }

        public void Modify(DateTime dateTime, string venue, byte genre)
        {
            var notification = Notification.GoUpdated(this, DateTime, venue);
            
            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
           
        }
    }
}