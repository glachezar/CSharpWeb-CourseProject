namespace MyGarage.Web.Controllers
{
    using Infrastructure.Extensions;
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
        public async Task<IActionResult> Details()
        {
            bool customerExist = await _customerService.ExistingByUserIdAsync(this.User.GetUserId()!);

            if (customerExist == false)
            {
                this.TempData[ErrorMessage] = "Something went wrong please try again later or contact our garage employee for assistance!";
                return this.RedirectToAction("Index", "Home");
            }

            CustomerDetailsViewModel? viewModel =
                await this._customerService.GetCustomerDetailsByUserIdAsync(this.User.GetUserId()!);

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(string id, AddCustomerViewModel formModel)
        {
            bool customerExist = await _customerService.ExistingByIdAsync(id);

            if (!customerExist)
            {
                this.TempData[ErrorMessage] = "Customer with provided id does not exist!";
                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                await this._customerService.EditCustomerByIdAndFormModelAsync(id, formModel);
                this.TempData[SuccessMessage] = "Successfully edited your details!";
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occur while trying to update your details, please try again later or contact administrator!");
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
                this.TempData[ErrorMessage] = "Something went wrong, please try again later or contact administrator!";
                return this.RedirectToAction("Index", "Home");
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
