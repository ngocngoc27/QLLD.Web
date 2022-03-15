using Microsoft.AspNetCore.Mvc;
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
    public class CalendarController : Controller
    {
        private readonly ICalendarService _CalendarService;
        public CalendarController(ICalendarService calendarService)
        {
            _CalendarService = calendarService;
        }
        public IActionResult Index()
        {
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
                    catch (DbUpdateConcurrencyException ex)
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
    }
}
