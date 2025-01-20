using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YT_Community.DBContext;
using YT_Community.Models;

namespace YT_Community.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly YoutubeCommunityContext _context;
        public HomeController(ILogger<HomeController> logger, YoutubeCommunityContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            int count = 0;
            count = _context.VideoLinks.ToList().Count;
            TempData["data"] = count;
            
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
