using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_LaoDong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkTickerService _workTickerService;
        private readonly IClassService _classService;
        private readonly IGroupsService _groupsService;
        private readonly IStudentService _studentService;
        public HomeController(IWorkTickerService workTickerService, IClassService classService, IGroupsService groupsService, IStudentService studentService)
        {
            _workTickerService = workTickerService;
            _classService = classService;
            _groupsService = groupsService;
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            ViewBag.usename = HttpContext.Session.GetString("user"); 
            ViewBag.role = HttpContext.Session.GetString("rolename");
            var data= HttpContext.Session.GetString("idrole");
            ViewBag.idrole = Convert.ToInt32(data);

            ViewBag.ds = _workTickerService.CountsDS();
            ViewBag.daduyet = _workTickerService.CountTT();
            ViewBag.baoban = _workTickerService.CountBan();
            ViewBag.choduyet = _workTickerService.Choduyet();
            ViewBag.hoanthanh = _classService.CountHoanthanh();
            ViewBag.chuahoanthanh = _classService.CountChuaHT();
            ViewBag.chuaxet = _classService.CountChuaxet();
            ViewBag.lop = _classService.CountClass();
            ViewBag.chuasv = _groupsService.CountGrChuaSV();
            ViewBag.chuadd = _groupsService.CountGrChuaDD();
            ViewBag.sogr = _groupsService.CountGr();
            return View();
        }
        public IActionResult IndexUser()
        {
            var totalw = HttpContext.Session.GetString("typeofedu");
            ViewBag.usename = HttpContext.Session.GetString("user");
            ViewBag.totalwork = "";
            if (totalw=="Đại học")
            {
                ViewBag.totalwork = 18;
            }
            else if(totalw=="Cao đẳng")
            {
                ViewBag.totalwork = 12;
            }
            var numw = HttpContext.Session.GetString("numberwork");
            ViewBag.numwork = numw;
            ViewBag.ngayld = _classService.CountNgayLD();
            ViewBag.sodk = _workTickerService.CountDK();
            ViewBag.duyet = _workTickerService.CountDuyet();
            ViewBag.cho = _workTickerService.CountCho();
            ViewBag.huy = _workTickerService.CountHuy();
            ViewBag.ban = _workTickerService.CountBban();
            ViewBag.hoanthanh = _studentService.CountHT();
            ViewBag.sap = _studentService.CountSap();
            ViewBag.chua = _studentService.CountChua();
            ViewBag.ngayldlop = _studentService.CountLDClass();
            return View();
        }

    }
}
