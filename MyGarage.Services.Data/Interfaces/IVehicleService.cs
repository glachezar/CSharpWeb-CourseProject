using MyGarage.Data.Models;

namespace MyGarage.Services.Data.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using MyGarage.Data.Configurations;
    using MyGarage.Web.ViewModels.Vehicle;


    public interface IVehicleService
    {
        Task<IEnumerable<VehicleViewModel>> AllVehiclesAsync();

        Task<IEnumerable<JobCardVehicleSelectFormModel>> AllVehiclesForFormModelAsync();

        Task AddVehicleAsync(AddVehicleViewModel vehicleViewModel);

        Task<VehicleDetailsViewModel> ViewVehicleDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<AddVehicleViewModel> GetVehicleForEditByIdAsync(string id);

        Task EditVehicleByIdAndFormModelAsync(string vehicleId, AddVehicleViewModel vehicleViewModel);

        Task<VehicleDeleteViewModel> GetVehicleByIdAsync(string id);

        Task AddOwnerToVehicleByIdAsync(string id,  string ownerId);

        Task<bool> IsVehicleSoftDeletedAsync(string vin);

        Task<bool> SoftDeleteVehicleAsync(Guid vehicleId);
    }
}
