using System;

namespace GoHub.Dtos
{
    public class GoDto

    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public UserDto Artical { get; set; }
        public DateTime DateTime { get; set; }
        public String Venue { get; set; }
        public GenreDto Genre { get; set; }

    }
}