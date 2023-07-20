namespace MyGarage.Services.Data.Interfaces
{
    using MyGarage.Web.ViewModels.Customer;

    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> AllCustomersAsync();

        Task AddCustomerAsync(AddCustomerViewModel customer);

        Task<bool> CustomerHaveVehiclesByIdAsync(string id);

        Task<bool> CustomerExistByEmailAsync(string email);
    }
}
