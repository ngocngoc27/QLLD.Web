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
        public IActionResult Index()
        {
            var data = _tooltickerService.Get();
            return View(data);
        }

    }
}
