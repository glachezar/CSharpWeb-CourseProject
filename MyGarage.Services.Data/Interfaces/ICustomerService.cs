namespace MyGarage.Services.Data.Interfaces
{
    using System.Runtime.CompilerServices;
    using Web.ViewModels.Customer;
    using MyGarage.Data.Models;


    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> AllCustomersAsync();

        Task<IEnumerable<CustomerInfoOnVehicleViewModel>> AllCustomersForSelectFormModelAsync();

        Task AddCustomerAsync(AddCustomerViewModel customer);

        Task<bool> CustomerHaveVehiclesByIdAsync(string id);

        Task<bool> CustomerExistByEmailAsync(string email);

        Task<Customer> GetCustomerByEmailAsync(string email);

        Task<CustomerViewModel> ViewCustomerDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<AddCustomerViewModel> GetCustomerForEditByIdAsync(string id);

        Task EditCustomerByIdAndFormModelAsync(string customerId, AddCustomerViewModel customerViewModel);

        Task<CustomerViewModel> GetCustomerByIdAsync(string id);

        Task<bool> DeleteCustomerByIdAsync(string id);
    }
}
