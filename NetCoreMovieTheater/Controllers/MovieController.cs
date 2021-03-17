using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepository<Movie> movieRepository;

        public MovieController(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            return View(movieRepository.GetMovieGenreVMs());
        }
    }
}
