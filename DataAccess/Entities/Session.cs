using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Session:BaseEntity
    {
        public TimeSpan SessionTime { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
    }
}
