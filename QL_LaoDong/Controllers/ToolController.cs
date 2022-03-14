using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_LaoDong.Helpers;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static QL_LaoDong.Helpers.Helper;

namespace QL_LaoDong.Controllers
{
    public class ToolController : Controller
    {
        private readonly IToolService _toolService;
        public ToolController(IToolService toolService)
        {
            _toolService = toolService;
        }
        public IActionResult Index()
        {
            var data = _toolService.Get();
            return View(data);
        }
        private bool ToolExists(long id)
        {
            return _toolService.ToolExists(id);
        }
        [NoDirectAccess]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Tool());
            }
            else
            {
                var data = _toolService.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Tool model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _toolService.Create(model);
                }
                else
                {
                    try
                    {
                        _toolService.Edit(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ToolExists(model.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _toolService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Tool model)
        {
            _toolService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _toolService.Get()) });
        }
        [HttpGet]
        public IActionResult Lock(Tool model, int id)
        {
            var data = _toolService.GetById(id);
            _toolService.Lock(data);
            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
