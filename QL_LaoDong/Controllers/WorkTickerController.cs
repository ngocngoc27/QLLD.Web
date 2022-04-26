using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QL_LaoDong.Helpers;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using QL_LaoDong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static QL_LaoDong.Helpers.Helper;

namespace QL_LaoDong.Controllers
{
    public class WorkTickerController : Controller
    {
        private readonly IWorkTickerService _worktickerService;
        private readonly ICalendarService _calendarService;
        private readonly IStudentService _studentService;
        public WorkTickerController(IWorkTickerService worktickerService, ICalendarService calendarService, IJobService jobService, IStudentService studentService)
        {
            _worktickerService = worktickerService;
            _calendarService = calendarService;
            _studentService = studentService;
        }
        public IActionResult ListStudent()
        {
            var data=_studentService.GetClass();
            var value = HttpContext.Session.GetString("idrole");
            ViewBag.idrole = Convert.ToInt32(value);
            return View(data);
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var value = HttpContext.Session.GetString("idrole");
            ViewBag.idrole = Convert.ToInt32(value);
            var data = _worktickerService.Get();
            return View(data);
        }
        private void CalendarList(object selectCalendar = null)
        {
            ViewBag.calendar = new SelectList(_calendarService.Get(), "Id", "Day", selectCalendar);
        }        
        private bool TickerExists(long id)
        {
            return _worktickerService.TickerExists(id);
        }
        [NoDirectAccess]
        public IActionResult Edit(int id = 0)
        {
            CalendarList();
            if (id == 0)
            {
                return View(new Workticker());
            }
            else
            {
                var data = _worktickerService.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Workticker model, long id)
        {
            ViewBag.calendar = _calendarService.GetById(id);
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _worktickerService.Create(model);
                }
                else
                {
                    try
                    {
                        _worktickerService.Edit(model);
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
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _worktickerService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Workticker model, long id)
        {
            ViewBag.calendar = _calendarService.GetById(id);
            _worktickerService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _worktickerService.Get()) });
        }
        public IActionResult PageWorkTicker(long id)
        {
            var value = HttpContext.Session.GetString("idrole");
            ViewBag.usename = HttpContext.Session.GetString("user");
            ViewBag.idrole = Convert.ToInt32(value);
            ViewBag.calendar = _calendarService.GetById(id);
            var data = _worktickerService.PageWorkTicker(id);
            return View(data);
        }
    }
}
