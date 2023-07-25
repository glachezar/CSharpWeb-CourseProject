﻿using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MyGarage.Data;
using MyGarage.Data.Models;
using MyGarage.Services.Data.Interfaces;
using MyGarage.Web.ViewModels.Customer;
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
                    RegistrationNumber = v.RegNumber,
                    Vin = v.Vin,
                    YearManufactured = v.YearManufactured
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

            await _context.Vehicles.AddAsync(newVehicle);
            await _context.SaveChangesAsync();
        }


        public async Task<VehicleDetailsViewModel> ViewVehicleDetailsByIdAsync(string id)
        {
            Vehicle? vehicle = await _context
                .Vehicles
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(v => v.Id.ToString() == id);

            if (vehicle == null)
            {
                return null;
            }

            return new VehicleDetailsViewModel()
            {
                Id = vehicle!.Id.ToString(),
                Make = vehicle.Make,
                Model = vehicle.Model,
                Vin = vehicle.Vin,
                EngineNumber = vehicle.EngineNumber ?? "No Engine Number Provided!",
                RegistrationNumber = vehicle.RegNumber ?? "No Registration Provided!",
                YearManufactured = vehicle.YearManufactured,
                FuelType = vehicle.FuelType ?? "Unknown Fuel Type!",
                Mileage = vehicle.Mileage ?? "Unknown Mileage!",
                VehicleOwner = new CustomerInfoOnVehicleViewModel
                {
                    Id = vehicle.Customer?.Id.ToString() ?? "No Owner Added!",
                    Name = vehicle.Customer?.Name ?? "No Owner Added!",
                    PhoneNumber = vehicle.Customer?.PhoneNumber ?? "No Owner Added!",
                    Email = vehicle.Customer?.Email ?? "No Owner Added!"
                }
            };

            
        }

        public Task<bool> VehicleExistingByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
