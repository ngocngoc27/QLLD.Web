using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            return View();
        }

    }
}
