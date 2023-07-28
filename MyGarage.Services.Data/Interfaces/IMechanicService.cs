using MyGarage.Web.ViewModels.Mechanic;
using MyGarage.Web.ViewModels.Part;

namespace MyGarage.Services.Data.Interfaces
{


    public interface IMechanicService
    {
        Task<IEnumerable<MechanicViewModel>> AllMechanicsAsync();

        Task AddPartAsync(MechanicViewModel part);

        Task<MechanicViewModel> ViewPartDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<MechanicViewModel> GetPartByIdAsync(string id);

        Task<MechanicViewModel> GetPartForEditByIdAsync(string id);

        Task EditPartByIdAndFormModelAsync(string vehicleId, MechanicViewModel vehicleViewModel);

        Task<bool> SoftDeletePartAsync(Guid vehicleId);
    }
}
