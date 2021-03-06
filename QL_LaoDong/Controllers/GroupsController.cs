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
    public class GroupsController : Controller
    {
        private readonly IGroupsService _groupsService;
        private readonly ICalendarService _calendarService;
        private readonly IJobService _jobService;
        private readonly IToolService _toolService;
        private readonly IMusterService _musterService;
        private readonly IWorkTickerService _worktickerService;

        public GroupsController(IGroupsService groupsService, ICalendarService calendarService, IJobService jobService, IToolService toolService, IMusterService musterService, IWorkTickerService workTickerService)
        {
            _groupsService = groupsService;
            _calendarService = calendarService;
            _jobService = jobService;
            _toolService = toolService;
            _musterService = musterService;
            _worktickerService = workTickerService;
        }
        public IActionResult PageGroups(long id)
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            ViewBag.caid = id;
            ViewBag.calendar = _calendarService.GetById(id);
            var value = HttpContext.Session.GetString("idrole");
            ViewBag.idrole = Convert.ToInt32(value);

            var data = _groupsService.PageGroups(id);
            return View(data);
        }
        [NoDirectAccess]
        public IActionResult AddOrEdit(long ids, int id = 0)
        {
            JobList();
            ViewBag.caid = ids;
            ViewBag.calendar = _calendarService.GetById(ids);
            if (id == 0)
            {
                return View(new Groups());
            }
            else
            {                
                var data = _groupsService.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Groups model, long caid)
        {
            ViewBag.calendar = _calendarService.GetById(caid);
            //if (ModelState.IsValid)
            
                if (model.Id == 0)
                {
                    _groupsService.CreateGroups(model, caid);
                }
                else
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
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _groupsService.PageGroups(caid))});
            
            //return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }        
        private void JobList(object selectJob = null)
        {
            ViewBag.job = new SelectList(_jobService.Get(), "Id", "JobName", selectJob);
        }
        private bool GroupsExists(long id)
        {
            return _groupsService.GroupsExists(id);
        }      

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Groups model, long id)
        {
            ViewBag.caid = id;
            ViewBag.calendar = _calendarService.GetById(id);
            _groupsService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _groupsService.PageGroups(id))});
        }
    }
}
