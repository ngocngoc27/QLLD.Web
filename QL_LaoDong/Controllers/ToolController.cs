using Microsoft.AspNetCore.Mvc;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class ToolController : Controller
    {
        private readonly IToolService _ToolService;
        public ToolController(IToolService toolService)
        {
            _ToolService = toolService;
        }
        public IActionResult Index()
        {
            var data = _ToolService.Get();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tool model)
        {

            _ToolService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var data = _ToolService.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Tool model)
        {
            _ToolService.Edit(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Lock(Tool model, int id)
        {
            var data = _ToolService.GetById(id);
            _ToolService.Lock(data);
            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
