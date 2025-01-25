using Microsoft.AspNetCore.Mvc;
using YT_Community.Models;
using YT_Community.Models.ModelView;
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
            return View(userRepository.GetAll().Result.ToList());
        }

        public async Task<IActionResult> Edit(Guid? guid)
        {
            if(guid == null)
            {
                return NotFound();
            }
            var user = await userRepository.GetById(guid);

            if (user == null)
            {
                return NotFound();
            }
            var ViewUser = new UserViewModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                DateOfBirth = user.DateOfBirth,
                MobileNumber = user.MobileNumber,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };
            return View(ViewUser);
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var ViewUser = new User
                {
                    UserName = user.UserName,
                    DateOfBirth = user.DateOfBirth,
                    MobileNumber = user.MobileNumber,
                    Email = user.Email,
                };
                userRepository.UpdateUser(ViewUser);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Create()
        {
            return View(userRepository.GetAll().Result.ToList());
        }
        public IActionResult Delete()
        {
            return View(userRepository.GetAll().Result.ToList());
        }
    }
}
