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
using Microsoft.AspNetCore.Http.Extensions;


namespace QL_LaoDong.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService _CalendarService;
        private readonly IWorkTickerService _WorkTickerService;
        private readonly IJobService _jobService;
        private readonly IGroupsService _groupsService;
        private readonly IMusterService _musterService;
        private readonly ITooltickerService _tooltickerService;

        public CalendarController(ICalendarService calendarService, IWorkTickerService workTickerService, IJobService jobService, IGroupsService groupsService, IMusterService musterService, ITooltickerService tooltickerService)
        {
            _CalendarService = calendarService;
            _WorkTickerService = workTickerService;
            _jobService = jobService;
            _groupsService = groupsService;
            _musterService = musterService;
            _tooltickerService = tooltickerService;
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var value = HttpContext.Session.GetString("idrole");
            ViewBag.idrole = Convert.ToInt32(value);
            var data = _CalendarService.Get();
            return View(data);
        }
        private bool CalendarExists(long id)
        {
            return _CalendarService.CalendarExists(id);
        }
        [NoDirectAccess]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Calendar());
            }
            else
            {
                var data = _CalendarService.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Calendar model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _CalendarService.Create(model);
                }
                else
                {
                    try
                    {
                        _CalendarService.Edit(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CalendarExists(model.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw new Exception("faadfdsfds");
                        }
                    }
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _CalendarService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Calendar model)
        {
            _CalendarService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _CalendarService.Get()) });
        }
        public IActionResult CalendarPage()
        {
            ViewBag.sundayafter = _groupsService.GetSundayAfter();
            ViewBag.sundaymor = _groupsService.GetSundayMor();
            ViewBag.mondayafter = _groupsService.GetMondayAfter();
            ViewBag.mondaymor = _groupsService.GetMondayMor();
            ViewBag.tuesdayafter = _groupsService.GetTuesdayAfter();
            ViewBag.tuesdaymor = _groupsService.GetTuesdayMor();
            ViewBag.wednesdayafter = _groupsService.GetWednesdayAfter();
            ViewBag.wednesdaymor = _groupsService.GetWednesdayMor();
            ViewBag.thursdayafter = _groupsService.GetThursdayAfter();
            ViewBag.thursdaymor = _groupsService.GetThursdayMor();
            ViewBag.fridayafter = _groupsService.GetFridayAfter();
            ViewBag.fridaymor = _groupsService.GetFridayMor();
            ViewBag.saturdayafter = _groupsService.GetSaturdayAfter();
            ViewBag.saturdaymor = _groupsService.GetSaturdayMor();
            ViewBag.usename = HttpContext.Session.GetString("user");
            return View();
        }

        public IActionResult CalendarDetail(long id)
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            ViewBag.liststudent = _musterService.PageMuster(id);
            ViewBag.listtool = _tooltickerService.PageToolTicker(id);
            var data = _groupsService.GetById(id);
            return View(data);
        }
    }
}