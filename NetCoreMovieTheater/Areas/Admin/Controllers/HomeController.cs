using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly IRepository<Movie> movieRepository;

        public HomeController(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            return View(movieRepository.GetMovieGenreVMs());
        }
    }
}
