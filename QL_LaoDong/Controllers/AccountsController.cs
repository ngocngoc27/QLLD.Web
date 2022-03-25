using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
using System.IO;

namespace QL_LaoDong.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _AccountService;
        private readonly IRoleService _RoleService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AccountsController(ILogger<AccountsController> logger, IAccountService accountService, IRoleService roleService, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            this._AccountService = accountService;
            this._RoleService = roleService;
            this._hostEnvironment = hostEnvironment;
        }
       
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
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
                        new Claim(ClaimTypes.Role, user.RoleName),
                    };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("user", user.Username);
                    HttpContext.Session.SetString("id",user.AccountId.ToString());
                    HttpContext.Session.SetString("username",user.Username);
                    HttpContext.Session.SetString("classname",user.ClassName);
                    HttpContext.Session.SetString("idclass", user.ClassId.ToString());
                    HttpContext.Session.SetString("total", user.Total.ToString());

                    return RedirectToAction(nameof(Index),"Home");
                }
                else
                {
                    ViewBag.Message = "Invalid Credential";
                    return View(user);
                }
               
            }
            return View();
            
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Accounts");
        }
        public IActionResult Details()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("id"));
            var data = _AccountService.Details(id);
            return View(data);
        }
    }
}
