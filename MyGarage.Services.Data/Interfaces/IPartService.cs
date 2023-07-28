using MyGarage.Web.ViewModels.Part;

namespace MyGarage.Services.Data.Interfaces
{

    using MyGarage.Web.ViewModels.Vehicle;

    public interface IPartService
    {
        Task<IEnumerable<PartsViewModel>> AllPartsAsync();

        Task AddPartAsync(PartsViewModel part);

        Task<PartsViewModel> ViewPartDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<PartsViewModel> GetPartByIdAsync(string id);

        Task<PartsViewModel> GetPartForEditByIdAsync(string id);

        Task EditPartByIdAndFormModelAsync(string vehicleId, PartsViewModel vehicleViewModel);

        Task<bool> SoftDeletePartAsync(string vehicleId);

    }
}
