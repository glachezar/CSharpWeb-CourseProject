using Microsoft.AspNetCore.Identity;
using MyGarage.Data.Models;
using MyGarage.Web.ViewModels.User;

namespace MyGarage.Services.Data.Interfaces
{


    public interface IUserService
    {
        Task<ApplicationUser> CreateUserByFormModelAsync(RegisterFormModel form);
    }
}
