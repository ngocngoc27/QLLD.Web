using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QL_LaoDong.Helpers;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static QL_LaoDong.Helpers.Helper;

namespace QL_LaoDong.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _AccountService;
        private readonly IRoleService _RoleService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService, IRoleService roleService)
        {
            _logger = logger;
            this._AccountService = accountService;
            this._RoleService = roleService;
        }
       
        public IActionResult Index()
        {
            var data = _AccountService.Get();
            return View(data);
        }
    
        [HttpGet]
        public IActionResult Lock(Account model, int id)
        {
            var ac = _AccountService.GetById(id);
            _AccountService.Lock(ac);
            return RedirectToAction(nameof(Index));
        }
        private void RoleList(object selectRole = null)
        {
            ViewBag.roles = new SelectList(_RoleService.Get(), "Id", "NameRole", selectRole);
        }

        private bool AccExists(long id)
        {
            return _AccountService.AccountExists(id);
        }
        [NoDirectAccess]
        //[Authorize(Roles = "Admin")]
        public IActionResult AddOrEdit(int id = 0)
        {
            RoleList();
            if (id == 0)
            {
                return View(new Account());
            }

            else
            {
                var Acc = _AccountService.GetById(id);
                if (Acc == null)
                {
                    return NotFound();
                }
                return View(Acc);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult AddOrEdit(Account model)
        {

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                   
                    _AccountService.Create(model);
                }
                else
                {
                    try
                    {
                        _AccountService.Edit(model);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AccExists(model.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Json(new { IsValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _AccountService.Get()) });
            }
            return Json(new { IsValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Account model)
        {
            _AccountService.Delete(model);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _AccountService.Get()) });
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Account model)
        {
            if (ModelState.IsValid)
            {
                var user = _AccountService.Login(model);
                if (user != null)
                {
                    //A claim is a statement about a subject by an issuer and    
                    //represent attributes of the subject that are useful in the context of authentication and authorization operations.
                    var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role.NameRole),
                    };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Invalid Credential";
                    return View(user);
                }
               
            }
            return View();
            
        }
    }
}
