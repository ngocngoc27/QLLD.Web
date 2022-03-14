using Microsoft.AspNetCore.Authorization;
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
    public class MenusController : Controller
    {
        private readonly IMenusService _menusService;
        private readonly IAccountService _accountService;
        public MenusController(IMenusService menusService, IAccountService accountService)
        {
            this._menusService = menusService;
            this._accountService = accountService;
        }
        public IActionResult Index()
        {
            var data = _menusService.Get();
            return View(data);
        }
        private bool MenuExists(long IdMn)
        {
            return _menusService.MenusExists(IdMn);
        }
        [NoDirectAccess]
        //[Authorize(Roles = "Admin")] 
        public IActionResult AddOrEdit(int IdMn = 0)
        {
            UserList();
            ParentList();
            if (IdMn == 0)
            {
                return View(new Menus());
            }

            else
            {
                var menus = _menusService.GetById(IdMn);
                if (menus == null)
                {
                    return NotFound();
                }
                return View(menus);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Menus model, int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {

                    _menusService.Create(model);
                }
                else
                {
                    try
                    {
                        _menusService.Edit(model, id);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MenuExists(model.IdMn))
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
        public IActionResult DeleteConfirmed( int id)
        {
            _menusService.Delete(id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _menusService.Get()) });
        }
        private void UserList(object selectUser = null)
        {
            ViewBag.user = new SelectList(_accountService.Get(), "Id", "Username", selectUser);
        }
        private void ParentList(object selectParent = null)
        {
            ViewBag.parent = new SelectList(_menusService.Get(), "IdMn", "Label", selectParent);
        }

    }
}
