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
        private readonly IJobService _jobService;
        public WorkTickerController(IWorkTickerService worktickerService, ICalendarService calendarService, IJobService jobService)
        {
            _worktickerService = worktickerService;
            _calendarService = calendarService;
            _jobService = jobService;
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var data = _worktickerService.Get();
            return View(data);
        }

        //private void CalendarList(object selectCalendar = null)
        //{
        //    ViewBag.CalendarId = new SelectList(_calendarService.Get(), "Id", "FacultyName", selectCalendar);
        //}
        //private bool TickerExists(long id)
        //{
        //    return _worktickerService.TickerExists(id);
        //}
        //[NoDirectAccess]
        //public IActionResult AddOrEdit(int id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return View(new Workticker());
        //    }
        //    else
        //    {
        //        var data = _worktickerService.GetById(id);
        //        if (data == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(data);
        //    }
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddOrEdit(Workticker model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model.Id == 0)
        //        {
        //            _worktickerService.Create(model);
        //        }
        //        else
        //        {
        //            try
        //            {
        //                _worktickerService.Edit(model);
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!TickerExists(model.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //        }
        //        return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _worktickerService.Get())});
        //    }
        //    return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(Workticker model)
        //{
        //    _worktickerService.Delete(model);
        //    return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _worktickerService.Get()) });
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Workticker model)
        //{
        //    _worktickerService.Create(model);
        //    return View();
        //}
       
    }
}
