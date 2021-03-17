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
    public class WeekController : Controller
    {
        private readonly IRepository<Week> weekRepository;

        public WeekController(IRepository<Week> weekRepository)
        {
            this.weekRepository = weekRepository;
        }
        public IActionResult Index()
        {
            return View(weekRepository.GetAll());
        }

        public IActionResult AddWeek()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWeek(Week week)
        {
            weekRepository.Create(week);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Week week)
        {
            weekRepository.Delete(week);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
            var updated = weekRepository.GetById(Id);
            return View(updated);
        }

        [HttpPost]
        public IActionResult Update(Week week)
        {
            weekRepository.Update(week);
            return RedirectToAction("Index");
        }
    }
}
