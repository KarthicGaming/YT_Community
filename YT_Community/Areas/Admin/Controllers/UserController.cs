using Microsoft.AspNetCore.Mvc;
using YT_Community.Models;
using YT_Community.Repository;

namespace YT_Community.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(userRepository.GetAll().Result);
        }

        public async Task<IActionResult> Edit(Guid? guid)
        {
            if (guid == null)
            {
                return NotFound();
            }
            var user = await userRepository.GetById(guid);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.UpdateUser(user);
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
            var user = await userRepository.GetById(guid);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(User user)
        {
            if (user != null && ModelState.IsValid)
            {
                userRepository.DeleteUser(user);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
