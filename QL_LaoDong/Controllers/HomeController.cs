using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_LaoDong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkTickerService _workTickerService;
        private readonly IClassService _classService;
        public HomeController(IWorkTickerService workTickerService, IClassService classService)
        {
            _workTickerService = workTickerService;
            _classService = classService;
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            int total = Convert.ToInt32( HttpContext.Session.GetString("totalwork"));
            int numberwork = Convert.ToInt32(HttpContext.Session.GetString("numberwork"));
            if (numberwork == default)
            {
                ViewBag.numwork = 0;
            }
            ViewBag.numwork = numberwork;
            ViewBag.totalwork = total;
            ViewBag.ds = _workTickerService.CountsDS();
            ViewBag.lop = _classService.CountClass();
            ViewBag.daduyet = _workTickerService.CountTT();
            return View();
        }

    }
}
