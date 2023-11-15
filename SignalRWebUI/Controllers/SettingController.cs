using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto();
            userEditDto.Surname = values.Surname;
            userEditDto.Name = values.Name;
            userEditDto.UserName = values.UserName;
            userEditDto.Mail = values.Email;
            return View(userEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (userEditDto.ConfrmPwd == userEditDto.Password)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Surname = userEditDto.Surname;
                user.Name = userEditDto.Name;
                user.UserName = userEditDto.UserName;
                user.Email = userEditDto.Mail;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,userEditDto.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Setting");
            }
            return View();
        }
    }
}
