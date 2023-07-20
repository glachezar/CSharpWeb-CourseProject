namespace MyGarage.Services.Data.Interfaces
{
    using MyGarage.Data.Configurations;
    using MyGarage.Web.ViewModels.Vehicle;


    public interface IVehicleService
    {
        Task<IEnumerable<VehicleViewModel>> AllVehiclesAsync();

        Task AddVehicleAsync(AddVehicleViewModel vehicleViewModel);

        Task<VehicleDetailsViewModel> ViewVehicleDetailsByIdAsync(string id);

        Task<bool> VehicleExistingByIdAsync(string id);
    }
}
