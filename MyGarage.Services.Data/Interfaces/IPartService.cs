using MyGarage.Web.ViewModels.Part;

namespace MyGarage.Services.Data.Interfaces
{
    using MyGarage.Web.ViewModels.Customer;

    public interface IPartService
    {
        Task<IEnumerable<AllPartsViewModel>> AllPartsAsync();

        Task AddPartAsync(AllPartsViewModel part);
    }
}
