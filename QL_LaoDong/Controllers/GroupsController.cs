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
    public class GroupsController : Controller
    {
        private readonly IWorkTickerService _worktickerService;
        private readonly IGroupsService _groupsService;
        private readonly ICalendarService _calendarService;
        private readonly IJobService _jobService;
        private readonly IToolService _toolService;
        public GroupsController(IGroupsService groupsService, ICalendarService calendarService, IJobService jobService, IToolService toolService, IWorkTickerService workTickerService)
        {
            _groupsService = groupsService;
            _calendarService = calendarService;
            _jobService = jobService;
            _toolService = toolService;
            _worktickerService = workTickerService;
        }
        public IActionResult Index()
        {
            var data = _groupsService.Get();
            return View(data);
        }
        [NoDirectAccess]
        public IActionResult Edit(int id)
        {
            var data = _groupsService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Groups model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _groupsService.Edit(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupsExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _groupsService.Get()) });
            }            
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "Edit", model) });
        }

        private bool GroupsExists(long id)
        {
            return _groupsService.GroupsExists(id);
        }
        /*==========================================================*/
        private void StudentList(long id, object selectStudent = null)
        {
            ViewBag.stu = new SelectList(_worktickerService.GetStudent(id), "Id", "MSSV", selectStudent);
        }
        [NoDirectAccess]
        public IActionResult CreateMuster(long id)
        {
            StudentList(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMuster(Muster model)
        {
            _groupsService.CreateMuster(model);
            return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _groupsService.Get()) });
        }
    }
}
