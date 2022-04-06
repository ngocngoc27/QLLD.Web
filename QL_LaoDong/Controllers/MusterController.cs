using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class MusterController : Controller
    {
        private readonly IGroupsService _groupsService;
        private readonly ICalendarService _calendarService;
        private readonly IJobService _jobService;
        private readonly IToolService _toolService;
        private readonly IMusterService _musterService;
        private readonly IWorkTickerService _worktickerService;
        public MusterController(IGroupsService groupsService, ICalendarService calendarService, IJobService jobService, IToolService toolService, IMusterService musterService, IWorkTickerService workTickerService)
        {
            _groupsService = groupsService;
            _calendarService = calendarService;
            _jobService = jobService;
            _toolService = toolService;
            _musterService = musterService;
            _worktickerService = workTickerService;
        }
        public IActionResult PageMuster(long id, long CalendarId)
        {
            var value = HttpContext.Session.GetString("idrole");
            ViewBag.usename = HttpContext.Session.GetString("user");
            ViewBag.idrole = Convert.ToInt32(value);
            ViewBag.caid = CalendarId;
            ViewBag.groupID = id;
            ViewBag.grname = _groupsService.GetById(id).GroupsName;
            var data = _musterService.PageMuster(id);
            return View(data);
        }
        [NoDirectAccess]
        public IActionResult AddStudent(long id, long ids)
        {
            ViewBag.idgr = ids;
            var data = _worktickerService.GetStudent(id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Muster model, long ids)
        {
            ViewBag.idgr = ids;
            _musterService.AddStudent(model, ids);
            //return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "PageMuster", _musterService.PageMuster(ids)) });
            //return RedirectToAction("PageMuster");
            return Redirect("/Muster/PageMuster/" + ids);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Muster model, long id)
        {
            ViewBag.idca = id;
            _musterService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "PageMuster", _musterService.PageMuster(id)) });
        }
        [HttpPost]
        public IActionResult Checkdiemdanh([FromBody] List<MusterVM> model)
        {
            _musterService.Diemdanh(model);
            return Json(model);
        }
       
    }
}
