using MyGarage.Web.ViewModels.Mechanic;

namespace MyGarage.Services.Data.Interfaces
{


    public interface IMechanicService
    {
        Task<IEnumerable<MechanicViewModel>> AllMechanicsAsync();
    }
}
