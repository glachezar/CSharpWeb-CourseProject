namespace MyGarage.Services.Data.Interfaces
{
    using Web.ViewModels.Part;

    public interface IPartService
    {
        Task<IEnumerable<PartsViewModel>> AllPartsAsync();

        Task<IEnumerable<JobCardPartSelectFormModel>> AllPartsForFormModelAsync();

        Task AddPartAsync(PartsViewModel part);

        Task<PartsViewModel> ViewPartDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<PartsViewModel> GetPartByIdAsync(string id);

        Task<PartsViewModel> GetPartForEditByIdAsync(string id);

        Task EditPartByIdAndFormModelAsync(string vehicleId, PartsViewModel vehicleViewModel);

        Task<bool> SoftDeletePartAsync(Guid vehicleId);

    }
}
