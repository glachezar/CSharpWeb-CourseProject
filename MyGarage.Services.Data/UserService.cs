namespace MyGarage.Services.Data
{
    using Microsoft.EntityFrameworkCore;

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

            return newUser;
        }

        public async Task<string> GetUserFullNameByEmailAsync(string email)
        {

            ApplicationUser? user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
