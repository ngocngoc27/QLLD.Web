using Microsoft.AspNetCore.Mvc;
using QL_LaoDong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IWorkTickerService _worktickerService;
        private readonly ICalendarService _calendarService;
        private readonly IJobService _jobService;
        public GroupsController(IWorkTickerService worktickerService, ICalendarService calendarService, IJobService jobService)
        {
            _worktickerService = worktickerService;
            _calendarService = calendarService;
            _jobService = jobService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
