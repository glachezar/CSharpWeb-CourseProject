using MyGarage.Data.Models;

namespace MyGarage.Services.Data.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using MyGarage.Data.Configurations;
    using MyGarage.Web.ViewModels.Vehicle;


    public interface IVehicleService
    {
        Task<IEnumerable<VehicleViewModel>> AllVehiclesAsync();

        Task AddVehicleAsync(AddVehicleViewModel vehicleViewModel);

        Task<bool> IsVehicleSoftDeletedAsync(string vin);

        Task<VehicleDetailsViewModel> ViewVehicleDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<AddVehicleViewModel> GetVehicleForEditByIdAsync(string id);

        Task EditVehicleByIdAndFormModelAsync(string vehicleId, AddVehicleViewModel vehicleViewModel);

        Task<bool> SoftDeleteVehicleAsync(Guid vehicleId);

        public Task<VehicleDeleteViewModel> GetVehicleByIdAsync(string id);
    }
}
