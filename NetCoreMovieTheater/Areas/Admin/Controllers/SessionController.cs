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
    public class SessionController : Controller
    {
        private readonly IRepository<Session> sessionRepository;

        public SessionController(IRepository<Session> sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }
        public ActionResult Index()
        {
            return View(sessionRepository.GetAll());
        }

        // GET: SessionConroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SessionConroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SessionConroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Session session)
        {
            try
            {
                sessionRepository.Create(session);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SessionConroller/Edit/5
        public ActionResult Edit(int id)
        {
            var updated= sessionRepository.GetById(id);
            return View(updated);
        }

        // POST: SessionConroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Session session)
        {
            try
            {
                sessionRepository.Update(session);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SessionConroller/Delete/5
        public ActionResult Delete(Session session)
        {
            sessionRepository.Delete(session);
            return RedirectToAction("Index");
        }

    }
}
