namespace MyGarage.Services.Data.Interfaces
{
    using Web.ViewModels.Vehicle;


    public interface IVehicleService
    {
        Task<IEnumerable<VehicleViewModel>> AllVehiclesAsync();

        Task<IEnumerable<VehicleViewModel>> AllVehiclesByUserIdAsync(string id);

        Task<IEnumerable<JobCardVehicleSelectFormModel>> AllVehiclesForFormModelAsync();

        Task AddVehicleAsync(AddVehicleViewModel vehicleViewModel);

        Task<VehicleDetailsViewModel> ViewVehicleDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<AddVehicleViewModel> GetVehicleForEditByIdAsync(string id);

        Task EditVehicleByIdAndFormModelAsync(string vehicleId, AddVehicleViewModel vehicleViewModel);

        Task<VehicleDeleteViewModel> GetVehicleByIdAsync(string id);

        Task AddOwnerToVehicleByIdAsync(string id, AddVehicleViewModel vehicleViewModel);

        Task<RemoveOwnerFormModel> GetVehicleToRemoveOwnerByIdAsync(string id);

        Task<bool> RemoveOwnerFromVehicleByIdAsync(RemoveOwnerFormModel model);

        Task<bool> IsVehicleSoftDeletedAsync(string vin);

        Task<bool> SoftDeleteVehicleAsync(Guid vehicleId);
    }
}
