using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Controllers
{
    public class GenreController : Controller
    {
        private readonly IRepository<Genre> genreRepository;
        private readonly IRepository<Movie> movieRepository;

        public GenreController(IRepository<Genre> genreRepository,IRepository<Movie> movieRepository)
        {
            this.genreRepository = genreRepository;
            this.movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            return View(genreRepository.GetAll());
        }

        public IActionResult GetMovieByGenre(Genre genre)
        {
            var genres = genreRepository.GetById(genre.Id);
           var movieByGenre = movieRepository.GetMovieGenreVMs().Where(x => x.GenreName == genres.GenreName).ToList();

            return View(movieByGenre);

        }

    }

    
}
