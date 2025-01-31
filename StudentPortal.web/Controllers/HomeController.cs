using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.web.Log;
using StudentPortal.web.Models;

namespace StudentPortal.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggingService _logger;

        public HomeController(ILoggingService logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInfo("Home page loaded");
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
    }
}
