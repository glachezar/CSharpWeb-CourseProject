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
            Customer customer = await _customerService.GetCustomerByEmailAsync(form.Email);

            ApplicationUser newUser = new ApplicationUser()
            {
                Email = customer.Email,
                FirstName = customer.Name,
                LastName = customer.Surname,
                CustomerId = customer.Id,
                Customer = customer
            };

            customer.ApplicationUserId = newUser.Id;
            customer.ApplicationUser = newUser;

            return newUser;
        }
    }
}
