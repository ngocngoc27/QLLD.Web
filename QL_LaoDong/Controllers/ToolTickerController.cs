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

namespace QL_LaoDong.Controllers
{
    public class ToolTickerController : Controller
    {
        private readonly ITooltickerService _tooltickerService;
        private readonly IToolService _toolService;
        public ToolTickerController(ITooltickerService tooltickerService, IToolService toolService)
        {
            _tooltickerService = tooltickerService;
            _toolService = toolService;
        }
        public IActionResult PageToolTicker(long id, long CalendarId)
        {
            var value = HttpContext.Session.GetString("idrole");
            ViewBag.idrole = Convert.ToInt32(value);
            ViewBag.caid = CalendarId;
            ViewBag.groupID = id;
            //ViewBag.grname = _tooltickerService.GetById(id).Groups.GroupsName;
            var data = _tooltickerService.PageToolTicker(id);
            return View(data);
        }
        private void ToolList(object selectTool = null)
        {
            ViewBag.tool = new SelectList(_toolService.Get(), "Id", "Tool1", selectTool);
        }
        [NoDirectAccess]
        public IActionResult AddOrEdit(long ids, int id = 0)
        {
            ToolList();
            ViewBag.idgr = ids;
            if (id == 0)
            {
                return View(new Toolticker());
            }
            else
            {
                var data = _tooltickerService.GetById(id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Toolticker model, long ids)
        {
            ViewBag.idgr = ids;
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _tooltickerService.Create(model, ids);
                }
                else
                {
                    try
                    {
                        _tooltickerService.Edit(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TooltickerExists(model.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _tooltickerService.PageToolTicker(ids)) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        private bool TooltickerExists(long id)
        {
            return _tooltickerService.TooltickerExists(id);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Toolticker model, long id)
        {
            ViewBag.idca = id;
            _tooltickerService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _tooltickerService.PageToolTicker(id)) });
        }
    }
}
