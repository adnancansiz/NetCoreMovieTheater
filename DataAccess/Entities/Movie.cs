using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Movie:BaseEntity
    {
        public string MovieName { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        public short Rank { get; set; }

        public virtual List<MovieGenre> MovieGenres { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
