using MyGarage.Services.Data.Interfaces;

namespace MyGarage.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Vehicle;



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
                await this._vehicleService.AllVehiclesAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            VehicleDetailsViewModel viewModel = 
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
            if (ModelState.IsValid)
            {
                await _vehicleService.AddVehicleAsync(addVehicle);
                return RedirectToAction("All", "Vehicle");
            }

            return View(addVehicle);
        }
    }
}
