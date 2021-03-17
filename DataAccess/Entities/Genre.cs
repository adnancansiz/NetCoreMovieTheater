using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Genre:BaseEntity
    {
        public string GenreName { get; set; }
        public string Description { get; set; }

        public virtual List<MovieGenre> MovieGenres { get; set; }

    }
}
