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
            var totalw = HttpContext.Session.GetString("totalwork");
            int total;
            if (totalw != null)
            {
                total = Convert.ToInt32(totalw);
            }
            else
            {
                total = 0;
            }
           
            var numw = HttpContext.Session.GetString("numberwork");
            int numbw;
            if (numw == null)
            {
                numbw = 0;
            }
            numbw = Convert.ToInt32(numw);
            ViewBag.numwork = numbw;
            ViewBag.totalwork = total;
            ViewBag.ds = _workTickerService.CountsDS();
            ViewBag.lop = _classService.CountClass();
            ViewBag.daduyet = _workTickerService.CountTT();
            ViewBag.baoban = _workTickerService.CountBan();
            ViewBag.choduyet = _workTickerService.Choduyet();
            return View();
        }

    }
}
