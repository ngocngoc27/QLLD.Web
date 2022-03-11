using Microsoft.AspNetCore.Mvc;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService _CalendarService;
        public IActionResult Index()
        {
            var data = _CalendarService.Get();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Calendar model)
        {

            _CalendarService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var data = _CalendarService.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Calendar model)
        {
            _CalendarService.Edit(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
