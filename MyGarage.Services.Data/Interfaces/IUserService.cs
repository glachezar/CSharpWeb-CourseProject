namespace MyGarage.Services.Data.Interfaces
{

    using MyGarage.Data.Models;

    using Web.ViewModels.User;


    public interface IUserService
    {
        Task<ApplicationUser> CreateUserByFormModelAsync(RegisterFormModel form);
    }
}
