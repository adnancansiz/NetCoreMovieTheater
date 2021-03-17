using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Reservation:BaseEntity
    {
        public int MovieId { get; set; }
        public int SalloonId { get; set; }
        public int SessionId { get; set; }
        public int WeekId { get; set; }
        public string AppUserId { get; set; }


        public Movie Movie { get; set; }
        public Salloon Salloon { get; set; }
        public Session Session { get; set; }
        public Week Week { get; set; }
        public AppUser AppUser { get; set; }
    }
}
