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

        Task<CustomerViewModel> ViewCustomerDetailsByIdAsync(string id);

        Task<bool> ExistingByIdAsync(string id);

        Task<AddCustomerViewModel> GetCustomerForEditByIdAsync(string id);

        Task EditCustomerByIdAndFormModelAsync(string customerId, AddCustomerViewModel customerViewModel);

        Task AddUserToCustomerByModelAsync(Customer customer, ApplicationUser user);

        Task<CustomerViewModel> GetCustomerByIdAsync(string id);

        Task<bool> DeleteCustomerByIdAsync(string id);
    }
}
