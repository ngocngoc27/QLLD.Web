﻿using Microsoft.AspNetCore.Http;
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
        public WorkTickerController(IWorkTickerService worktickerService, ICalendarService calendarService)
        {
            _worktickerService = worktickerService;
            _calendarService = calendarService;
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var data = _worktickerService.Get();
            return View(data);
        }
        public IActionResult CalendarPage()
        {
            ViewBag.sundayafter = _worktickerService.GetSundayAfter();
            ViewBag.sundaymor = _worktickerService.GetSundayMor();
            ViewBag.mondayafter = _worktickerService.GetMondayAfter();
            ViewBag.mondaymor = _worktickerService.GetMondayMor();
            ViewBag.tuesdayafter = _worktickerService.GetTuesdayAfter();
            ViewBag.tuesdaymor = _worktickerService.GetTuesdayMor();
            ViewBag.wednesdayafter = _worktickerService.GetWednesdayAfter();
            ViewBag.wednesdaymor = _worktickerService.GetWednesdayMor();
            ViewBag.thursdayafter = _worktickerService.GetThursdayAfter();
            ViewBag.thursdaymor = _worktickerService.GetThursdayMor();
            ViewBag.fridayafter = _worktickerService.GetFridayAfter();
            ViewBag.fridaymor = _worktickerService.GetFridayMor();
            ViewBag.saturdayafter = _worktickerService.GetSaturdayAfter();
            ViewBag.saturdaymor = _worktickerService.GetSaturdayMor();
            return View();
        }

        private void CalendarList(object selectCalendar = null)
        {
            ViewBag.calendar = new SelectList(_calendarService.Get(), "Id", "Day", selectCalendar);
        }
        //private void JobList(object selectJob = null)
        //{
        //    ViewBag.job = new SelectList(_jobService.Get(), "Id", "Job1", selectJob);
        //}
        private bool TickerExists(long id)
        {
            return _worktickerService.TickerExists(id);
        }
        [NoDirectAccess]
        public IActionResult AddOrEdit(int id = 0)
        {
            CalendarList();
            //JobList();
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
        public IActionResult AddOrEdit(Workticker model)
        {
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
        public IActionResult DeleteConfirmed(Workticker model)
        {
            _worktickerService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _worktickerService.Get()) });
        }
    }
}
