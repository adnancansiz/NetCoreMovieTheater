using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Models.ViewModels
{
    public class MovieGenreVM
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string GenreName { get; set; }
    }
}
