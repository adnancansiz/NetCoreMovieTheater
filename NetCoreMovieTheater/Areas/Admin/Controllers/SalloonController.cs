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
    public class SalloonController : Controller
    {
        private readonly IRepository<Salloon> salloonRepository;

        public SalloonController(IRepository<Salloon> salloonRepository)
        {
            this.salloonRepository = salloonRepository;
        }
        // GET: SalloonController
        public ActionResult Index()
        {
            return View(salloonRepository.GetAll());
        }

        // GET: SalloonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalloonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalloonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Salloon salloon)
        {
            try
            {
                salloonRepository.Create(salloon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalloonController/Edit/5
        public ActionResult Edit(int Id)
        {
            var updated=salloonRepository.GetById(Id);
            return View(updated);
        }

        // POST: SalloonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Salloon salloon)
        {
            try
            {
                salloonRepository.Update(salloon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalloonController/Delete/5
        public ActionResult Delete(Salloon salloon)
        {
            salloonRepository.Delete(salloon);
            return RedirectToAction("Index");
        }

    }
}
