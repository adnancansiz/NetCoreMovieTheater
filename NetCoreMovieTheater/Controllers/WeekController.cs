using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Controllers
{
    public class WeekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
