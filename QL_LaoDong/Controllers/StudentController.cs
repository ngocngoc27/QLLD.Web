using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QL_LaoDong.Helpers;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static QL_LaoDong.Helpers.Helper;

namespace QL_LaoDong.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IAccountService _accountService;
        private readonly IClassService _classService;
        private IHttpContextAccessor _httpContextAccessor;
        public StudentController(IStudentService studentService, IAccountService accountService, IClassService classService, IHttpContextAccessor httpContextAccessor)
        {
            _studentService = studentService;
            _accountService = accountService;
            _classService = classService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var value = HttpContext.Session.GetString("idrole");
            ViewBag.idrole = Convert.ToInt32(value);
            var data = _studentService.Get();
            return View(data);
        }
        public IActionResult StudentClass()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            var data = _studentService.GetClass();
            return View(data);
        }
        private bool StudentExists(long Id)
        {
            return _studentService.StudentExists(Id);
        }
        [NoDirectAccess]
        //[Authorize(Roles = "Admin")] 
        public IActionResult AddOrEdit(int Id = 0)
        {
            AccountList();
            ClassList();
            if (Id == 0)
            {
                return View(new Student());
            }

            else
            {
                var student = _studentService.GetById(Id);
                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Student model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    try
                    {
                        _studentService.Create(model);
                    }
                    catch(Exception ex)
                    {
                       
                         throw new Exception(ex.Message.ToString());
                    }
                    
                }
                else
                {
                    try
                    {
                        _studentService.Edit(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StudentExists(model.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _studentService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Student model)
        {
            _studentService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _studentService.Get()) });
        }
        private void AccountList(object selectacc = null)
        {
            ViewBag.acc = new SelectList(_accountService.Get(), "Id", "Fullname", selectacc);
        }
        private void ClassList(object selectClass = null)
        {
            ViewBag.cla = new SelectList(_classService.Get(), "Id", "ClassName", selectClass);
        }
    }
}
