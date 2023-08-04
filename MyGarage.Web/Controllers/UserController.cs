namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static Common.NotificationsMessagesConstants;
    using ViewModels.User;
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
        public async Task<IActionResult> Register(RegisterFormModel user)
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

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel formModel = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };
            return this.View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            var result =
                await this._signInManager.PasswordSignInAsync(formModel.Email, 
                formModel.Password, formModel.RememberMe, false);

            if (!result.Succeeded)
            {
                this.TempData[ErrorMessage] = "There was an error while logging you in, please try again later or contact support!";
                return this.View(formModel);
            }

            return this.Redirect(formModel.ReturnUrl ?? "/Home/Index");
        }
    }
}
