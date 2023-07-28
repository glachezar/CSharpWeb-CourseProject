using MyGarage.Web.ViewModels.Mechanic;
using MyGarage.Web.ViewModels.Part;

namespace MyGarage.Services.Data.Interfaces
{


    public interface IMechanicService
    {
        Task<IEnumerable<MechanicViewModel>> AllMechanicsAsync();

        Task AddMechanicAsync(MechanicViewModel part);

        Task<MechanicViewModel> ViewMechanicDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<MechanicViewModel> GetMechanicByIdAsync(string id);

        Task<MechanicViewModel> GetMechanicForEditByIdAsync(string id);

        Task EditMechanicByIdAndFormModelAsync(string vehicleId, MechanicViewModel vehicleViewModel);

        Task<bool> SoftDeleteMechanicAsync(Guid vehicleId);
    }
}
