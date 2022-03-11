using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Create()
        {
            RoleList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Account model)
        {

             _AccountService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            RoleList();
            var acc = _AccountService.GetById(id);
            return View(acc);
        }
        [HttpPost]
        public IActionResult Edit(Account model)
        {
            _AccountService.Edit(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Lock(Account model, int id)
        {
            var ac = _AccountService.GetById(id);
            _AccountService.Lock(ac);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void RoleList(object selectRole = null)
        {
            ViewBag.roles = new SelectList(_RoleService.Get(), "Id", "NameRole", selectRole);
        }
        [HttpGet]
        public IActionResult Delete(Account model, int id)
        {
            var ac = _AccountService.GetById(id);
            _AccountService.Delete(ac);
            return RedirectToAction(nameof(Index));
        }


    }
}
