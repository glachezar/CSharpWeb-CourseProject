namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyGarage.Services.Data.Interfaces;
    using Data;
    using Data.Models;
    using ViewModels.Customer;

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICustomerService _customerService;
        private readonly MyGarageDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, ICustomerService customerService,
            MyGarageDbContext context)
        {
            _userManager = userManager;
            _customerService = customerService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Register the new user
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Check if the email exists in the Customers table
                    var customer = await _customerService.GetCustomerByEmailAsync(model.Email);
                    if (customer != null)
                    {
                        // Connect the user and customer with a one-to-one relationship
                        user.Customer = customer;
                        await _context.SaveChangesAsync();
                    }

                    // Redirect to the appropriate page after registration
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }

}

