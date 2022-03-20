using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class CalenPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
