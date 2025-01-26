using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YT_Community.DBContext;
using YT_Community.Models;
using YT_Community.Models.ModelView;
using YT_Community.Repository;

namespace YT_Community.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class VideoLinksController : Controller
    {
        private readonly IVideoLinksRespository videoLinksRespository;

        public IUserRepository UserRepository { get; }

        public VideoLinksController(IVideoLinksRespository videoLinksRespository, IUserRepository userRepository)
        {
            this.videoLinksRespository = videoLinksRespository;
            UserRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var result = videoLinksRespository.GetAll(includeProperties: "User").Result;
            return View(result);
        }

        public async Task<IActionResult> Edit(Guid? guid)
        {
            if (guid == null)
            {
                return NotFound();
            }
            var user = await videoLinksRespository.GetById(guid);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(VideoLink videoLink)
        {
            if (ModelState.IsValid)
            {
                videoLinksRespository.UpdateLink(videoLink);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(Guid? guid)
        {
            if (guid == null)
            {
                return NotFound();
            }
            var user = await videoLinksRespository.GetById(guid);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(VideoLink videoLink)
        {
            if (videoLink != null && ModelState.IsValid)
            {
                videoLinksRespository.DeleteLink(videoLink);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> userList = UserRepository.GetAll().Result.
                Select(x => new SelectListItem
                {
                Value = x.UserId.ToString(),
                Text = x.UserName
                });

            VideoLinkView videoLinkView = new VideoLinkView
            {
                UserList = userList,
                videoLink = new VideoLink()
            };
            return View(videoLinkView);
        }
        [HttpPost]
        public IActionResult Create(VideoLinkView videoLinkView)
        {
            videoLinkView.videoLink.PostedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                videoLinksRespository.CreateLink(videoLinkView.videoLink);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
