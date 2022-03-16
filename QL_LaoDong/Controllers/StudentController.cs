using Microsoft.AspNetCore.Mvc;
using QL_LaoDong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IAccountService _accountService;
        public StudentController(IStudentService studentService, IAccountService accountService)
        {
            _studentService = studentService;
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            var data = _studentService.Get();
            return View(data);
        }
    }
}
