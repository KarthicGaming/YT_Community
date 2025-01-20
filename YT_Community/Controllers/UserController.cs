using Microsoft.AspNetCore.Mvc;
using YT_Community.Repository;

namespace YT_Community.Controllers
{
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
    }
}
