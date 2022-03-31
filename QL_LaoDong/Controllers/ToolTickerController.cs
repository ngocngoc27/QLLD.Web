using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_LaoDong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class ToolTickerController : Controller
    {
        private readonly ITooltickerService _tooltickerService;
        public ToolTickerController(ITooltickerService tooltickerService)
        {
            _tooltickerService = tooltickerService;
        }
        public IActionResult PageToolTicker(long id, long CalendarId)
        {
            ViewBag.caid = CalendarId;
            ViewBag.groupID = id;

            ViewBag.grname = _tooltickerService.GetById(id).Groups.GroupsName;
            var data = _tooltickerService.PageToolTicker(id);
            return View(data);
        }

    }
}
