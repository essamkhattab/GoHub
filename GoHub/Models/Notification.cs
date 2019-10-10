using System;
using System.CodeDom;
using System.ComponentModel.DataAnnotations;
using System.Web.Profile;

namespace GoHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get;  private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Go Go { get; private set; }

        protected Notification() { }


        private Notification(NotificationType type, Go go)
        {
            if (go == null)
                throw new ArgumentNullException("go");
            Type = type;
            Go = go;
            DateTime =DateTime.Now;
        }

        public  static Notification GoCreated(Go go)
        {
          return  new Notification(NotificationType.GoCreated, go);
        }

        public  static Notification GoUpdated(Go newGo , DateTime originalDateTime ,string originalVenue)
        {
          var notification =  new Notification(NotificationType.GoUpdated, newGo);
          notification.OriginalDateTime = originalDateTime;
          notification.OriginalVenue = originalVenue;

          return notification;
        }

        public static Notification GoCanceled(Go go)
        {
            return new Notification(NotificationType.GoCanceled, go);
        }
    }

   
}