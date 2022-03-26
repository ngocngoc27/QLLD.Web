using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QL_LaoDong.Helpers;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static QL_LaoDong.Helpers.Helper;

namespace QL_LaoDong.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IWorkTickerService _worktickerService;
        private readonly ICalendarService _calendarService;
        private readonly IJobService _jobService;
        public RegistrationController(IWorkTickerService workTickerService, ICalendarService calendarService, IJobService jobService)
        {
            _calendarService = calendarService;
            _worktickerService = workTickerService;
            _jobService = jobService;
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var data = _worktickerService.Get();
            return View(data);
        }
        public IActionResult CalendarTable()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var data = _worktickerService.GetCalendar();
            return View(data);
        }
        private void CalendarList(object selectCalendar = null)
        {
            ViewBag.calendar = new SelectList(_calendarService.Get(), "Id", "Day", selectCalendar);
           
        }
        [NoDirectAccess]
        public IActionResult Create()
        {
            //CalendarList();            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Workticker model)
        {
            
             _worktickerService.Create(model);
            return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _worktickerService.Get()) });

        }
    }
}
