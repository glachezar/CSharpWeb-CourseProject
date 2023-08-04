using MyGarage.Web.ViewModels.User;

namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Data.Models;


    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public UserController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserFormModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            await this._userManager.SetEmailAsync(newUser, user.Email);
            await this._userManager.SetUserNameAsync(newUser, user.Email);

            IdentityResult result = 
                await this._userManager.CreateAsync(newUser, user.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            await this._signInManager.SignInAsync(newUser, false);
            return RedirectToAction("Index", "Home");
        }
    }
}
