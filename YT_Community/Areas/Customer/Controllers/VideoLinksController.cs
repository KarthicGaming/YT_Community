using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YT_Community.DBContext;

namespace YT_Community.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class VideoLinksController : Controller
    {
        private readonly YoutubeCommunityContext _context;

        public VideoLinksController(YoutubeCommunityContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.VideoLinks.ToListAsync());
        }

    }
}
