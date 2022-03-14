using Microsoft.AspNetCore.Authorization;
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
    public class MenusController : Controller
    {
        private readonly IMenusService _menusService;
        public MenusController(IMenusService menusService)
        {
            _menusService = menusService;
        }
        public IActionResult Index()
        {
            var data = _menusService.Get();
            return View(data);
        }
        private bool MenusExists(long id)
        {
            return _menusService.MenusExists(id);
        }
        [NoDirectAccess]
        //[Authorize(Roles = "Admin")]
        public IActionResult AddOrEdit(int id = 0)
        {
            //RoleList();
            if (id == 0)
            {
                return View(new Menus());
            }

            else
            {
                var Data = _menusService.GetById(id);
                if (Data == null)
                {
                    return NotFound();
                }
                return View(Data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Menus model)
        {

            if (ModelState.IsValid)
            {
                if (model.IdMn == 0)
                {

                    _menusService.Create(model);
                }
                else
                {
                    try
                    {
                        _menusService.Edit(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MenusExists(model.IdMn))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _menusService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Menus model)
        {
            _menusService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _menusService.Get()) });
        }
    }
}
