namespace MyGarage.Web.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyGarage.Services.Data.Interfaces;
using ViewModels.User;
using Data.Models;
using Griesoft.AspNetCore.ReCaptcha;
using Microsoft.Extensions.Caching.Memory;
using static Common.NotificationsMessagesConstants;
using static Common.GeneralApplicationConstants;

public class UserController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly ICustomerService _customerService;
    private readonly IUserService _userService;
    private readonly IMemoryCache _memoryCache;

    public UserController(SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore,
        ICustomerService customerService, IUserService userService, IMemoryCache memoryCache)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _userStore = userStore;
        _customerService = customerService;
        _userService = userService;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateRecaptcha(Action = nameof(Register),
    ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
    public async Task<IActionResult> Register(RegisterFormModel user)
    {
        //bool customerExist = await _customerService.CustomerExistByEmailAsync(user.Email);

        if (!ModelState.IsValid)
        {
            return View(user);
        }

        //if (customerExist == false)
        //{
        //    TempData[ErrorMessage] = "Your email is not in our database," +
        //                             " please ask our garage employee register you as customer first and try again!";
        //    return this.View(user);
        //}

        ApplicationUser newUser = await _userService.CreateUserByFormModelAsync(user);

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

            return View(user);
        }

        await this._signInManager.SignInAsync(newUser, false);
        this._memoryCache.Remove(UsersCacheKey);
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