using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreMovieTheater.Models;
using Service.Models.ViewModels;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IRepository<Movie> MovieRepository { get; }

        public HomeController(ILogger<HomeController> logger,IRepository<Movie> movieRepository)
        {
            _logger = logger;
            MovieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            return View(MovieRepository.GetMovieGenreVMs());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
