using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class MovieController : Controller
    {
        private readonly IRepository<Movie> movieRepository;
        private readonly IRepository<Genre> genreRepository;
        private readonly IRepository<MovieGenre> moviegenreRepository;


        public MovieController(IRepository<Movie> movieRepository, IRepository<Genre> genreRepository, IRepository<MovieGenre> moviegenreRepository)
        {
            this.movieRepository = movieRepository;
            this.genreRepository = genreRepository;
            this.moviegenreRepository = moviegenreRepository;
        }


        // GET: MovieController
        public ActionResult Index()
        {
            
            return View(movieRepository.GetMovieGenreVMs());
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            ViewBag.Genre = genreRepository.GetAll();
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie, List<int> genreId)
        {

            try
            {
                movieRepository.Create(movie);
                foreach (var genre in genreId)
                {
                    var mvgn = new MovieGenre { MovieId = movie.Id, GenreId = genre };
                    moviegenreRepository.Create(mvgn);
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Genre = genreRepository.GetAll();
            var updated = movieRepository.GetById(id);
            return View(updated);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie, List<int> genreId)
        {
            try
            {
                List<MovieGenre> movieGenres = new List<MovieGenre>();
                foreach (var genre in genreId)
                {
                    movieGenres.Add(new MovieGenre { MovieId = movie.Id, GenreId = genre });
                }
                var existGenre = moviegenreRepository.GetAll().Where(x => x.MovieId == movie.Id);
                var addGenre = movieGenres.Where(x => !existGenre.Any(i => i.GenreId == x.GenreId)).ToList();
                var deleteGenre = existGenre.Where(x => !addGenre.Any(i => i.GenreId == x.GenreId)).ToList();

                foreach (var genre in addGenre)
                {
                    moviegenreRepository.Create(genre);
                }


                foreach (var genre in deleteGenre)
                {
                    moviegenreRepository.Delete(genre);
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(Movie movie)
        {
           var deleteMovieGenre = moviegenreRepository.GetAll().Where(x => x.MovieId == movie.Id).ToList();
            foreach (var movieGenre in deleteMovieGenre)
            {
                moviegenreRepository.Delete(movieGenre);
            }
            movieRepository.Delete(movie);
            return RedirectToAction("Index");
        }

    }
}
