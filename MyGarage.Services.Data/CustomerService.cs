using MyGarage.Data.Models;

namespace MyGarage.Services.Data
{

    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using MyGarage.Data;
    using Web.ViewModels.Customer;


    public class CustomerService : ICustomerService
    {
        private readonly MyGarageDbContext _dbContext;

        public CustomerService(MyGarageDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<CustomerViewModel>> AllCustomersAsync()
        {
            IEnumerable<CustomerViewModel> viewAllCustomers = await this._dbContext
                .Customers
                .AsNoTracking()
                .Select(c => new CustomerViewModel()
                {
                    Id = c.Id.ToString(),
                    FirstName = c.Name,
                    LastName = c.Surname,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email
                })
                .ToArrayAsync();

            return viewAllCustomers;
        }

        public async Task AddCustomerAsync(AddCustomerViewModel customer)
        {
            Customer newCustomer = new Customer()
            {
                Name = customer.Name,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber,
                Egn = customer.Egn,
                Email = customer.Email,
                Address = customer.Address,
            };

            await _dbContext.AddAsync(newCustomer);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<bool> CustomerHaveVehiclesByIdAsync(string id)
        {
            Customer? customer = await this._dbContext
                .Customers
                .FirstOrDefaultAsync(c => c.Id.ToString() == id);

            if (customer == null)
            {
                return false;
            }

            return customer.Vehicles!.Any();
        }

        public async Task<bool> CustomerExistByEmailAsync(string email)
        {
            var customer = await this._dbContext
                .Customers
                .FirstOrDefaultAsync(u => u.Email.ToUpper() == email.ToUpper());
            if (customer == null)
            {
                return false;
            }

            return true;
        }
    }
}
