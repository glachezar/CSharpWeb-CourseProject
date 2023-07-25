namespace MyGarage.Services.Data.Interfaces
{
    using Web.ViewModels.Customer;
    using MyGarage.Data.Models;


    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> AllCustomersAsync();

        Task AddCustomerAsync(AddCustomerViewModel customer);

        Task<bool> CustomerHaveVehiclesByIdAsync(string id);

        Task<Customer> GetCustomerByEmailAsync(string email);
    }
}
