using Microsoft.AspNetCore.Server.IIS.Core;

namespace MyGarage.Services.Data
{
    using MyGarage.Data.Models;
    using Web.ViewModels.User;
    using MyGarage.Data;
    using Interfaces;



    public class UserService : IUserService
    {
        private readonly MyGarageDbContext _dbContext;
        private readonly ICustomerService _customerService;

        public UserService(MyGarageDbContext dbContext, ICustomerService customerService)
        {
            _dbContext = dbContext;
            _customerService = customerService;
        }

        public async Task<ApplicationUser> CreateUserByFormModelAsync(RegisterFormModel form)
        {
            throw new NotImplementedException();
        }
    }
}
