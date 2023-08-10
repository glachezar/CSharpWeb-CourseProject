namespace MyGarage.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using MyGarage.Data;
    using MyGarage.Data.Models;
    using Web.ViewModels.Customer;
    using Web.ViewModels.JobCard;
    using Web.ViewModels.Mechanic;
    using Web.ViewModels.Vehicle;



    public class VehicleService : IVehicleService
    {
        private readonly MyGarageDbContext _context;
        private readonly ICustomerService _customerService;

        public VehicleService(MyGarageDbContext dbContext, ICustomerService customerService)
        {
            _context = dbContext;
            _customerService = customerService;
        }

        public async Task<IEnumerable<VehicleViewModel>> AllVehiclesAsync()
        {
            IEnumerable<VehicleViewModel> viewAllVehicles = await _context
                .Vehicles
                .Where(v => v.IsActive == true)
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

        public async Task<IEnumerable<JobCardVehicleSelectFormModel>> AllVehiclesForFormModelAsync()
        {
            IEnumerable<JobCardVehicleSelectFormModel> viewAllVehicles = await _context
                .Vehicles
                .Where(v => v.IsActive == true)
                .AsNoTracking()
                .Select(v => new JobCardVehicleSelectFormModel()
                {
                    Id = v.Id.ToString(),
                    Make = v.Make,
                    Model = v.Model,
                    Vin = v.Vin,
                    
                })
                .ToArrayAsync();

            return viewAllVehicles;
        }

        


        public async Task AddVehicleAsync(AddVehicleViewModel vehicleViewModel)
        {
            Vehicle? inactiveVehicleCheck = await _context
                .Vehicles
                .Where(v => v.IsActive == false)
                .FirstOrDefaultAsync(v => v.Vin == vehicleViewModel.Vin);
            Customer? owner = await _context
                .Customers
                .FirstOrDefaultAsync(c => c.Id.ToString() == vehicleViewModel.CustomerId);

            if (inactiveVehicleCheck != null)
            {
                inactiveVehicleCheck.IsActive = true;
                await _context.SaveChangesAsync();
            }
            else
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

                if (vehicleViewModel.CustomerId != null && owner != null)
                {
                    newVehicle.CustomerId = Guid.Parse(vehicleViewModel.CustomerId);
                    newVehicle.Customer = owner;
                }
                await _context.Vehicles.AddAsync(newVehicle);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task AddOwnerToVehicleByIdAsync(string id, AddVehicleViewModel vehicleViewModel)
        {
            var vehicle = await _context
                .Vehicles
                .Where(v => v.IsActive == true)
                .FirstOrDefaultAsync(v => v.Id.ToString() == id);

            vehicle!.CustomerId = Guid.Parse(vehicleViewModel.CustomerId!);

            await _context.SaveChangesAsync();
        }

        public async Task<RemoveOwnerFormModel> GetVehicleToRemoveOwnerByIdAsync(string id)
        {

            Vehicle? vehicle = await _context
                .Vehicles
                .Where(v => v.IsActive == true)
                .FirstOrDefaultAsync(v => v.Id.ToString() == id);

            if (vehicle == null)
            {
                return null;
            }

            RemoveOwnerFormModel model = new RemoveOwnerFormModel()
            {
                Id = vehicle.Id.ToString(),
                Make = vehicle.Make,
                Model = vehicle.Model,
                Vin = vehicle.Vin,
                CustomerId = vehicle.CustomerId.ToString(),
            };

            return model;
        }

        public async Task<bool> RemoveOwnerFromVehicleByIdAsync(RemoveOwnerFormModel model)
        {
            string vehicleId = model.Id;

            var vehicleToRemoveOwner = await _context
                .Vehicles
                .Where(v => v.IsActive == true)
                .FirstOrDefaultAsync(v => v.Id.ToString() == vehicleId);

            if (vehicleToRemoveOwner != null)
            {
                vehicleToRemoveOwner.CustomerId = null;
                vehicleToRemoveOwner.Customer = null;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> IsVehicleSoftDeletedAsync(string vin)
        {
            Vehicle? isVehicleNotActive = await _context
                .Vehicles
                .Where(v => v.IsActive == false)
                .FirstOrDefaultAsync(v => v.Vin == vin);

            if (isVehicleNotActive == null)
            {
                return false;
            }

            isVehicleNotActive.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<VehicleDetailsViewModel> ViewVehicleDetailsByIdAsync(string id)
        {
            Vehicle? vehicle = await _context
                .Vehicles
                .Where(v => v.IsActive == true)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(v => v.Id.ToString() == id);

            IEnumerable<JobCardToVehicleViewModel>? cards = await _context
                .JobCards
                .Where(jc => jc.VehicleId.ToString() == id)
                .Select(jc => new JobCardToVehicleViewModel()
                {
                    Id = jc.Id.ToString(),
                    CreatedOn = jc.CreatedOn.ToString("d"),
                    Mileage = jc.Mileage,
                    Mechanic = new JobCardMechanicFormModel()
                    {
                        
                        Name = jc.Mechanic!.Name,
                        LastName = jc.Mechanic.Surname
                    }
                })
                .ToArrayAsync();

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
                    Id = vehicle.Customer?.Id.ToString(),
                    Name = vehicle.Customer?.Name,
                    PhoneNumber = vehicle.Customer?.PhoneNumber,
                    Email = vehicle.Customer?.Email 
                },
                JobCards = cards
            };

        }

        public async Task<bool> ExistingByIdAsync(string id)
        {
            bool result = await _context
                .Vehicles
                .Where(v => v.IsActive == true)
                .AnyAsync(v => v.Id.ToString() == id);

            return result;
        }

        public async Task<VehicleDeleteViewModel> GetVehicleByIdAsync(string id)
        {
            Guid vId = Guid.Parse(id);
            var vehicle = await _context.Vehicles.FindAsync(vId);

            VehicleDeleteViewModel result = new VehicleDeleteViewModel
            {
                Id = vehicle.Id.ToString(),
                Make = vehicle.Make,
                Model = vehicle.Model,
                Vin = vehicle.Vin
            };

            return result;
        }

        public async Task<AddVehicleViewModel> GetVehicleForEditByIdAsync(string id)
        {
            Vehicle vehicle = await _context
                .Vehicles
                .Where(v => v.IsActive == true)
                .Include(c => c.Customer)
                .FirstAsync(v => v.Id.ToString() == id);

            IEnumerable<CustomerInfoOnVehicleViewModel> owners = await _context
                .Customers
                .Select(c => new CustomerInfoOnVehicleViewModel
                {
                    Id = c.Id.ToString(),
                    Name = $"{c.Name} {c.Surname}",
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email,

                })
                .ToArrayAsync();

            return new AddVehicleViewModel
            {
                Make = vehicle.Make,
                Model = vehicle.Model,
                Vin = vehicle.Vin,
                EngineNumber = vehicle.EngineNumber,
                RegNumber = vehicle.RegNumber,
                YearManufactured = vehicle.YearManufactured,
                FuelType = vehicle.FuelType,
                Mileage = vehicle.Mileage,
                CustomerId = vehicle.CustomerId.ToString(),
                Owner = owners
            };
        }

        public async Task EditVehicleByIdAndFormModelAsync(string vehicleId, AddVehicleViewModel vehicleViewModel)
        {
            Vehicle vehicle = await _context
                .Vehicles
                .FirstAsync(v => v.Id.ToString() == vehicleId);

            
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id.ToString() == vehicleViewModel.CustomerId);

            vehicle.Make = vehicleViewModel.Make;
            vehicle.Model = vehicleViewModel.Model;
            vehicle.Vin = vehicleViewModel.Vin;
            vehicle.RegNumber = vehicleViewModel.RegNumber ?? "N/A";
            vehicle.EngineNumber = vehicleViewModel.EngineNumber ?? "N/A";
            vehicle.YearManufactured = vehicleViewModel.YearManufactured;
            vehicle.FuelType = vehicleViewModel.FuelType;
            vehicle.Mileage = vehicleViewModel.Mileage ?? vehicle.Mileage;

            if (customer == null)
            {
                vehicle.CustomerId = Guid.Empty;
                vehicle.Customer = null;
            }

            vehicle.CustomerId = customer!.Id;
            vehicle.Customer = customer;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> SoftDeleteVehicleAsync(Guid vehicleId)
        {
            
            var vehicle = await _context.Vehicles.FindAsync(vehicleId);
            if (vehicle == null)
            {
                return false;
            }

            vehicle.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
