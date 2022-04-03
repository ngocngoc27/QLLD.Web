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
            ViewBag.ds = _workTickerService.CountsDS();
            ViewBag.daduyet = _workTickerService.CountTT();
            ViewBag.baoban = _workTickerService.CountBan();
            ViewBag.choduyet = _workTickerService.Choduyet();
            ViewBag.hoanthanh = _classService.CountHoanthanh();
            ViewBag.chuahoanthanh = _classService.CountChuaHT();
            ViewBag.chuaxet = _classService.CountChuaxet();
            ViewBag.lop = _classService.CountClass();
            ViewBag.chuasv = _groupsService.CountChuaSV();
            ViewBag.chuadiemdanh = _groupsService.CountChuaDiemdanh();
            ViewBag.sonhom = _groupsService.CountGr();
            return View();
        }
        public IActionResult IndexUser()
        {
            ViewBag.usename = HttpContext.Session.GetString("user");
            ViewBag.typeedu = HttpContext.Session.GetString("typeofedu");
            var numw = HttpContext.Session.GetString("numberwork");
            ViewBag.numwork = numw;
            ViewBag.soluongphieudk = _workTickerService.CountDSDK();
            ViewBag.choduyet = _workTickerService.CountCho();
            ViewBag.duyet = _workTickerService.CountDuyet();
            ViewBag.baoban = _workTickerService.CountbBan();
            ViewBag.huy = _workTickerService.CountHuy();
            ViewBag.chuahoanthanh = _studentService.countChuaHT();
            ViewBag.saphoanthanh = _studentService.coutSapHT();
            ViewBag.hoanthanh = _studentService.countHT();
            ViewBag.ngayldclass = _classService.countTotalLD();
            return View();
        }

    }
}
