using Microsoft.AspNetCore.Mvc;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class MusterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
