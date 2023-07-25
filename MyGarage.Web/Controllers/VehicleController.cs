﻿namespace MyGarage.Web.Controllers
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
            if (ModelState.IsValid)
            {
                await _vehicleService.AddVehicleAsync(addVehicle);
                return RedirectToAction("All", "Vehicle");
            }

            return View(addVehicle);
        }

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
    }
}
