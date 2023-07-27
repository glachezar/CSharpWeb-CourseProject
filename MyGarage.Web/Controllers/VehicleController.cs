namespace MyGarage.Web.Controllers
{
    using MyGarage.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Vehicle;
    using static Common.NotificationsMessagesConstants;



    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService service, ICustomerService customerService)
        {
            _vehicleService = service;
            
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<VehicleViewModel> viewModel =
                await this._vehicleService.AllVehiclesAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool vehicleExist = await _vehicleService.ExistingByIdAsync(id);

            if (!vehicleExist)
            {
                this.TempData[ErrorMessage] = "Vehicle with provided id does not exist!";
                return this.RedirectToAction("All", "Vehicle");
            }

            VehicleDetailsViewModel? viewModel = 
                await this._vehicleService.ViewVehicleDetailsByIdAsync(id);

            

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddVehicleViewModel addVehicle)
        {
            bool notActive = await _vehicleService.IsVehicleSoftDeletedAsync(addVehicle.Vin);
            if (notActive)
            {
                this.TempData[SuccessMessage] = "Vehicle was added successfully!";
                return RedirectToAction("All", "Vehicle");
            }
            if (notActive == false && ModelState.IsValid)
            {

                await _vehicleService.AddVehicleAsync(addVehicle);
                this.TempData[SuccessMessage] = "Vehicle was added successfully!";
                return RedirectToAction("All", "Vehicle");
            }

            return View(addVehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, AddVehicleViewModel formModel)
        {
            bool vehicleExist = await _vehicleService.ExistingByIdAsync(id);

            if (!vehicleExist)
            {
                this.TempData[ErrorMessage] = "Vehicle with provided id does not exist!";
                return this.RedirectToAction("All", "Vehicle");
            }

            try
            {
                await this._vehicleService.EditVehicleByIdAndFormModelAsync(id, formModel);
                this.TempData[SuccessMessage] = "Vehicle edited successfully!";
            }
            catch (Exception )
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occur while trying to update vehicle details, please try again later or contact support!");
                return View(formModel);
            }

            return RedirectToAction("Details", "Vehicle", new{id});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool vehicleExist = await _vehicleService.ExistingByIdAsync(id);

            if (!vehicleExist)
            {
                this.TempData[ErrorMessage] = "Vehicle with provided id does not exist!";
                return this.RedirectToAction("All", "Vehicle");
            }

            AddVehicleViewModel formModel = await this._vehicleService.GetVehicleForEditByIdAsync(id);

            return this.View(formModel);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                this.TempData[ErrorMessage] = "Vehicle with provided id does not exist!";
                return this.RedirectToAction("All", "Vehicle"); 
            }

            return View(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, VehicleDeleteViewModel vehicleDeleteView)
        {
            Guid vehicleId = Guid.Parse(id);
            var isDeleted = await _vehicleService.SoftDeleteVehicleAsync(vehicleId);
            if (!isDeleted)
            {
                this.TempData[ErrorMessage] = "Vehicle with provided id does not exist!";
                return this.RedirectToAction("All", "Vehicle");
            }

            
            this.TempData[SuccessMessage] = "Vehicle successfully deleted!";
            return RedirectToAction("All", "Vehicle");
        }
    }
}
