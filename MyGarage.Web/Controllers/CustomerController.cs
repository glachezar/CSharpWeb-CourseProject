namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Customer;
    using MyGarage.Services.Data.Interfaces;
    using MyGarage.Services.Data;


    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<CustomerViewModel> viewModel =
                await this._customerService.AllCustomersAsync();

            return View(viewModel);
        }

        public Task<IActionResult> Details()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerViewModel addCustomer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddCustomerAsync(addCustomer);
                return RedirectToAction("All", "Customer");
            }

            return View(addCustomer);
        }
    }
}
