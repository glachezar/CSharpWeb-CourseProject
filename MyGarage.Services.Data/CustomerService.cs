using MyGarage.Web.ViewModels.Vehicle;

namespace MyGarage.Services.Data
{

    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using MyGarage.Data;
    using Web.ViewModels.Customer;
    using MyGarage.Data.Models;




    public class CustomerService : ICustomerService
    {
        private readonly MyGarageDbContext _context;

        public CustomerService(MyGarageDbContext dbContext)
        {
            this._context = dbContext;
        }
        public async Task<IEnumerable<CustomerViewModel>> AllCustomersAsync()
        {
            IEnumerable<CustomerViewModel> viewAllCustomers = await this._context
                .Customers
                .AsNoTracking()
                .Select(c => new CustomerViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Surname = c.Surname,
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

            await _context.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CustomerHaveVehiclesByIdAsync(string id)
        {
            Customer? customer = await this._context
                .Customers
                .FirstOrDefaultAsync(c => c.Id.ToString() == id);

            if (customer == null)
            {
                return false;
            }

            bool customerHaveVehicles = customer.Vehicles.Any();

            return customerHaveVehicles;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            string normalizedEmail = email.ToUpper();
            Customer? customerByEmail = await _context.Customers.FirstOrDefaultAsync(c => c.Email.ToUpper() == normalizedEmail);

            if (customerByEmail == null)
            {
                return null;
            }

            return customerByEmail;
        }

        public async Task<CustomerViewModel> ViewCustomerDetailsByIdAsync(string id)
        {
            Customer? customer = await _context
                .Customers
                .Include(c => c.Vehicles)
                .FirstOrDefaultAsync(v => v.Id.ToString() == id);

            if (customer == null)
            {
                return null;
            }

            return new CustomerViewModel
            {
                Id = customer.Id.ToString(),
                Name = customer.Name,
                Surname = customer.Surname,
                Egn = customer.Egn,
                Address = customer.Address,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Vehicles = customer.Vehicles
            };
        }

        public async Task<bool> ExistingByIdAsync(string id)
        {
            bool result = await _context
                .Customers
                .AnyAsync(v => v.Id.ToString() == id);

            return result;
        }

        public async Task<AddCustomerViewModel> GetCustomerForEditByIdAsync(string id)
        {
            Guid vId = Guid.Parse(id);
            var customer = await _context.Customers.FindAsync(vId);

            AddCustomerViewModel result = new AddCustomerViewModel()
            {
                Name = customer.Name,
                Surname = customer.Surname,
                Egn = customer.Egn,
                Address = customer.Address,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };

            return result;
        }

        public async Task EditCustomerByIdAndFormModelAsync(string customerId, AddCustomerViewModel customerViewModel)
        {
            Customer customer = await _context
                .Customers
                .FirstAsync(v => v.Id.ToString() == customerId);

            customer.Name = customerViewModel.Name;
            customer.Surname = customerViewModel.Surname;
            customer.Egn = customerViewModel.Egn;
            customer.Address = customerViewModel.Address;
            customer.Email = customerViewModel.Email;
            customer.PhoneNumber = customerViewModel.PhoneNumber;
            
            await _context.SaveChangesAsync();
        }

        public async Task<CustomerViewModel> GetCustomerByIdAsync(string id)
        {
            Guid cId = Guid.Parse(id);
            var customer = await _context.Customers.FindAsync(cId);

            CustomerViewModel result = new CustomerViewModel
            {
                Id = customer.Id.ToString(),
                Name = customer.Name,
                Surname = customer.Surname,
                Egn = customer.Egn,
                Address = customer.Address,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                ApplicationUserId = customer.ApplicationUserId,
                ApplicationUser = customer.ApplicationUser,
                Vehicles = customer.Vehicles
            };

            return result;
        }

        public async Task<bool> DeleteCustomerByIdAsync(string id)
        {
            Guid customerId = Guid.Parse(id);
            Customer customerToDelete = await _context.Customers.FindAsync(customerId);
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
