using Language2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Language2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(ILogger<HomeController> logger , IStringLocalizer<HomeController> localizer )
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
           ViewBag.homepage = _localizer["Home Page"];
           ViewBag.welcome = _localizer["Welcome"];
            return View();
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

        public IActionResult IpInfo()
        {
           /* foreach(var item in HttpContext.Request.Headers)
            {
                //item.Key
            }
           */
           ViewBag.headers = HttpContext.Request.Headers;
            return View();
        }
    }
}
