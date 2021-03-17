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
    [Authorize(Roles ="Administrator")]
    public class GenreController : Controller
    {
        private readonly IRepository<Genre> genreRepository;

        public GenreController(IRepository<Genre> genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        // GET: GenreController
        public ActionResult Index()
        {
            return View(genreRepository.GetAll());
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            try
            {
                genreRepository.Create(genre);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            var updated = genreRepository.GetById(id);
            return View(updated);
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            try
            {
                genreRepository.Update(genre);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(Genre genre)
        {
            genreRepository.Delete(genre);
            return RedirectToAction(nameof(Index));
        }

    }
}
