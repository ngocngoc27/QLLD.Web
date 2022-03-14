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
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly IFacultyService _FacultyService;
        public ClassController(IClassService classService, IFacultyService facultyService)
        {
            _classService = classService;
            _FacultyService = facultyService; 
        }
        public IActionResult Index()
        {
            var data = _classService.Get();
            return View(data);
        }
        private void FacultyList(object selectFaculty = null)
        {
            ViewBag.FacultyId = new SelectList(_FacultyService.Get(), "Id", "FacultyName", selectFaculty);
        }
        private bool ClassExists(long id)
        {
            return _classService.ClassExists(id);
        }
        [NoDirectAccess]
        public IActionResult AddOrEdit(int id = 0)
        {
            FacultyList();
            if (id == 0)
            {
                return View(new Class());
            }
            else
            {
                var data = _classService.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Class model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _classService.Create(model);
                }
                else
                {
                    try
                    {
                        _classService.Edit(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClassExists(model.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _classService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Class model)
        {
            _classService.Delete(model);
            return Json(new {html = Helper.RenderRazorViewToString(this, "_ViewAll", _classService.Get())});
        }
    }
}
