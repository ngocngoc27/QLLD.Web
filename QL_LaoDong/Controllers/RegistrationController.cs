using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        
        [NoDirectAccess]
        public IActionResult Create()
        {         
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Workticker model)
        {
            
             _worktickerService.Create(model);
            return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _worktickerService.Get()) });

        }

        [NoDirectAccess]
        public IActionResult Cancle(int id)
        {
            var data = _worktickerService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancle(Workticker model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _worktickerService.Cancle(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TickerExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _worktickerService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "Cancle", model) });
        }

        private bool TickerExists(long id)
        {
            return _worktickerService.TickerExists(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Workticker model)
        {
            _worktickerService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _worktickerService.Get()) });
        }
    }
}
