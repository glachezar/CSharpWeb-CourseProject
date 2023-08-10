namespace MyGarage.Web.Areas.Admin.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    using MyGarage.Services.Data.Interfaces;
    using ViewModels.Vehicle;

    using static Common.NotificationsMessagesConstants;



    public class VehicleController : BaseAdminController
    {
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService service, ICustomerService customerService)
        {
            _vehicleService = service;
            _customerService = customerService;
            
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
        public async Task<IActionResult> Add()
        {
            AddVehicleViewModel formModel = new AddVehicleViewModel();
            formModel.Owner = await _customerService.AllCustomersForSelectFormModelAsync();

            return View(formModel);
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
            if (notActive == false && !ModelState.IsValid)
            {
                
                await _vehicleService.AddVehicleAsync(addVehicle);
                this.TempData[SuccessMessage] = "Vehicle was added successfully!";
                return RedirectToAction("All", "Vehicle");
            }
            else
            {
                addVehicle.Owner = await _customerService.AllCustomersForSelectFormModelAsync();
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
        public async Task<IActionResult> Delete(string id, AddVehicleViewModel vehicleDeleteView)
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

        [HttpGet]
        public async Task<IActionResult> AddOwner(string id)
        {
            AddVehicleViewModel formModel = await this._vehicleService.GetVehicleForEditByIdAsync(id);
 
            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOwner(string id, AddVehicleViewModel vehicleViewModel)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);

            if (vehicle == null)
            {
                TempData[ErrorMessage] = "No Vehicle with Provided Id!";
            }

            await _vehicleService.AddOwnerToVehicleByIdAsync(vehicle!.Id, vehicleViewModel);
            TempData[SuccessMessage] = "Successfully added owner to vehicle!";
            return RedirectToAction("Details", "Vehicle", new{vehicle.Id});
        }

        [HttpGet]
        public async Task<IActionResult> RemoveOwner(string id)
        {

            var vehicle = await _vehicleService.GetVehicleToRemoveOwnerByIdAsync(id);
            if (vehicle == null)
            {
                TempData[ErrorMessage] = "Vehicle with provided Id do not exist!";
                return RedirectToAction("All", "Vehicle");
            }

            return View(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveOwner(RemoveOwnerFormModel vehicle, string id)
        {
            var isOwnerDeleted = await _vehicleService.RemoveOwnerFromVehicleByIdAsync(vehicle);

            if (isOwnerDeleted)
            {
                TempData[SuccessMessage] = "Vehicle owner have been removed from vehicle!";
                return this.RedirectToAction("Details", "Vehicle", new{vehicle.Id});
            }

            TempData[ErrorMessage] = "Something went wrong please try again later or contact support!";
            return this.RedirectToAction("All", "Vehicle");
        }
    }
}
