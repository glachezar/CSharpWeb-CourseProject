namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Customer;
    using MyGarage.Services.Data.Interfaces;
    using static Common.NotificationsMessagesConstants;


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
                TempData[SuccessMessage] = "Successfully added new customer!";
                return RedirectToAction("All", "Customer");
            }

            return View(addCustomer);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool customerExist = await _customerService.ExistingByIdAsync(id);

            if (customerExist == false)
            {
                this.TempData[ErrorMessage] = "Customer with provided id does not exist!";
                return this.RedirectToAction("All", "Customer");
            }

            CustomerViewModel? viewModel =
                await this._customerService.ViewCustomerDetailsByIdAsync(id);

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(string id, AddCustomerViewModel formModel)
        {
            bool customerExist = await _customerService.ExistingByIdAsync(id);

            if (!customerExist)
            {
                this.TempData[ErrorMessage] = "Customer with provided id does not exist!";
                return this.RedirectToAction("All", "Customer");
            }

            try
            {
                await this._customerService.EditCustomerByIdAndFormModelAsync(id, formModel);
                this.TempData[SuccessMessage] = "Customer details edited successfully!";
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occur while trying to update customer details, please try again later or contact support!");
                return View(formModel);
            }

            return RedirectToAction("Details", "Customer", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool customerExist = await _customerService.ExistingByIdAsync(id);

            if (!customerExist)
            {
                this.TempData[ErrorMessage] = "Customer with provided id does not exist!";
                return this.RedirectToAction("All", "Customer");
            }

            AddCustomerViewModel formModel = await this._customerService.GetCustomerForEditByIdAsync(id);

            return this.View(formModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                this.TempData[ErrorMessage] = "Customer with provided id does not exist!";
                return this.RedirectToAction("All", "Customer");
            }

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, CustomerViewModel customerDeleteView)
        {
            var isDeleted = await _customerService.DeleteCustomerByIdAsync(id);
            if (isDeleted == false)
            {
                this.TempData[ErrorMessage] = "Customer with provided id does not exist!";
                return this.RedirectToAction("All", "Customer");
            }


            this.TempData[SuccessMessage] = "Customer successfully deleted!";
            return RedirectToAction("All", "Customer");
        }
    }
}
