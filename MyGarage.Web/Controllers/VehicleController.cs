namespace MyGarage.Web.Controllers
{
    using Infrastructure.Extensions;
    using MyGarage.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Vehicle;
    using static Common.NotificationsMessagesConstants;



    [Authorize]
    public class VehicleController : Controller
    {

        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService service)
        {
            _vehicleService = service;

            
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<VehicleViewModel> viewModel =
                await this._vehicleService.AllVehiclesByUserIdAsync(this.User.GetUserId()!);

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
            var vehicle = await _vehicleService.GetVehicleToRemoveOwnerByIdAsync(id);
            var isOwnerRemoved = await _vehicleService.RemoveOwnerFromVehicleByIdAsync(vehicle);
            var isDeleted = await _vehicleService.SoftDeleteVehicleAsync(vehicleId);
            if (!isDeleted)
            {
                this.TempData[ErrorMessage] = "Vehicle with provided id does not exist!";
                return this.RedirectToAction("All", "Vehicle");
            }
            if (isOwnerRemoved == false)
            {
                this.TempData[ErrorMessage] = "Something went wrong while trying to delete your vehicle, please try again later or contact administrator!";
                return this.RedirectToAction("All", "Vehicle");
            }

            
            this.TempData[SuccessMessage] = "Vehicle successfully deleted!";
            return RedirectToAction("All", "Vehicle");
        }

    }
}
