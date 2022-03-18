using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }
        private void CalendarList(object selectCalendar = null)
        {
            ViewBag.calendar = new SelectList(_calendarService.Get(), "Id", "Day", selectCalendar);
        }
        public IActionResult Create()
        {
            CalendarList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Workticker model)
        {
            model.Status = "Chờ duyệt";
            _worktickerService.Create(model);
            return View();
        }
    }
}
