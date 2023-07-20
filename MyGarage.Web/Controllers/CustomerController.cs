namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Customer;
    using MyGarage.Services.Data.Interfaces;


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
    }
}
