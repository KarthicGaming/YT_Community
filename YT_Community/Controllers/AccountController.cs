using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using YT_Community.DBContext;
using YT_Community.Models;
using YT_Community.Models.DTOs;

namespace YT_Community.Controllers
{
    public class AccountController : Controller
    {
        private readonly YoutubeCommunityContext _context;

        public AccountController(YoutubeCommunityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var PasswordHasher = new PasswordHasher<User>();

            var user = new User
            {
                UserId = new Guid(),
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                DateOfBirth = registerDto.DateOfBirth,
                MobileNumber = registerDto.MobileNumber,
                PasswordHash = registerDto.PasswordHash
            };
           // user.PasswordHash = PasswordHasher.HashPassword(user, registerDto.PasswordHash );
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username,string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            if (user != null)
            {
                var passwordHasher = new PasswordHasher<User>();
                var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash,password);
                if (result == PasswordVerificationResult.Success)
                {
                    TempData["Message"] = $"Welcome,{user.UserName}!";
                    return RedirectToAction("Tndex", "VideoLinks");

                }
                
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }
    }
}
