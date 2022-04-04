using Microsoft.AspNetCore.Http;
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
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var data = HttpContext.Session.GetString("idrole");
            ViewBag.idrole = Convert.ToInt32(data);
            var job = _jobService.Get();
            return View(job);
        }
        private bool JobExists(long id)
        {
            return _jobService.JobExists(id);
        }
        [NoDirectAccess]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Job());
            }
            else
            {
                var data = _jobService.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Job model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _jobService.Create(model);
                }
                else
                {
                    try
                    {
                        _jobService.Edit(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!JobExists(model.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _jobService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Job model)
        {
            _jobService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _jobService.Get()) });
        }
        [HttpGet]
        public IActionResult Lock(Job model, int id)
        {
            var job = _jobService.GetById(id);
            _jobService.Lock(job);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var data=_jobService.GetById(id);
            return View(data);
        }
    }
}
