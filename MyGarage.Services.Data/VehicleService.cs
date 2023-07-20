using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MyGarage.Data;
using MyGarage.Data.Models;
using MyGarage.Services.Data.Interfaces;
using MyGarage.Web.ViewModels.Vehicle;

namespace MyGarage.Services.Data
{


    public class VehicleService : IVehicleService
    {
        private readonly MyGarageDbContext _context;

        public VehicleService(MyGarageDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<VehicleViewModel>> AllVehiclesAsync()
        {
            IEnumerable<VehicleViewModel> viewAllVehicles = await _context
                .Vehicles
                .AsNoTracking()
                .Select(v => new VehicleViewModel()
                {
                    Id = v.Id.ToString(),
                    Make = v.Make,
                    Model = v.Model,
                    YearManufactured = v.YearManufactured,
                    Vin = v.Vin
                })
                .ToArrayAsync();

            return viewAllVehicles;
        }


        public async Task AddVehicleAsync(AddVehicleViewModel vehicleViewModel)
        {
            Vehicle newVehicle = new Vehicle()
            {
                Make = vehicleViewModel.Make,
                Model = vehicleViewModel.Model,
                Vin = vehicleViewModel.Vin,
                EngineNumber = vehicleViewModel.EngineNumber ?? "N/A",
                RegNumber = vehicleViewModel.RegNumber ?? "N/A",
                YearManufactured = vehicleViewModel.YearManufactured,
                FuelType = vehicleViewModel.FuelType,
                Mileage = vehicleViewModel.Mileage ?? "No Record"
            };

            _context.Vehicles.Add(newVehicle);
            await _context.SaveChangesAsync();
        }


        public async Task<VehicleDetailsViewModel> ViewVehicleDetailsByIdAsync(string id)
        {
            Vehicle? vehicle = await _context
                .Vehicles
                .FirstOrDefaultAsync(v => v.Id.ToString() == id);

            VehicleDetailsViewModel model = new VehicleDetailsViewModel()
            {
                Id = vehicle!.Id.ToString(),
                Make = vehicle.Make,
                Model = vehicle.Model,
                Vin = vehicle.Vin,
                EngineNumber = vehicle.EngineNumber ?? "Unknown Engine Number!",
                RegNumber = vehicle.RegNumber ?? "No Registration Provided!",
                YearManufactured = vehicle.YearManufactured,
                FuelType = vehicle.FuelType ?? "Unknown Fuel Type!",
                Mileage = vehicle.Mileage ?? "Unknown Mileage!"
            };

            return model;
        }

        public Task<bool> VehicleExistingByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
