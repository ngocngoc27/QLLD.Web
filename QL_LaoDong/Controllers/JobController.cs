using Microsoft.AspNetCore.Mvc;
using QL_LaoDong.Interfaces;
using QL_LaoDong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        public IActionResult Index()
        {
            var job = _jobService.Get();
            return View(job);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Job model)
        {
            _jobService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            //RoleList();
            var job = _jobService.GetById(id);
            return View(job);
        }
        [HttpPost]
        public IActionResult Edit(Job model)
        {
            _jobService.Edit(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Lock(Job model, int id)
        {
            var job = _jobService.GetById(id);
            _jobService.Lock(job);
            return RedirectToAction(nameof(Index));
        }
    }
}
